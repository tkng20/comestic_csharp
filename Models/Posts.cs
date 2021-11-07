using System;
using System.Collections.Generic;

namespace comestic.Models
{
    public partial class Posts
    {
        public Posts()
        {
            PostComments = new HashSet<PostComments>();
        }

        public long Id { get; set; }
        public string Title { get; set; }
        public string Slug { get; set; }
        public string Summary { get; set; }
        public string Description { get; set; }
        public string Quote { get; set; }
        public string Photo { get; set; }
        public string Tags { get; set; }
        public long? PostCatId { get; set; }
        public long? PostTagId { get; set; }
        public long? AddedBy { get; set; }
        public string Status { get; set; }
        public DateTime Created_at { get; set;}
        public DateTime Updated_at { get; set;}

        public virtual Users AddedByNavigation { get; set; }
        public virtual PostCategories PostCat { get; set; }
        public virtual PostTags PostTag { get; set; }
        public virtual ICollection<PostComments> PostComments { get; set; }
    }
}
