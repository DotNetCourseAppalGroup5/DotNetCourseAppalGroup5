namespace FluentAPI
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class MessageAvatars
    {
        public int Id { get; set; }

        public int? AvatarId { get; set; }

        public int? MessageId { get; set; }

        public virtual Avatars Avatars { get; set; }

        public virtual Messages Messages { get; set; }
    }
}
