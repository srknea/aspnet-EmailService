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

        [HttpGet]
        public async Task<IActionResult> All()
        {
            var emailLogs = await _emailLogService.GetAllAsync();
            var emailLogsDto = _mapper.Map<List<EmailLogDto>>(emailLogs.ToList());

            return Ok(emailLogsDto);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {

            var emailLog = await _emailLogService.GetByIdAsync(id);

            var emailLogDto = _mapper.Map<EmailAddressDto>(emailLog);

            return Ok(emailLogDto);
        }



        [HttpPost("Send")]
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
        /*
        [HttpPost]
        public async Task<IActionResult> Save(EmailLogDto emailLogDto)
        {
            var emailLog = await _emailLogService.AddAsync(_mapper.Map<EmailLog>(emailLogDto));
            var dto = _mapper.Map<EmailLogDto>(emailLog);

            return Ok(dto);
        }
        */

        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove(int id)
        {
            var emailLog = await _emailLogService.GetByIdAsync(id);

            await _emailLogService.RemoveAsync(emailLog);

            return Ok();
        }

    }
}
