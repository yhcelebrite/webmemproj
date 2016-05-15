using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using webmemdemo.Models;

namespace webmemdemo.Controllers
{
    public class BaseController : Controller
    {
        public User LoginUser{set;get;}
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);
            //从客户端的cookie中获取SessionId
            string sessionId = Request["SessionId"] != null ? Request["SessionId"].ToString() : "";
            if (string.IsNullOrEmpty(sessionId))
            {
                //跳转到登录页面
                Response.Redirect("/Login/Index");
                return;
            }
            //从mem中获取SessionId对应的value 即user信息
            var user = MemcacheHelper.Get(sessionId);
            //value存在
            if(user != null)
            {
                //强转为User 保存到LoginUser中
                LoginUser = user as User;
            }
            else
            {
                //跳转到登录页面
                Response.Redirect("/Login/Index");
                return;
            }
        }
    }
}
