using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.SessionState;
using System.Data;
using System.Xml;
using System.IO;
using EasyCMS.Model;

namespace EasyCMS.Ajax
{
    /// <summary>
    /// UserMenu 的摘要说明
    /// </summary>
    public class AjaxUserMenu : IHttpHandler, IReadOnlySessionState
    {
        public bool IsReusable
        {
            get
            {
                return false;
            }
        }

        public void ProcessRequest(HttpContext context)
        {
            if (context.Session["user"] == null)
            {
                context.Response.Write("非法的请求！");
            }
            else 
            { 
                context.Response.ContentType = "text/plain";
                if (context.Request["action"] != null)
                {
                    string command = context.Request["action"].ToString();
                    System.Reflection.MethodInfo method = this.GetType().GetMethod(command);
                    if (method != null)
                    {
                        method.Invoke(this, new object[] { context });
                    }
                }
            }
        }
        //以下为ajax执行action制定的方法
        public void GetUserMenu(HttpContext context)
        {
            List<UserMenu> list=(context.Session["user"] as User).listUserMenu;
            User u = context.Session["user"] as User;
            string jsonstr = "";
            foreach(var um in list)
            {
                if (jsonstr == "")
                {
                    jsonstr += "[{\"Text\":\"" + um.MenuName + "\",\"ChildMenu\": [";
                    string childstr = "";
                    foreach (var m in um.ChildMenu)
                    {
                        if (childstr == "")
                        {
                            childstr += "{\"Text\": \"" + m.MenuName + "\",\"Url\":\"" + m.MenuUrl + "\"}";
                        }
                        else
                        {
                            childstr += ",{\"Text\": \"" + m.MenuName + "\",\"Url\":\"" + m.MenuUrl + "\"}";
                        }
                    }
                    jsonstr += childstr;
                    jsonstr += "]}";

                }
                else
                {
                    jsonstr += ",{\"Text\":\"" + um.MenuName + "\",\"ChildMenu\": [";
                    string childstr = "";
                    foreach (var m in um.ChildMenu)
                    {
                        if (childstr == "")
                        {
                            childstr += "{\"Text\": \"" + m.MenuName + "\",\"Url\":\"" + m.MenuUrl + "\"}";
                        }
                        else
                        {
                            childstr += ",{\"Text\": \"" + m.MenuName + "\",\"Ur\"l:\"" + m.MenuUrl + "\"}";
                        }
                    }
                    jsonstr += childstr;
                    jsonstr += "]}";

                }

            }
            jsonstr += "]";
            context.Response.Write(jsonstr);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        public void GetServerTime(HttpContext context)
        {
            string ServerTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            context.Response.Write(ServerTime);
        }

    }
}