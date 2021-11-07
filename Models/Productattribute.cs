using System;
using System.Collections.Generic;

#nullable disable

namespace comestic_csharp.Models
{
    public partial class Productattribute
    {
        public ulong Id { get; set; }
        public string Color { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public ulong? ProductId { get; set; }

        public virtual Product Product { get; set; }
    }
}
