using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using ES_DAL;
namespace ES_BLL
{
    public class Class1
    {
        public static DataTable GetAllUser()
        {
            return SQLHelper.Query("select * from ES_User").Tables[0];
        }
    }
}
