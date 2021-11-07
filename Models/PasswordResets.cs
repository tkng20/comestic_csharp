using System;
using System.Collections.Generic;

namespace comestic.Models
{
    public partial class PasswordResets
    {
        public string Email { get; set; }
        public string Token { get; set; }
        public DateTime Created_at { get; set;}
    }
}
