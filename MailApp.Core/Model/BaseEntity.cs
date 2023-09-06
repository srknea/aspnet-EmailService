using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailApp.Core.Model
{
    //Nesne örneği alınmaması için abstract yapıldı.
    public abstract class BaseEntity
    {
        public int Id { get; set; }
        /*
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        */
    }
}
