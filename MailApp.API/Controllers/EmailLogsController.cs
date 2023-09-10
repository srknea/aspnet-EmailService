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
    public class EmailLogsController : ControllerBase
    {
        private readonly IEmailLogService _emailLogService;
        private readonly IMapper _mapper;

        public EmailLogsController(IEmailLogService emailLogService, IMapper mapper)
        {
            _emailLogService = emailLogService;
            _mapper = mapper;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> All()
        {
            var emailLogs = await _emailLogService.GetAllAsync();
            var emailLogsDto = _mapper.Map<List<EmailLogDto>>(emailLogs.ToList());

            return Ok(emailLogsDto);
        }

        [HttpGet("GetById/{id}")]
        public async Task<IActionResult> GetById(int id)
        {

            var emailLog = await _emailLogService.GetByIdAsync(id);

            var emailLogDto = _mapper.Map<EmailLogDto>(emailLog);

            return Ok(emailLogDto);
        }
      
        [HttpGet("GetAll/EmailLogsWithEmailAddress")]
        public async Task<IActionResult> GetEmailLogsWithEmailAddress()
        {
            var emailLogWithEmailAddressDto = await _emailLogService.GetEmailLogsWithEmailAddress();
            return Ok(emailLogWithEmailAddressDto);
        }

        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> Remove(int id)
        {
            var emailLog = await _emailLogService.GetByIdAsync(id);

            await _emailLogService.RemoveAsync(emailLog);

            return Ok();
        }

    }
}
