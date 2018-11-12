namespace WebMediaServer.ModelsDB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Likes_NotLikes
    {
        public int id { get; set; }

        [Required]
        [StringLength(128)]
        public string UserId { get; set; }

        public int ContentId { get; set; }

        public bool Bool_or { get; set; }

        public virtual AspNetUsers AspNetUsers { get; set; }

        public virtual Content Content { get; set; }
    }
}
