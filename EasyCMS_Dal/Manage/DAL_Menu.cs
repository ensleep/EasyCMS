using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EasyCMS_Dal;

namespace EasyCMS_DAl.Manage
{
    public class DAL_Menu
    {
        public List<ES_Menu> GetMenuByUserId(int id)
        {
            EasyCMSEntities en=new EasyCMSEntities();
            List<ES_Menu> list = new List<ES_Menu>();
            var query = from menu in en.ES_Menu
                        from role in en.ES_Role
                        from user in en.ES_User
                        from user_role in en.ES_Menu_Role
                        where menu.Id == user_role.MenuId && role.Id == user_role.RoleId && user.RoleId == role.Id
                        select (menu);
            list = query.ToList();
            return list;
        }
    }
}
