using System;
using System.Collections.Generic;

#nullable disable

namespace comestic_csharp.Models
{
    public partial class Setting
    {
        public ulong Id { get; set; }
        public string Description { get; set; }
        public string ShortDes { get; set; }
        public string Logo { get; set; }
        public string Photo { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
    }
}
