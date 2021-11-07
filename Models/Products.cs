using System;
using System.Collections.Generic;

namespace comestic.Models
{
    public partial class Products
    {
        public Products()
        {
            Carts = new HashSet<Carts>();
            ProductReviews = new HashSet<ProductReviews>();
            Wishlists = new HashSet<Wishlists>();
        }

        public long Id { get; set; }
        public string Title { get; set; }
        public string Slug { get; set; }
        public string Summary { get; set; }
        public string Description { get; set; }
        public string Photo1 { get; set; }
        public string Photo2 { get; set; }
        public string Photo3 { get; set; }
        public string Photo4 { get; set; }
        public int Stock { get; set; }
        public string Color { get; set; }
        public string Condition { get; set; }
        public string Status { get; set; }
        public decimal Price { get; set; }
        public long? CouponId { get; set; }
        public long? CatId { get; set; }
        public long? ChildCatId { get; set; }
        public long? BrandId { get; set; }
        public DateTime Created_at { get; set;}
        public DateTime Updated_at { get; set;}

        public virtual Brands Brand { get; set; }
        public virtual Categories Cat { get; set; }
        public virtual Categories ChildCat { get; set; }
        public virtual Coupons Coupon { get; set; }
        public virtual ICollection<Carts> Carts { get; set; }
        public virtual ICollection<ProductReviews> ProductReviews { get; set; }
        public virtual ICollection<Wishlists> Wishlists { get; set; }
    }
}
