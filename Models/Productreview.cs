using System;
using System.Collections.Generic;

#nullable disable

namespace comestic_csharp.Models
{
    public partial class Productreview
    {
        public ulong Id { get; set; }
        public ulong? UserId { get; set; }
        public ulong? ProductId { get; set; }
        public sbyte Rating { get; set; }
        public string Review { get; set; }
        public string Status { get; set; }

        public virtual Product Product { get; set; }
        public virtual User User { get; set; }
    }
}
