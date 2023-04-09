using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Twilio.Rest.Api.V2010.Account;

namespace Reprository.Core.Interfaces
{
    public interface ISmsSender
    {
        MessageResource Send(string MobileNumber, string Body);
    }
}
