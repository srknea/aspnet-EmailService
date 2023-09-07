﻿using MailApp.Core.Model;
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
        public EmailLogService(IGenericRepository<EmailLog> repository, IUnitOfWork unitOfWork) : base(repository, unitOfWork)
        {
        }
    }
}
