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
    public class EmailLogService : Service<EmailLog>, IEmailLogService
    {
        private readonly IEmailLogRepository _emailLogRepository;
        private readonly IMapper _mapper;
        public EmailLogService(IGenericRepository<EmailLog> repository, IUnitOfWork unitOfWork, IEmailLogRepository emailLogRepository, IMapper mapper) : base(repository, unitOfWork)
        {
            _emailLogRepository = emailLogRepository;
            _mapper = mapper;
        }

        public async Task<List<EmailLogWithEmailAddressDto>> GetEmailLogsWithEmailAddress()
        {
            var emailLogs = await _emailLogRepository.GetEmailLogsWithEmailAddress();
            var emailLogWithEmailAddressDto = _mapper.Map<List<EmailLogWithEmailAddressDto>>(emailLogs);

            return emailLogWithEmailAddressDto;
        }
    }
}
