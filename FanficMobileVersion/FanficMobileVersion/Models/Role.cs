using System;
using System.Collections.Generic;
using System.Text;

namespace FanficMobileVersion.Models
{
    public class Role
    {
        public int id { get; set; }
        public string Name { get; set; }
        public DateTime createdAt { get; set; }
        public DateTime updatedAt { get; set; }
        // public int userId { get; set; }
        // public IEnumerable<User> users {get; set;}

    }
}
