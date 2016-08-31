//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Rhythm.Domain.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class Post
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Post()
        {
            this.Comments = new HashSet<Comment>();
            this.Tags = new HashSet<Tag>();
        }
    
        public int ID { get; set; }
        public string NameSenderPost { get; set; }
        public string Title { get; set; }
        public string ShortDescription { get; set; }
        public string DescriptionPost { get; set; }
        public string UrlSlug { get; set; }
        public bool Published { get; set; }
        public System.DateTime PostedOn { get; set; }
        public Nullable<System.DateTime> Modified { get; set; }
        public int Category { get; set; }
        public byte[] ImageData { get; set; }
        public string ImageMime { get; set; }
        public Nullable<int> CountComments { get; set; }
    
        public virtual Category Category1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Comment> Comments { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tag> Tags { get; set; }
    }
}
