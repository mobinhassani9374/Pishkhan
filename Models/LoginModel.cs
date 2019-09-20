using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Pishkhan.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage = "نام کاربری نمی تواند فاقد مقدار باشد")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "رمز عبور نمی تواند فاقد مقدار باشد")]
        public string Password { get; set; }

        [Required()]
        public string UserEnteredCaptchaCode { get; set; }

        [Required()]
        public string CaptchaId { get; set; }
    }
}
