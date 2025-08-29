using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Portfolio_Website.CS
{
    public class User
    {
        public string Username { get; set; }
        public string Role { get; set; } // "Guest", "Member", "Admin"
    }
}