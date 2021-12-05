using System;
using System.Collections.Generic;
using System.Text;

namespace FanficMobileVersion.Models.Login
{
    public class LoginApiResponseModel
    {   
        public string accessToken { get; set; }
        public string refreshToken { get; set; }

        public User user { get; set; }
        
    }
}
