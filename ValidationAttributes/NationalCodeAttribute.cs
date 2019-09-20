using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using DNTPersianUtils.Core;

namespace Pishkhan.ValidationAttributes
{
    public class NationalCodeAttribute:ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if (value == null) return false;

            var nationalCode = (string)value;

            return nationalCode.IsValidIranianNationalCode();
        }
    }
}
