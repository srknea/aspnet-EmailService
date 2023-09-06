using AutoMapper;
using MailApp.Core.DTOs;
using MailApp.Core.Model;
using MailApp.Core.Services;
using MailApp.Service.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

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

        // GET : api/email
        [HttpGet]
        public async Task<IActionResult> All()
        {
            var emailAddress = await _emailAddressService.GetAllAsync();
            var emailAddressDto = _mapper.Map<List<EmailAddressDto>>(emailAddress.ToList());

            return Ok(emailAddressDto);
        }

        // GET : api/email/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {

            var emailAddress = await _emailAddressService.GetByIdAsync(id);

            var emailAddressDto = _mapper.Map<EmailAddressDto>(emailAddress);

            return Ok(emailAddressDto);
        }

        [HttpPost]
        public async Task<IActionResult> Save(EmailAddressDto emailAddressDto)
        {
            var emailAddress = await _emailAddressService.AddAsync(_mapper.Map<EmailAddress>(emailAddressDto));
            var dto = _mapper.Map<EmailAddressDto>(emailAddress);

            return Ok(dto);
        }

        [HttpPut]
        public async Task<IActionResult> Update(EmailAddressDto emailAddressDto)
        {
            await _emailAddressService.UpdateAsync(_mapper.Map<EmailAddress>(emailAddressDto));

            return Ok();
        }

        // DELETE : api/email/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove(int id)
        {
            var emailAddress = await _emailAddressService.GetByIdAsync(id);

            await _emailAddressService.RemoveAsync(emailAddress);

            return Ok();
        }

    }
}
