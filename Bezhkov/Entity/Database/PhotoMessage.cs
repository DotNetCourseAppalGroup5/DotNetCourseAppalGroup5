using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Database
{
   public class PhotoMessage
    {
        public int Id { get; set; }
        public int? PhotoId { get; set; }
        public int? MessageId { get; set; }
        public virtual Photo Photos { get; set; }
        public virtual Message Message { get; set; }
    }
}
