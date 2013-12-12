using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EasyCMS_Dal;
using EasyCMS_DAl.Manage;

namespace EasyCMS_Bll.Manage
{
    public class BLL_Menu
    {
        public List<ES_Menu> GetMenuByUserId(int id)
        {
            DAL_Menu dal = new DAL_Menu();
            return dal.GetMenuByUserId(id);
        }
    }
}
