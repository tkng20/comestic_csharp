using System;
using System.Collections.Generic;

namespace comestic.Models
{
    public partial class Notifications
    {
        public string Id { get; set; }
        public string Type { get; set; }
        public string NotifiableType { get; set; }
        public long NotifiableId { get; set; }
        public string Data { get; set; }
        public DateTime Created_at { get; set;}
        public DateTime Read_at {get; set;}
        public DateTime Updated_at { get; set;}
    }
}
