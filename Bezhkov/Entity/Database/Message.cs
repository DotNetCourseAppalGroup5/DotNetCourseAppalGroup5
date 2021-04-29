using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Database
{
    public class Message
    {
        public int Id { get; set; }
        public int? DialogId { get; set; }

        [Column(TypeName = "text")]
        [Required]
        public string Text { get; set; }
        public bool TextChanged { get; set; }
        public User Users { get; set; }
        public virtual Dialog Dialogs { get; set; }

        
    }
}
