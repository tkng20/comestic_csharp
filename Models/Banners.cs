using System;
using System.Collections.Generic;

namespace comestic.Models
{
    public partial class Banners
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public string Slug { get; set; }
        public string Photo { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
        public DateTime Created_at { get; set;}
        public DateTime Updated_at { get; set;}
    }
}
