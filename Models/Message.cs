﻿using System;
using System.Collections.Generic;

#nullable disable

namespace comestic_csharp.Models
{
    public partial class Message
    {
        public ulong Id { get; set; }
        public string Name { get; set; }
        public string Subject { get; set; }
        public string Email { get; set; }
        public string Photo { get; set; }
        public string Phone { get; set; }
        public string Message1 { get; set; }
        public DateTime? ReadAt { get; set; }
    }
}
