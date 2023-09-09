using AutoMapper;
using AutoMapper.Internal;
using MailApp.API.Service;
using MailApp.Core.DTOs;
using MailApp.Core.Helpter;
using MailApp.Core.Model;
using MailApp.Core.Services;
using MailApp.Service.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MailApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SendEmailController : ControllerBase
    {
        private readonly IEmailLogService _emailLogService;
        private readonly IMapper _mapper;
        private readonly ISendEmailService _sendEmailService;
        private readonly IEmailAddressService _emailAddressService;

        public SendEmailController(IEmailLogService emailLogService, IMapper mapper, ISendEmailService sendEmailService, IEmailAddressService emailAddressService)
        {
            _emailLogService = emailLogService;
            _mapper = mapper;
            _sendEmailService = sendEmailService;
            _emailAddressService = emailAddressService;
        }

        [HttpPost]
        public async Task<IActionResult> Send(EmailLogDto emailLogDto)
        {

            var emailAddress = await _emailAddressService.GetByIdAsync(emailLogDto.EmailAddressId);

            try
            {
                MailRequest mailrequest = new MailRequest();
                mailrequest.ToEmail = emailAddress.Email;
                mailrequest.Subject = emailLogDto.Subject;
                mailrequest.Body = emailLogDto.Body;
                await _sendEmailService.SendEmailAsync(mailrequest);

                var emailLog = await _emailLogService.AddAsync(_mapper.Map<EmailLog>(emailLogDto));
                var dto = _mapper.Map<EmailLogDto>(emailLog);

                return Ok(dto);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [HttpPost("Test")]
        public async Task<IActionResult> Test(SendEmailDto sendEmailDto)
        {

            var emailLog = await _emailLogService.AddAsync(_mapper.Map<EmailLog>(sendEmailDto));
            var dto = _mapper.Map<EmailLogDto>(emailLog);

            return Ok(dto);
        }
    }
}
