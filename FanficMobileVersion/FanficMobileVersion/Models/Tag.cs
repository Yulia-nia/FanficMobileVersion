using System;
using System.Collections.Generic;
using System.Text;

namespace FanficMobileVersion.Models
{
    internal class Tag
    {
        public int id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public DateTime createdAt { get; set; }
        public DateTime updatedAt { get; set; }
        public int userId { get; set; }
        
        // ---------------------------------
        public int fanficId { get; set; }
        public IEnumerable<Fanfic> fanfics { get; set; }
    }
}
