using System;
using System.Collections.Generic;
using System.Text;

namespace FanficMobileVersion.Models
{
    internal class Token
    {
        public int id { get; set; }
        public string refreshToken { get; set; }
        public DateTime createdAt { get; set; }
        public DateTime updatedAt { get; set; } 
        public int userId { get; set; }

    }
}
