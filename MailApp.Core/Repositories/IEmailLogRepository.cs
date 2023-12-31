﻿using MailApp.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailApp.Core.Repositories
{
    public interface IEmailLogRepository : IGenericRepository<EmailLog>
    {
        Task<List<EmailLog>> GetEmailLogsWithEmailAddress();
    }
}
