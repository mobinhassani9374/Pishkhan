using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pishkhan.Models
{
    public class RegisterModel
    {
        public string NationalCode { get; set; }

        public string PhoneNumber { get; set; }

        public string Password { get; set; }

        public string ConfirmPassword { get; set; }
    }
}
