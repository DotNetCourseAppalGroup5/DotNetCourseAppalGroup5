using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Database
{
   public class UserDialog
    {
        public UserDialog()
        {
            TimeCreation = DateTime.Now;
        }
        public int Id { get; set; }
        public int? UserId { get; set; }
        public int? DialogId { get; set; }
        public DateTime TimeCreation { get; set; }
        public virtual Dialog Dialogs { get; set; }
        public virtual User Users { get; set; }
    }
}
