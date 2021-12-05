using System;
using System.Collections.Generic;
using System.Text;

namespace FanficMobileVersion.Models
{
    public class FavoriteFan
    {
        public int id { get; set; }
        public Info1 info { get; set; }
        public User user { get; set; }
        public List<Tag> tags { get; set; }
    }

    public class Info1
    {
        public int id { get; set; }
        public string name { get; set; }
        public string shortDescription { get; set; }
        public int countLikes { get; set; }
        public int countComments { get; set; }
        public int countChapters { get; set; }
        public string createdAt { get; set; }
    }

}
