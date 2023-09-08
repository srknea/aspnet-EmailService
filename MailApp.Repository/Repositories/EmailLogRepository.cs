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
    public class EmailLogRepository : GenericRepository<EmailLog>, IEmailLogRepository
    {
        public EmailLogRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<List<EmailLog>> GetEmailLogsWithEmailAddress()
        {
            // Eager Loading
            return await _context.EmailLogs.Include(x => x.EmailAddress).ToListAsync();
        }
    }
}
