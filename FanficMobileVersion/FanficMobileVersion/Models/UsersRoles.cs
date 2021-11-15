using System;
using System.Collections.Generic;
using System.Text;

namespace FanficMobileVersion.Models
{
    internal class UsersRoles
    {
        public int userId { get; set; }
        public int roleId { get; set; }
        public DateTime createdAt { get; set; }
        public DateTime updatedAt { get; set; }

    }
}
