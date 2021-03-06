using System;
using System.Collections.Generic;

namespace comestic.Models
{
    public partial class Carts
    {
        public Carts()
        {
            Wishlists = new HashSet<Wishlists>();
        }

        public long Id { get; set; }
        public long ProductId { get; set; }
        public long? OrderId { get; set; }
        public long? UserId { get; set; }
        public decimal Price { get; set; }
        public string Status { get; set; }
        public int Quantity { get; set; }
        public decimal Amount { get; set; }
        public DateTime Created_at { get; set;}
        public DateTime Updated_at { get; set;}

        public virtual Orders Order { get; set; }
        public virtual Products Product { get; set; }
        public virtual Users User { get; set; }
        public virtual ICollection<Wishlists> Wishlists { get; set; }
    }
}
