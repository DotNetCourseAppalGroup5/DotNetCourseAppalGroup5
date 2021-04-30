namespace FluentAPI
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class UserDialogs
    {
        public int Id { get; set; }

        public int? UserId { get; set; }

        public int? DialogId { get; set; }

        public DateTime TimeCreation { get; set; }

        public virtual Dialogs Dialogs { get; set; }

        public virtual Users Users { get; set; }
    }
}
