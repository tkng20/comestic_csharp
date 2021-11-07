using System;
using System.Collections.Generic;

namespace comestic.Models
{
    public partial class Shippings
    {
        public Shippings()
        {
            Orders = new HashSet<Orders>();
        }

        public long Id { get; set; }
        public string Type { get; set; }
        public decimal Price { get; set; }
        public string Status { get; set; }

        public DateTime Created_at { get; set;}
        public DateTime Updated_at { get; set;}

        public virtual ICollection<Orders> Orders { get; set; }
    }
}
