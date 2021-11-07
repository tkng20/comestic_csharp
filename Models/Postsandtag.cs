using System;
using System.Collections.Generic;

#nullable disable

namespace comestic_csharp.Models
{
    public partial class Postsandtag
    {
        public ulong Id { get; set; }
        public ulong? PostId { get; set; }
        public ulong? TagId { get; set; }

        public virtual Post Post { get; set; }
        public virtual Posttag Tag { get; set; }
    }
}
