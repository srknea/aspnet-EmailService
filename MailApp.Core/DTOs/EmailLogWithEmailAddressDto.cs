using MailApp.Core.DTOs;
using MailApp.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailApp.Core.DTOs
{
    public class EmailLogWithEmailAddressDto : EmailLogDto
    {
        public EmailAddressDto EmailAddress { get; set; }
    }
}
