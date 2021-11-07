using System;
using System.Collections.Generic;

namespace comestic.Models
{
    public partial class Users
    {
        public Users()
        {
            Carts = new HashSet<Carts>();
            Categories = new HashSet<Categories>();
            Orders = new HashSet<Orders>();
            PostComments = new HashSet<PostComments>();
            Posts = new HashSet<Posts>();
            ProductReviews = new HashSet<ProductReviews>();
            Wishlists = new HashSet<Wishlists>();
        }

        public long Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Photo { get; set; }
        public string Role { get; set; }
        public string Status { get; set; }
        public string RememberToken { get; set; }

        public DateTime Created_at { get; set;}
        public DateTime Updated_at { get; set;}

        public virtual ICollection<Carts> Carts { get; set; }
        public virtual ICollection<Categories> Categories { get; set; }
        public virtual ICollection<Orders> Orders { get; set; }
        public virtual ICollection<PostComments> PostComments { get; set; }
        public virtual ICollection<Posts> Posts { get; set; }
        public virtual ICollection<ProductReviews> ProductReviews { get; set; }
        public virtual ICollection<Wishlists> Wishlists { get; set; }
    }
}
