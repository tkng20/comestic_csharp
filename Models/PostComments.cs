using System;
using System.Collections.Generic;

namespace comestic.Models
{
    public partial class PostComments
    {
        public long Id { get; set; }
        public long? UserId { get; set; }
        public long? PostId { get; set; }
        public string Comment { get; set; }
        public string Status { get; set; }
        public long? ParentId { get; set; }
        public DateTime Created_at { get; set;}
        public DateTime Updated_at { get; set;}

        public virtual Posts Post { get; set; }
        public virtual Users User { get; set; }
    }
}
