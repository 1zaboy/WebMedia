namespace WebMediaServer.ModelsDB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Subscribe")]
    public partial class Subscribe
    {
        public int id { get; set; }

        [Required]
        [StringLength(128)]
        public string UserId1 { get; set; }

        [Required]
        [StringLength(128)]
        public string UserId2 { get; set; }

        public virtual AspNetUsers AspNetUsers { get; set; }

        public virtual AspNetUsers AspNetUsers1 { get; set; }
    }
}
