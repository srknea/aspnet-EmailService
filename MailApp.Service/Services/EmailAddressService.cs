using AutoMapper;
using MailApp.Core.DTOs;
using MailApp.Core.Model;
using MailApp.Core.Repositories;
using MailApp.Core.Services;
using MailApp.Core.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailApp.Service.Services
{
    public class EmailAddressService : Service<EmailAddress>, IEmailAddressService
    {
        private readonly IEmailAddressRepository _emailAddressRepository;
        private readonly IMapper _mapper;
        public EmailAddressService(IGenericRepository<EmailAddress> repository, IUnitOfWork unitOfWork, IMapper mapper, IEmailAddressRepository emailAddressRepository) : base(repository, unitOfWork)
        {
            _mapper = mapper;
            _emailAddressRepository = emailAddressRepository;
        }

        public async Task<EmailAddressWithEmailLogDto> GetSingleEmailAddressByIdWithEmailLogsAsync(int emailAddressId)
        {
            var emailAddress = await _emailAddressRepository.GetSingleEmailAddressByIdWithEmailLogsAsync(emailAddressId);

            EmailAddressWithEmailLogDto dto = _mapper.Map<EmailAddressWithEmailLogDto>(emailAddress);

            return dto;
        }
    }
}
