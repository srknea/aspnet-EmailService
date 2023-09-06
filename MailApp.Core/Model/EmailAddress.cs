using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailApp.Core.Model
{
    public class EmailAddress
    {
        public string? Email { get; set; }

        public int EmailLogId { get; set; }
        public EmailLog EmailLog { get; set; }
    }
}
