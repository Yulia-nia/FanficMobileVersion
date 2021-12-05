using System;
using System.Collections.Generic;
using System.Text;

namespace FanficMobileVersion.Models
{
    public class Comment
    {
       //ublic Info info { get; set; }
       //public User user { get; set; }
        public int id { get; set; }
        public string text { get; set; }
        public string createdAt { get; set; }
        public DateTime updatedAt { get; set; }
        public int userId { get; set; }
        public string UserName { get; set; }
        public int fanficId { get; set; }
    }


    public class Info
    {
        public int id { get; set; }
        public string text { get; set; }
        public string createdAt { get; set; }
        public int fanficId { get; set; }
    }
   

}
