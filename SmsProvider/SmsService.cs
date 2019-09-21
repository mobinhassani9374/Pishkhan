using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pishkhan.SmsProvider
{
    public class SmsService
    {
        public void Send(string phoneNumber, string message)
        {
            // code send sms here
            System.IO.File.WriteAllText("verify.txt", message);
        }
    }
}
