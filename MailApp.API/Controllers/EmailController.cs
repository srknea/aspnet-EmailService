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
        public EmailController(IEmailAddressService emailAddressService)
        {
            _emailAddressService = emailAddressService;
        }

        [HttpPost]
        public async Task<IActionResult> Save(EmailAddress emailAddress)
        {
            await _emailAddressService.AddAsync(emailAddress);

            return Ok();
            // 201 : Oluşturuldu anlamında kullanılır. İşlem başarılı ise 201 döndürülebilir.
        }

    }
}
