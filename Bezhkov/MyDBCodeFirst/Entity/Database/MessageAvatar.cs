using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Database
{
   public class MessageAvatar
    {
        public int Id { get; set; }
        public int? AvatarId { get; set; }
        public int? MessageId { get; set; }
        public virtual Avatar Avatars { get; set; }
        public virtual Message Messages { get; set; }
    }
}
