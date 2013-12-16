using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EasyCMS.Model;
using EasyCMS.Entity;
using EasyCMS;

namespace EasyCMS
{
    public partial class BasePage : System.Web.UI.Page
    {
        public User CurUser
        {
            get { return Session["user"] as User; }
            set { Session["user"] = value; }
        }

        public BasePage()
        {
            this.Load += new EventHandler(BasePage_Load);
        }
        protected void BasePage_Load(object sender, EventArgs e)
        {

            EasyCMSEntities db = new EasyCMSEntities();
            if (Session["user"] == null)
            {
                var query = from u in db.ES_User
                            join r in db.ES_Role on u.RoleId equals r.Id
                            where u.Id == 1
                            select new User { UserId = u.Id, UserName = u.LogName, UserRole = r.RoleName};
                List<User> listUser = query.ToList();
                if(listUser.Count>0){
                    this.CurUser=listUser[0];

                }

            }
            else
            {

            }

            List<ES_Menu> list = new List<ES_Menu>();
            List<UserMenu> listUserMenu = new List<UserMenu>();
            List<ChildMenu> listChildMenu = new List<ChildMenu>();
            foreach(var m in db.ES_Menu.Where(m=>m.FatherId==null).ToList())
            {
                listUserMenu.Add(new UserMenu { MenuName = m.MenuName, id = m.Id, ChildMenu = null });
            }
            foreach(var m in db.ES_Menu.Where(m=>m.FatherId!=null).ToList())
            {
                listChildMenu.Add(new ChildMenu { MenuName = m.MenuName, MenuUrl = m.MenuUrl, id = m.Id, FatherId = m.FatherId });

            }
            //listChildMenu = db.ES_Menu.Where(m => m.FatherId != null).ToList();
            if (listUserMenu.Count > 0)
            {
                foreach (var um in listUserMenu)
                {
                    um.ChildMenu = listChildMenu.Where(m => m.FatherId == um.id).ToList();
                }

            }
            User uu = Session["user"] as User;
            uu.listUserMenu = listUserMenu.Where(m=>m.ChildMenu.Count!=0).ToList();
            Session["user"]=uu;
        }
    }
}