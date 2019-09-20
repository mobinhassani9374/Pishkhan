using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Pishkhan.Models
{
    public class RegisterModel
    {
        [Required(ErrorMessage = "کد ملی نمی تواند فاقد مقدار باشد")]
        public string NationalCode { get; set; }

        [Required(ErrorMessage = "شماره همراه نمی تواند فاقد مقدار باشد")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "رمز عبور نمی تواند فاقد مقدار باشد")]
        public string Password { get; set; }

        [Required(ErrorMessage = "تکرار رمز عبور نمی تواند فاقد مقدار باشد")]
        [Compare(nameof(Password), ErrorMessage = "تکرار رمز عبور با رمز عبور مطابقت ندارد")]
        public string ConfirmPassword { get; set; }

        [Required()]
        public string UserEnteredCaptchaCode { get; set; }

        [Required()]
        public string CaptchaId { get; set; }
    }
}
