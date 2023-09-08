using AutoMapper;
using MailApp.Core.DTOs;
using MailApp.Core.Model;
using MailApp.Core.Services;
using MailApp.Repository;
using MailApp.Service.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NLayerApp.Core.DTOs;
using System.Collections.Generic;

namespace MailApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmailController : ControllerBase
    {
        
        private readonly IEmailAddressService _emailAddressService;
        private readonly IMapper _mapper;
        private readonly AppDbContext _context;

        public EmailController(IEmailAddressService emailAddressService, IMapper mapper, AppDbContext appDbContext, AppDbContext context)
        {
            _emailAddressService = emailAddressService;
            _mapper = mapper;
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> All()
        {
            var emailAddress = await _emailAddressService.GetAllAsync();
            var emailAddressDto = _mapper.Map<List<EmailAddressDto>>(emailAddress.ToList());

            return Ok(emailAddressDto);
        }

        [HttpGet("[action]/{emailAddressId}")]
        public async Task<IActionResult> GetSingleEmailAddressByWithEmailLog(int emailAddressId)
        {
            var emailAddressWithEmailLogDto = await _emailAddressService.GetSingleEmailAddressByWithEmailLogAsync(emailAddressId);

            return Ok(emailAddressWithEmailLogDto);
        }

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
            // Aynı ürün adıyla başka bir kayıt var mı?
            var isExsist =  await _context.EmailAddresses.AnyAsync(e => e.Email == emailAddressDto.Email);
            
            if (isExsist)
            {
                return BadRequest("Bu e-posta adresi zaten mevcut.");
            }

            var emailAddress = await _emailAddressService.AddAsync(_mapper.Map<EmailAddress>(emailAddressDto));
            var dto = _mapper.Map<EmailAddressDto>(emailAddress);

            return Ok(dto);
        }

        [HttpPut]
        public async Task<IActionResult> Update(EmailAddressUpdateDto emailAddressUpdateDto)
        {
            await _emailAddressService.UpdateAsync(_mapper.Map<EmailAddress>(emailAddressUpdateDto));

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove(int id)
        {
            var emailAddress = await _emailAddressService.GetByIdAsync(id);

            await _emailAddressService.RemoveAsync(emailAddress);

            return Ok();
        }

    }
}
