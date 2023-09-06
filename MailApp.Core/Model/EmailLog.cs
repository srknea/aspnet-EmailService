using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailApp.Core.Model
{
    public class EmailLog
    {
        public string? Subject { get; set; }
        public string? Body { get; set; }

        public List<EmailAddress> EmailAddresses { get; set; } = new List<EmailAddress>();
    }
}
