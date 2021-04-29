using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Database
{
   public class Dialog
    {
        public Dialog()
        {
            Messages = new HashSet<Message>();
            UserDialogs = new HashSet<UserDialog>();
        }
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        public DateTime TimeCreation { get; set; }
        public virtual ICollection<Message> Messages { get; set; }
        public virtual ICollection<UserDialog> UserDialogs { get; set; }
    }
}
