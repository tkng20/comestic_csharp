using System;
using System.Collections.Generic;

#nullable disable

namespace comestic_csharp.Models
{
    public partial class Banner
    {
        public ulong Id { get; set; }
        public string Title { get; set; }
        public string Slug { get; set; }
        public string Photo { get; set; }
        public string Description { get; set; }
        public string Condition { get; set; }
    }
}
