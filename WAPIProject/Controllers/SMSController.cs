using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Reprository.Core.Interfaces;
using WAPIProject.DTO;

namespace WAPIProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SMSController : ControllerBase
    {
        private readonly ISmsSender smsSender;

        public SMSController(ISmsSender smsSender)
        {
            this.smsSender = smsSender;
        }

        [HttpPost("sendMessage")]
        public IActionResult SendMessage(SMSDTO smsDTO)
        {
            var resault = smsSender.Send(smsDTO.MobileNumber, smsDTO.Body);
            if(!string.IsNullOrEmpty(resault.ErrorMessage))
                BadRequest(resault.ErrorMessage);   

            return Ok(resault);
            

        }
    }
}
