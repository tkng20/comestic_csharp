using System;
using System.Collections.Generic;

#nullable disable

namespace comestic_csharp.Models
{
    public partial class Postcomment
    {
        public ulong Id { get; set; }
        public ulong? UserId { get; set; }
        public ulong? PostId { get; set; }
        public string Comments { get; set; }
        public string Status { get; set; }
        public ulong? ParentId { get; set; }

        public virtual Post Post { get; set; }
        public virtual User User { get; set; }
    }
}
