using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Database
{
   public class Friend
    {
        public int Id { get; set; }

        public int? User1Id { get; set; }
        public int? User2Id { get; set; }

        [ForeignKey("User1Id")]
        public virtual User User1 { get; set; }

        [ForeignKey("User2Id")]
        public virtual User User2 { get; set; }
    }
}
