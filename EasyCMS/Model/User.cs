using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EasyCMS.Model
{
    public class User
    {
        public int UserId{get;set;}
        public string UserName { get; set; }
        public string UserRole { get; set; }
        public List<UserMenu> listUserMenu { get; set; }
    }
}