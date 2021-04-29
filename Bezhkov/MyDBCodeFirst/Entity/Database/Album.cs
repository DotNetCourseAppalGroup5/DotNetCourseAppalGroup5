using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Database
{
   public class Album
    {
        public Album()
        {
            Photos = new HashSet<Photo>();
            TimeCreation = DateTime.Now;
        }
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        public int? UserId { get; set; }
        public DateTime TimeCreation { get; set; }
        public virtual ICollection<Photo> Photos { get; set; }
    }
}
