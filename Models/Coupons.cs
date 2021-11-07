using System;
using System.Collections.Generic;

namespace comestic.Models
{
    public partial class Coupons
    {
        public Coupons()
        {
            Orders = new HashSet<Orders>();
            Products = new HashSet<Products>();
        }

        public long Id { get; set; }
        public string Code { get; set; }
        public string Type { get; set; }
        public decimal Value { get; set; }
        public string Status { get; set; }
        public bool IsVoucher { get; set; }
        public int Quantity { get; set; }
        public DateTime Created_at { get; set;}
        public DateTime Ended_at { get; set;}
        public DateTime Updated_at { get; set;}

        public virtual ICollection<Orders> Orders { get; set; }
        public virtual ICollection<Products> Products { get; set; }
    }
}
