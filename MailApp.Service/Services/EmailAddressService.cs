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
        public EmailAddressService(IGenericRepository<EmailAddress> repository, IUnitOfWork unitOfWork) : base(repository, unitOfWork)
        {
        }
    }
}
