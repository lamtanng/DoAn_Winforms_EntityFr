using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DemoDoAn
{
    internal class CheckError
    {
        public bool IsEmail(string email)
        {
            try
            {
                MailAddress m = new MailAddress(email);
                return true;
            }
            catch (FormatException)
            {
                return false;
            }
        }

        public bool IsPhone(string strPhone)
        {
            Regex isValidInput = new Regex(@"^\d{9,11}$");

            if (strPhone[0] != '0' || !isValidInput.IsMatch(strPhone))
                return false;
            return true;
        }

        
    }
}
