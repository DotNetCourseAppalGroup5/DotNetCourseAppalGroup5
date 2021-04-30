namespace FluentAPI
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Likes
    {
        public int Id { get; set; }

        public int? UserId { get; set; }

        public bool Сondition { get; set; }

        [Required]
        [StringLength(128)]
        public string Discriminator { get; set; }

        public int? Photos_Id { get; set; }

        public int? Avatars_Id { get; set; }

        public virtual Avatars Avatars { get; set; }

        public virtual Photos Photos { get; set; }

        public virtual Users Users { get; set; }
    }
}
