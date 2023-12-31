﻿using AutoMapper;
using MailApp.Core.DTOs;
using MailApp.Core.Model;
using MailApp.Core.Services;
using MailApp.Repository;
using MailApp.Service.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace MailApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmailAddressesController : ControllerBase
    {
        
        private readonly IEmailAddressService _emailAddressService;
        private readonly IMapper _mapper;
        private readonly AppDbContext _context;

        public EmailAddressesController(IEmailAddressService emailAddressService, IMapper mapper, AppDbContext appDbContext, AppDbContext context)
        {
            _emailAddressService = emailAddressService;
            _mapper = mapper;
            _context = context;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> All()
        {
            var emailAddress = await _emailAddressService.GetAllAsync();
            var emailAddressDto = _mapper.Map<List<EmailAddressDto>>(emailAddress.ToList());

            return Ok(emailAddressDto);
        }

        [HttpGet("GetAll/EmailAddressWithEmailLogs/{emailAddressId}")]
        public async Task<IActionResult> GetSingleEmailAddressByIdWithEmailLogs(int emailAddressId)
        {
            var emailAddressWithEmailLogDto = await _emailAddressService.GetSingleEmailAddressByIdWithEmailLogsAsync(emailAddressId);

            return Ok(emailAddressWithEmailLogDto);
        }

        [HttpGet("[action]/{id}")]
        public async Task<IActionResult> GetById(int id)
        {

            var emailAddress = await _emailAddressService.GetByIdAsync(id);

            var emailAddressDto = _mapper.Map<EmailAddressDto>(emailAddress);

            return Ok(emailAddressDto);
        }

        
        [HttpPost("Create")]
        public async Task<IActionResult> Save(EmailAddressCreateDto emailAddressCreateDto)
        {
            // Aynı ürün adıyla başka bir kayıt var mı?
            var isExsist =  await _context.EmailAddresses.AnyAsync(e => e.Email == emailAddressCreateDto.Email);
            
            if (isExsist)
            {
                return BadRequest("Bu e-posta adresi zaten mevcut.");
            }

            var emailAddress = await _emailAddressService.AddAsync(_mapper.Map<EmailAddress>(emailAddressCreateDto));
            var dto = _mapper.Map<EmailAddressDto>(emailAddress);

            return Ok(dto);
        }

        [HttpPut("Update")]
        public async Task<IActionResult> Update(EmailAddressUpdateDto emailAddressUpdateDto)
        {
            await _emailAddressService.UpdateAsync(_mapper.Map<EmailAddress>(emailAddressUpdateDto));

            return Ok();
        }

        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> Remove(int id)
        {
            var emailAddress = await _emailAddressService.GetByIdAsync(id);

            await _emailAddressService.RemoveAsync(emailAddress);

            return Ok();
        }

    }
}
