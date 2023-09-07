using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailApp.Core.Model
{
    public class EmailAddress : BaseEntity
    {
        public string? Email { get; set; }

        public List<EmailLog> EmailLogs { get; set; } = new List<EmailLog>();
    }
}
