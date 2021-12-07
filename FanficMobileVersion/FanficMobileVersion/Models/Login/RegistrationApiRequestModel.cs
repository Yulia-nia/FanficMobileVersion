using System;
using System.Collections.Generic;
using System.Text;

namespace FanficMobileVersion.Models.Login
{
    public class RegistrationApiRequestModel
    {
        public string username { get; set; }
        public string password { get; set; }
        public string email { get; set; }
    }
}
