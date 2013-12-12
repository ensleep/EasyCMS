using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EasyCMS_Bll.Manage;
using EasyCMS_Dal;

namespace EasyCMS.Manage
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            BLL_Menu bll = new BLL_Menu();
            List<ES_Menu> list = bll.GetMenuByUserId(1);
        }
    }
}