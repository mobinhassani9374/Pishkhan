using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Pishkhan.Models
{
    public class VerificationModel
    {
        [Required(ErrorMessage = "شماره همراه نمی تواند فاقد مقدار باشد")]
        public string PhoneNumber { get; set; }

        public int ActivationCode { get; set; }
    }
}
