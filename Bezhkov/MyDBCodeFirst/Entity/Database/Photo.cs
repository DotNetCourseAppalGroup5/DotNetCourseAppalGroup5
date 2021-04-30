using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Database
{
   public class Photo
    {
        public Photo()
        {
            TimeCreation = DateTime.Now;
            LikePhotos = new HashSet<LikePhoto>();
        }
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Path { get; set; }
        public int? AlbumId { get; set; }
        public DateTime TimeCreation { get; set; }
        public virtual Album Albums { get; set; }
        public virtual ICollection<LikePhoto> LikePhotos { get; set; }
        public virtual ICollection<PhotoMessage> PhotoMessages { get; set; }
    }
}
