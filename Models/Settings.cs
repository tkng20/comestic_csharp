using System;
using System.Collections.Generic;

namespace comestic.Models
{
    public partial class Settings
    {
        public long Id { get; set; }
        public string Description { get; set; }
        public string ShortDes { get; set; }
        public string Logo { get; set; }
        public string Photo { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public DateTime Created_at { get; set;}
        public DateTime Updated_at { get; set;}
    }
}
