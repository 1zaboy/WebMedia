namespace WebMediaServer.ModelsDB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Content")]
    public partial class Content
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Content()
        {
            Comments = new HashSet<Comments>();
            Likes_NotLikes = new HashSet<Likes_NotLikes>();
            Views_Con = new HashSet<Views_Con>();
        }

        public int id { get; set; }

        [Required]
        [StringLength(200)]
        public string NameVideo { get; set; }

        [Required]
        [StringLength(128)]
        public string UserId { get; set; }

        [Required]
        public string Url1 { get; set; }

        public string Url2 { get; set; }

        public DateTime DateAddVideo { get; set; }

        public TimeSpan? LengthVideo { get; set; }

        public int TypeContent { get; set; }

        public string Text_Description { get; set; }

        public virtual AspNetUsers AspNetUsers { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Comments> Comments { get; set; }

        public virtual TypeContent TypeContent1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Likes_NotLikes> Likes_NotLikes { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Views_Con> Views_Con { get; set; }
    }
}
