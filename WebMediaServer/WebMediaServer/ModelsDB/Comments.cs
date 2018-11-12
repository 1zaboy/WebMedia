namespace WebMediaServer.ModelsDB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Comments
    {
        public int id { get; set; }

        [Required]
        [StringLength(128)]
        public string UserId { get; set; }

        public int ContentId { get; set; }

        public DateTime DateAddCom { get; set; }

        [Required]
        public string TextCom { get; set; }

        public virtual AspNetUsers AspNetUsers { get; set; }

        public virtual Content Content { get; set; }
    }
}
