using MailApp.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailApp.Core.DTOs
{
    public class SendEmailDto
    {
        public string? Subject { get; set; }
        public string? Body { get; set; }

        public int EmailAddressId { get; set; }
    }
}
