using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using BotDetect.Web;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Pishkhan.Data;
using Pishkhan.Models;
using Pishkhan.Repositories;

namespace Pishkhan.Controllers
{
    public class AccountController : Controller
    {
        private readonly SignInManager<AppIdentityUser> signInManager;
        private readonly UserManager<AppIdentityUser> userManager;
        private readonly JwtConfigModel jwtTokenModel;
        private readonly UserPhoneNumberRepository _userPhoneNumberRepository;
        private readonly SettingRepository _settingRepository;
        public AccountController(SignInManager<AppIdentityUser> signInManager,
            UserManager<AppIdentityUser> userManager,
            IOptions<JwtConfigModel> options,
            UserPhoneNumberRepository userPhoneNumberRepository,
            SettingRepository settingRepository)
        {
            this.signInManager = signInManager;
            this.userManager = userManager;
            jwtTokenModel = options.Value;
            _userPhoneNumberRepository = userPhoneNumberRepository;
            _settingRepository = settingRepository;
        }
        [HttpPost]
        [Route("api/login")]
        [ValidateAntiForgeryToken()]
        public async Task<IActionResult> Login([FromBody]LoginModel loginModel)
        {
            if (!ModelState.IsValid) return Ok(ServiceResult.Error(ModelState));

            // create a captcha instance to be used for the captcha validation
            SimpleCaptcha yourFirstCaptcha = new SimpleCaptcha();
            // execute the captcha validation
            bool isHuman = yourFirstCaptcha.Validate(loginModel.UserEnteredCaptchaCode, loginModel.CaptchaId);

            if (isHuman == false)
                return Ok(ServiceResult.Error("کد امنیتی اشتباه است"));

            var appUser = userManager.Users.Include(c => c.PhoneNumbers).FirstOrDefault(c => c.UserName.Equals(loginModel.UserName)
                || c.NationalCode.Equals(loginModel.UserName)
                || c.PhoneNumbers.Any(i => i.PhoneNumber.Equals(loginModel.UserName)));

            if (appUser == null) return Ok(ServiceResult.Error("کاربری یافت نشد"));


            var verifyPass = userManager.PasswordHasher
                .VerifyHashedPassword(appUser, appUser.PasswordHash, loginModel.Password);

            // policy
            //appUser.PhoneNumbers.Any(c=>c.IsPrimary && c.IsConfirm)

            if (verifyPass == PasswordVerificationResult.Failed) return Ok(ServiceResult.Error("کاربری یافت نشد"));

            await signInManager.SignInAsync(appUser, true, JwtBearerDefaults.AuthenticationScheme);

            return Ok(ServiceResult<string>.Okay(GenerateJwtToken(appUser)));
        }

        [HttpPost]
        [Route("api/register")]
        [ValidateAntiForgeryToken()]
        public async Task<IActionResult> Register([FromBody]RegisterModel registerModel)
        {
            if (!ModelState.IsValid) return Ok(ServiceResult.Error(ModelState));

            // create a captcha instance to be used for the captcha validation
            SimpleCaptcha yourFirstCaptcha = new SimpleCaptcha();
            // execute the captcha validation
            bool isHuman = yourFirstCaptcha.Validate(registerModel.UserEnteredCaptchaCode, registerModel.CaptchaId);

            if (isHuman == false)
                return Ok(ServiceResult.Error("کد امنیتی اشتباه است"));

            // validation unique pjoneNumber and nationalCode
            if (userManager.Users.Any(c => c.NationalCode.Equals(registerModel.NationalCode)))
                return Ok(ServiceResult.Error("کد ملی متعلق به شخص دیگری است"));

            if (_userPhoneNumberRepository
                .AsQueryable()
                .Any(c => c.PhoneNumber.Equals(registerModel.PhoneNumber)))
                return Ok(ServiceResult.Error("شماره همراه متعلق به شخص دیگری است"));


            var result = await userManager.CreateAsync(new AppIdentityUser
            {
                NationalCode = registerModel.NationalCode,
                UserName = registerModel.UserName,
                IsAdmin = false

            }, registerModel.Password);


            if (result.Succeeded)
            {
                var appUser = await userManager.FindByNameAsync(registerModel.UserName);

                var activationCode = new Random().Next(1000, 9999);

                var verificationTime = _settingRepository.AsQueryable()
                    .FirstOrDefault(c => c.Key.Equals(Enums.Setting.VerificationTime.ToString()));

                int verificationTimeMin = 3;

                if (verificationTime != null)
                    verificationTimeMin = Convert.ToInt32(verificationTime.Value);

                _userPhoneNumberRepository.Create(new UserPhoneNumber
                {
                    IsConfirm = false,
                    IsPrimary = true,
                    PhoneNumber = registerModel.PhoneNumber,
                    UserId = appUser.Id,
                    ActivationCode = activationCode,
                    ActivationCodeExpireDate = DateTime.Now.AddMinutes(verificationTimeMin)
                });

                new SmsProvider.SmsService().Send(registerModel.PhoneNumber, $"کد فعالسازی شما : {activationCode}");

                return Ok(ServiceResult<int>.Okay(verificationTimeMin));
            }

            var errors = result.Errors.Select(c => c.Description).ToList();

            return Ok(ServiceResult.Error(errors));
        }

