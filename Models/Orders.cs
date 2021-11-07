using System;
using System.Collections.Generic;

namespace comestic.Models
{
    public partial class Orders
    {
        public Orders()
        {
            Carts = new HashSet<Carts>();
        }

        public long Id { get; set; }
        public string OrderNumber { get; set; }
        public long? UserId { get; set; }
        public decimal SubTotal { get; set; }
        public long? ShippingId { get; set; }
        public long? CouponId { get; set; }
        public decimal TotalAmount { get; set; }
        public int Quantity { get; set; }
        public string PaymentMethod { get; set; }
        public string PaymentStatus { get; set; }
        public string Status { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Country { get; set; }
        public string Address { get; set; }
        public DateTime Created_at { get; set;}
        public DateTime Updated_at { get; set;}

        public virtual Coupons Coupon { get; set; }
        public virtual Shippings Shipping { get; set; }
        public virtual Users User { get; set; }
        public virtual ICollection<Carts> Carts { get; set; }
    }
}
