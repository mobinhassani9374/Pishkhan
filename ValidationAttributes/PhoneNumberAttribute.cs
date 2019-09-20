using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using DNTPersianUtils.Core;

namespace Pishkhan.ValidationAttributes
{
    public class PhoneNumberAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if (value == null) return false;

            var phoneNumber = (string)value;

            return phoneNumber.IsValidIranianMobileNumber();
        }
    }
}
