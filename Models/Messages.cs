using System;
using System.Collections.Generic;

namespace comestic.Models
{
    public partial class Messages
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Subject { get; set; }
        public string Email { get; set; }
        public string Photo { get; set; }
        public string Phone { get; set; }
        public string Message { get; set; }
        public DateTime Created_at { get; set;}
        public DateTime Read_at {get; set;}
        public DateTime Updated_at { get; set;}
    }
}
