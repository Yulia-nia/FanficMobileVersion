using System;
using System.Collections.Generic;
using System.Text;

namespace FanficMobileVersion.Models
{
    internal class Fanfic
    {
        public int id { get; set; }
        public string name { get; set; }
        public string shortDescription { get; set; }
        public int countLikes { get; set; }
        public int countComments { get; set; }
        public int countChapters { get; set; }
        public DateTime createdAt { get; set; }
        public DateTime updatedAt { get; set; }
        
        public int userId { get; set; }
        public int categoryId { get; set; }

        public IEnumerable<Comment> comments { get; set; }
        public IEnumerable<Tag> tags { get; set; }
        public IEnumerable<Chapter> chapters { get; set; }

        //public IEnumerable<Favorites> favorites { get; set; }
        public int? tagId { get; set; }
    }
}
