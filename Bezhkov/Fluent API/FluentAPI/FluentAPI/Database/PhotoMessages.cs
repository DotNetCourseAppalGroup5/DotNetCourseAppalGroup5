namespace FluentAPI
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class PhotoMessages
    {
        public int Id { get; set; }

        public int? PhotoId { get; set; }

        public int? MessageId { get; set; }

        public virtual Messages Messages { get; set; }

        public virtual Photos Photos { get; set; }
    }
}
