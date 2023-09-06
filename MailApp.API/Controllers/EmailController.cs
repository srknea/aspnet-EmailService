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
    public class EmailController : ControllerBase
    {
        private readonly IEmailAddressService _emailAddressService;
        private readonly IMapper _mapper;

        public EmailController(IEmailAddressService emailAddressService, IMapper mapper)
        {
            _emailAddressService = emailAddressService;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> Save(EmailAddressDto emailAddressDto)
        {
            var emailAddress = await _emailAddressService.AddAsync(_mapper.Map<EmailAddress>(emailAddressDto));
            var dto = _mapper.Map<EmailAddressDto>(emailAddress);

            return Ok(dto);
            // 201 : Oluşturuldu anlamında kullanılır. İşlem başarılı ise 201 döndürülebilir.
        }

    }
}
