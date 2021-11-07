using System;
using System.Collections.Generic;

#nullable disable

namespace comestic_csharp.Models
{
    public partial class Notification
    {
        public Guid Id { get; set; }
        public string Type { get; set; }
        public string NotifiableType { get; set; }
        public ulong NotifiableId { get; set; }
        public string Data { get; set; }
        public DateTime? ReadAt { get; set; }
    }
}
