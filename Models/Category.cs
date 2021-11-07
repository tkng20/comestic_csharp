﻿using System;
using System.Collections.Generic;

#nullable disable

namespace comestic_csharp.Models
{
    public partial class Category
    {
        public Category()
        {
            InverseParent = new HashSet<Category>();
            ProductCats = new HashSet<Product>();
            ProductChildCats = new HashSet<Product>();
        }

        public ulong Id { get; set; }
        public string Title { get; set; }
        public string Slug { get; set; }
        public string Summary { get; set; }
        public string Photo { get; set; }
        public bool? IsParent { get; set; }
        public ulong? ParentId { get; set; }
        public ulong? AddedBy { get; set; }
        public string Status { get; set; }

        public virtual User AddedByNavigation { get; set; }
        public virtual Category Parent { get; set; }
        public virtual ICollection<Category> InverseParent { get; set; }
        public virtual ICollection<Product> ProductCats { get; set; }
        public virtual ICollection<Product> ProductChildCats { get; set; }
    }
}
