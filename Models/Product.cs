using System;
using System.Collections.Generic;

#nullable disable

namespace comestic_csharp.Models
{
    public partial class Product
    {
        public Product()
        {
            Carts = new HashSet<Cart>();
            Orders = new HashSet<Order>();
            Productattributes = new HashSet<Productattribute>();
            Productreviews = new HashSet<Productreview>();
            Wishlists = new HashSet<Wishlist>();
        }

        public ulong Id { get; set; }
        public string Title { get; set; }
        public string Slug { get; set; }
        public string Summary { get; set; }
        public string Description { get; set; }
        public string Photo1 { get; set; }
        public string Photo2 { get; set; }
        public string Photo3 { get; set; }
        public string Photo4 { get; set; }
        public int Stock { get; set; }
        public string Condition { get; set; }
        public string Status { get; set; }
        public decimal Price { get; set; }
        public ulong? CouponId { get; set; }
        public ulong? CatId { get; set; }
        public ulong? ChildCatId { get; set; }
        public ulong? BrandId { get; set; }

        public virtual Brand Brand { get; set; }
        public virtual Category Cat { get; set; }
        public virtual Category ChildCat { get; set; }
        public virtual Coupon Coupon { get; set; }
        public virtual ICollection<Cart> Carts { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
        public virtual ICollection<Productattribute> Productattributes { get; set; }
        public virtual ICollection<Productreview> Productreviews { get; set; }
        public virtual ICollection<Wishlist> Wishlists { get; set; }
    }
}
