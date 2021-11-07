using System;
using System.Collections.Generic;

namespace comestic.Models
{
    public partial class Categories
    {
        public Categories()
        {
            InverseParent = new HashSet<Categories>();
            ProductsCat = new HashSet<Products>();
            ProductsChildCat = new HashSet<Products>();
        }

        public long Id { get; set; }
        public string Title { get; set; }
        public string Slug { get; set; }
        public string Summary { get; set; }
        public string Photo { get; set; }
        public bool? IsParent { get; set; }
        public long? ParentId { get; set; }
        public long? AddedBy { get; set; }
        public string Status { get; set; }
        public DateTime Created_at { get; set;}
        public DateTime Updated_at { get; set;}

        public virtual Users AddedByNavigation { get; set; }
        public virtual Categories Parent { get; set; }
        public virtual ICollection<Categories> InverseParent { get; set; }
        public virtual ICollection<Products> ProductsCat { get; set; }
        public virtual ICollection<Products> ProductsChildCat { get; set; }
    }
}
