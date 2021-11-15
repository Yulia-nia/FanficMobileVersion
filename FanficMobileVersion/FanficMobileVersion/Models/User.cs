using System;
using System.Collections.Generic;
using System.Text;

namespace FanficMobileVersion.Models
{
    internal class User
    {
        public int id { get; set; }
        public string username { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        
        public string about { get; set; }
        public int isActivated { get; set; }
        public string activationLine { get; set; }  
        public int countFanfics { get; set; }
        public int visibilityLikedFanfics { get; set; }
        public DateTime? createdAt { get; set; }
        public DateTime updateAt { get; set; }
        public int visibilityFavoritesFanfics { get; set; }
        
        public IEnumerable<Like> likes { get; set; }
        public IEnumerable<Fanfic> favoritesFanfics { get; set; }
        public IEnumerable<Token> tokens { get; set; }
        public IEnumerable<Tag> tags { get; set; }
        public IEnumerable<Comment> comments { get; set; }

        //public IEnumerable<Role> roles { get; set; }

        //public int profileId { get; set; }  

    }
}
