using MailApp.Core.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailApp.Core.DTOs
{
    public class EmailAddressWithEmailLogDto : EmailAddressDto
    {
        public List<EmailLogDto> EmailLogs { get; set; } 

    }
}
