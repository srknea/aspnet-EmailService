using MailApp.Core.Model;
using MailApp.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailApp.Repository.Repositories
{
    public class EmailAddressRepository : GenericRepository<EmailAddress>, IEmailAddressRepository
    {
        public EmailAddressRepository(AppDbContext context) : base(context)
        {
        }
    }
}
