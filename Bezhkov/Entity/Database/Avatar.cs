using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Database
{
   public class Avatar
    {
        public Avatar()
        {
            LikeAvatars = new HashSet<LikeAvatar>();
            MessageAvatars = new HashSet<MessageAvatar>();
        }
        public int? Id { get; set; }
        public int? UserId { get; set; }

        [Required]
        [StringLength(50)]
        public string Path { get; set; }
        public bool Active { get; set; }

        public virtual ICollection<LikeAvatar> LikeAvatars { get; set; }
        public virtual ICollection<MessageAvatar> MessageAvatars { get; set; }
    }
}
