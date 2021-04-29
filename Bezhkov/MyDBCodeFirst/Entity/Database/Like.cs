using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Database
{
   public class Like
    {
        public int Id { get; set; }

        public int? UserId { get; set; }

        public bool Сondition { get; set; }


        [ForeignKey("UserId")]
        public virtual User Users { get; set; }
    }
}
