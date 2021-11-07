using System;
using System.Collections.Generic;

namespace comestic.Models
{
    public partial class PostTags
    {
        public PostTags()
        {
            Posts = new HashSet<Posts>();
        }

        public long Id { get; set; }
        public string Title { get; set; }
        public string Slug { get; set; }
        public string Status { get; set; }
        public DateTime Created_at { get; set;}
        public DateTime Updated_at { get; set;}

        public virtual ICollection<Posts> Posts { get; set; }
    }
}