        [HttpPost]
        [Route("api/verify")]
        [ValidateAntiForgeryToken()]
        public IActionResult Verify([FromBody]VerificationModel verificationModel)
        {
            if (!ModelState.IsValid) return Ok(ServiceResult.Error(ModelState));

            var entity = _userPhoneNumberRepository
                  .AsQueryable()
                  .Include(c => c.User)
                  .FirstOrDefault(c => c.PhoneNumber.Equals(verificationModel.PhoneNumber));

            if (entity == null) return Ok(ServiceResult.Error("شماره همراه وارد شده در پایگاه داده موجود نمی باشد"));

            if (entity.IsConfirm)
                return Ok(ServiceResult.Error("شماره همراه مورد نظر قبلا فعال شده است"));

            if (entity.ActivationCode != verificationModel.ActivationCode)
                return Ok(ServiceResult.Error("کد فعالسازی معتبر نمی باشد"));

            if (entity.ActivationCodeExpireDate <= DateTime.Now)
            {
                entity.IsConfirm = true;

                var updateResult = _userPhoneNumberRepository.Update(entity);

                if (updateResult.IsSuccess)
                    return Ok(ServiceResult<string>.Okay(GenerateJwtToken(entity.User)));

                return Ok(ServiceResult.Error());
            }
            else return Ok(ServiceResult.Error("کد فعالسازی منقضی شده است"));

        }

        [HttpPost]
        [Route("api/reSendActivationCode")]
        [ValidateAntiForgeryToken()]
        public IActionResult ReSendActivationCode([FromBody]ReSendActivationCodeModel reSendActivationCodeModel)
        {
            if (!ModelState.IsValid) return Ok(ServiceResult.Error(ModelState));

            var entity = _userPhoneNumberRepository
                  .AsQueryable()
                  .FirstOrDefault(c => c.PhoneNumber.Equals(reSendActivationCodeModel.PhoneNumber));

            if (entity == null) return Ok(ServiceResult.Error("شماره همراه وارد شده در پایگاه داده موجود نمی باشد"));

            if (entity.IsConfirm) return Ok(ServiceResult.Error("شماره همراه قبلا فعال شده است"));

            var verificationTime = _settingRepository.AsQueryable()
                    .FirstOrDefault(c => c.Key.Equals(Enums.Setting.VerificationTime.ToString()));

            int verificationTimeMin = 3;

            if (verificationTime != null)
                verificationTimeMin = Convert.ToInt32(verificationTime.Value);

            entity.ActivationCode = new Random().Next(1000, 9999);
            entity.ActivationCodeExpireDate = DateTime.Now.AddMinutes(verificationTimeMin);

            var updateResult = _userPhoneNumberRepository.Update(entity);

            if (updateResult.IsSuccess)
                return Ok(ServiceResult<int>.Okay(verificationTimeMin));

            return Ok(ServiceResult.Error());
        }
        private string GenerateJwtToken(IdentityUser user)
        {
            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(ClaimTypes.NameIdentifier, user.Id)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtTokenModel.Key));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var expires = DateTime.Now.AddDays(Convert.ToDouble(jwtTokenModel.AuthenticationTimeDay));

            var token = new JwtSecurityToken(
                jwtTokenModel.Issuer,
                jwtTokenModel.Audience,
                claims,
                expires: expires,
                signingCredentials: creds
            );


            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }

}