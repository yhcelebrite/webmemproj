using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using webmemdemo.Models;

namespace webmemdemo.Controllers
{
    public class LoginController : Controller
    {
        userDbContext udc = new userDbContext();

        public ActionResult Index()
        {
            return View();
        }


        public ActionResult login() 
        {
            string _username =Request["username"].ToString();
            string _passward =Request["passward"].ToString();
            var user = udc.User.Where(n => n.username.Equals(_username) && n.passward.Equals(_passward)).FirstOrDefault();
            if (user != null)
            {
                //登陆成功，构造sessionId （模拟session）到mem 有效期30mins
                Guid sessionId = Guid.NewGuid();
                MemcacheHelper.Set(sessionId.ToString(), user, DateTime.Now.AddMinutes(30));
                Response.Cookies.Add(new HttpCookie("sessionId",sessionId.ToString()));

                return RedirectToAction("Index", "Home");
            }
            else
            {
                return Content("用户名或密码错误！！！");
            }
        }
    }
}
