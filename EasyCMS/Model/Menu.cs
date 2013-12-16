using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EasyCMS.Model
{
    public class UserMenu
    {
        public List<ChildMenu> ChildMenu
        {
            get;
            set;
        }
        public string MenuName { get; set; }
        public int? id { get; set; }
    }
    public class ChildMenu
    {
        public int id { get; set; }
        public string MenuName { get; set; }
        public string MenuUrl { get; set; }
        public int? FatherId { get; set; }

    }
}