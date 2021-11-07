using System;
using System.Collections.Generic;

#nullable disable

namespace comestic_csharp.Models
{
    public partial class Post
    {
        public Post()
        {
            Postcomments = new HashSet<Postcomment>();
            Postsandtags = new HashSet<Postsandtag>();
        }

        public ulong Id { get; set; }
        public string Title { get; set; }
        public string Slug { get; set; }
        public string Summary { get; set; }
        public string Description { get; set; }
        public string Quote { get; set; }
        public string Photo { get; set; }
        public ulong? PostCatId { get; set; }
        public ulong? AddedBy { get; set; }
        public string Status { get; set; }

        public virtual User AddedByNavigation { get; set; }
        public virtual Postcategory PostCat { get; set; }
        public virtual ICollection<Postcomment> Postcomments { get; set; }
        public virtual ICollection<Postsandtag> Postsandtags { get; set; }
    }
}
