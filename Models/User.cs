using System;
using System.Collections.Generic;

#nullable disable

namespace comestic_csharp.Models
{
    public partial class User
    {
        public User()
        {
            Carts = new HashSet<Cart>();
            Categories = new HashSet<Category>();
            Orders = new HashSet<Order>();
            Postcomments = new HashSet<Postcomment>();
            Posts = new HashSet<Post>();
            Productreviews = new HashSet<Productreview>();
            Wishlists = new HashSet<Wishlist>();
        }

        public ulong Id { get; set; }
        public string Fullname { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Photo { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string Role { get; set; }
        public string Status { get; set; }

        public virtual ICollection<Cart> Carts { get; set; }
        public virtual ICollection<Category> Categories { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
        public virtual ICollection<Postcomment> Postcomments { get; set; }
        public virtual ICollection<Post> Posts { get; set; }
        public virtual ICollection<Productreview> Productreviews { get; set; }
        public virtual ICollection<Wishlist> Wishlists { get; set; }
    }
}
