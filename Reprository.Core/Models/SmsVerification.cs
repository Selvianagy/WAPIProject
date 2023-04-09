using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reprository.Core.Models
{
    public class SmsVerification
    {
        public string AccountSID { get; set; }  
        public string AuthToken { get; set; }  
        public string TwilioPhoneNumber { get; set; }  
    }
}
