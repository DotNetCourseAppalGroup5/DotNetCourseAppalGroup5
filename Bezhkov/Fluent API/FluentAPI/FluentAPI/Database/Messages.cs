namespace FluentAPI
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Messages
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Messages()
        {
            MessageAvatars = new HashSet<MessageAvatars>();
            PhotoMessages = new HashSet<PhotoMessages>();
        }

        public int Id { get; set; }

        public int? DialogId { get; set; }

        [Column(TypeName = "text")]
        [Required]
        public string Text { get; set; }

        public bool TextChanged { get; set; }

        public int? Users_Id { get; set; }

        public virtual Dialogs Dialogs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MessageAvatars> MessageAvatars { get; set; }

        public virtual Users Users { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PhotoMessages> PhotoMessages { get; set; }
    }
}
