using System;
using System.Collections.Generic;

namespace comestic.Models
{
    public partial class ProductReviews
    {
        public long Id { get; set; }
        public long? UserId { get; set; }
        public long? ProductId { get; set; }
        public byte Rate { get; set; }
        public string Review { get; set; }
        public string Status { get; set; }
        public DateTime Created_at { get; set;}
        public DateTime Updated_at { get; set;}

        public virtual Products Product { get; set; }
        public virtual Users User { get; set; }
    }
}
