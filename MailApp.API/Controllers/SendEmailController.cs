using AutoMapper;
using MailApp.Core.DTOs;
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


        public SendEmailController(IEmailLogService emailLogService, IMapper mapper)
        {
            _emailLogService = emailLogService;
            _mapper = mapper;
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

        [HttpPost]
        public async Task<IActionResult> Save(EmailLogDto emailLogDto)
        {
            var emailLog = await _emailLogService.AddAsync(_mapper.Map<EmailLog>(emailLogDto));
            var dto = _mapper.Map<EmailLogDto>(emailLog);

            return Ok(dto);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove(int id)
        {
            var emailLog = await _emailLogService.GetByIdAsync(id);

            await _emailLogService.RemoveAsync(emailLog);

            return Ok();
        }

    }
}
