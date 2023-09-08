using MailApp.Core.DTOs;
using MailApp.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailApp.Core.Services
{
    public interface IEmailAddressService : IService<EmailAddress>
    {
        public Task<EmailAddressWithEmailLogDto> GetSingleEmailAddressByIdWithEmailLogsAsync(int emailAddressId);
    }
}
