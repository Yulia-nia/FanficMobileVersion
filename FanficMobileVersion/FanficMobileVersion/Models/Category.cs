using System;
using System.Collections.Generic;
using System.Text;

namespace FanficMobileVersion.Models
{
    public class Category
    {
        public int id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public int countFanfics { get; set; }
        public DateTime createdAt { get; set; }
        public DateTime updatedAt { get; set; }
        public IEnumerable<Fanfic> fanfics { get; set; }

    }
}
