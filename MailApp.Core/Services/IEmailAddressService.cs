using MailApp.Core.Model;
using NLayerApp.Core.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailApp.Core.Services
{
    public interface IEmailAddressService : IService<EmailAddress>
    {
        public Task<EmailAddressWithEmailLogDto> GetSingleCategoryByWithProductAsync(int emailAddressId);
    }
}
