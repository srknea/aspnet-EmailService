using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailApp.Core.Model
{
    public class EmailLog : BaseEntity
    {
        public string? Subject { get; set; }
        public string? Body { get; set; }

        public int EmailAddressId { get; set; }
        public EmailAddress EmailAddress { get; set; }
    }
}
