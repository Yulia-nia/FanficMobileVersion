using System;
using System.Collections.Generic;
using System.Text;

namespace FanficMobileVersion.Models
{
    public class Chapter
    {
        public int id { get; set; }
        public string name { get; set; }
        public string text { get; set; }
        public DateTime createdAt { get; set; }
        public DateTime updatedAt { get; set; }
        public int fanficId { get; set; }
        // public IEnumerable<Like> likes { get; set; }
    }
}
