using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using BotDetect.Web;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Pishkhan.Data;
using Pishkhan.Models;

namespace Pishkhan.Controllers
{
    public class AccountController : Controller
    {
        private readonly SignInManager<AppIdentityUser> signInManager;
        private readonly UserManager<AppIdentityUser> userManager;
        private readonly JwtConfigModel jwtTokenModel;
        public AccountController(SignInManager<AppIdentityUser> signInManager,
            UserManager<AppIdentityUser> userManager,
            IOptions<JwtConfigModel> options)
        {
            this.signInManager = signInManager;
            this.userManager = userManager;
            jwtTokenModel = options.Value;
        }
        [HttpPost]
        [Route("api/login")]
        public async Task<IActionResult> Login([FromBody]Models.LoginModel loginModel)
        {
            if (!ModelState.IsValid) return Ok(ServiceResult.Error(ModelState));

            // create a captcha instance to be used for the captcha validation
            SimpleCaptcha yourFirstCaptcha = new SimpleCaptcha();
            // execute the captcha validation
            bool isHuman = yourFirstCaptcha.Validate(loginModel.UserEnteredCaptchaCode, loginModel.CaptchaId);

            if (isHuman == false)
                return Ok(ServiceResult.Error("کد امنیتی اشتباه است"));

            var result = await signInManager.PasswordSignInAsync(loginModel.UserName, loginModel.Password, false, false);

            if (result.Succeeded)
            {
                var appUser = await userManager.FindByNameAsync(loginModel.UserName);

                return Ok(ServiceResult<string>.Okay(GenerateJwtToken(appUser)));
            }

            return Ok(ServiceResult.Error("کاربری یافت نشد"));
        }

        [HttpPost]
        [Route("api/register")]
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

            if (userManager.Users.Any(c => c.PhoneNumber.Equals(registerModel.PhoneNumber)))
                return Ok(ServiceResult.Error("شماره همراه متعلق به شخص دیگری است"));

            var result = await userManager.CreateAsync(new AppIdentityUser
            {
                NationalCode = registerModel.NationalCode,
                UserName = registerModel.NationalCode,
                PhoneNumber = registerModel.PhoneNumber,

            }, registerModel.Password);


            if (result.Succeeded)
            {
                var appUser = await userManager.FindByNameAsync(registerModel.NationalCode);

                return Ok(ServiceResult<string>.Okay(GenerateJwtToken(appUser)));
            }

            var errors = result.Errors.Select(c => c.Description).ToList();

            return Ok(ServiceResult.Error(errors));
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