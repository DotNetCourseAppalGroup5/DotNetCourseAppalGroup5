namespace FluentAPI
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Photos
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Photos()
        {
            Likes = new HashSet<Likes>();
            PhotoMessages = new HashSet<PhotoMessages>();
        }

        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Path { get; set; }

        public int? AlbumId { get; set; }

        public DateTime TimeCreation { get; set; }

        public virtual Albums Albums { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Likes> Likes { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PhotoMessages> PhotoMessages { get; set; }
    }
}
