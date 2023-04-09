using Microsoft.Extensions.Options;
using Reprository.Core.Interfaces;
using Reprository.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Twilio;
using Twilio.Rest.Api.V2010.Account;

namespace Reprository.EF.Repositories
{
    public class SmsSenderRepository : ISmsSender
    {
        private readonly SmsVerification _smsVerification;

        public SmsSenderRepository(IOptions<SmsVerification> smsVerification)
        {
            _smsVerification = smsVerification.Value;
        }

        public MessageResource Send(string MobileNumber, string Body)
        {
            TwilioClient.Init(_smsVerification.AccountSID, _smsVerification.AuthToken);
            var resault = MessageResource.Create(
                  body:Body  ,
                  from : new Twilio.Types.PhoneNumber(_smsVerification.TwilioPhoneNumber),
                  to: MobileNumber
                );
            return resault;

        }
    }
}
