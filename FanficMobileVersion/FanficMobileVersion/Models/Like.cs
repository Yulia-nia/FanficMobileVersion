using System;
using System.Collections.Generic;
using System.Text;

namespace FanficMobileVersion.Models
{
    internal class Like
    {
        public int id { get; set; }
        public DateTime createdAt { get; set; }
        public DateTime updatedAt { get; set; }
        public int userId { get; set; }
        public int fanficId { get; set; }
        public int chapterId { get; set; }  
    }
}
