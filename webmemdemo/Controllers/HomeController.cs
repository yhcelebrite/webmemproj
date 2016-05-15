using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using webmemdemo.Models;

namespace webmemdemo.Controllers
{
    public class HomeController : BaseController
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
            return Content("Home/Index");
        }

        public ActionResult addUser()
        {
            userDbContext udc = new userDbContext();
            User user = new User();
            user.username = "rayu";
            user.passward = "123456";

            udc.User.Add(user);
            udc.SaveChanges();
            return Content("add User success!!!");
        }
    }
}
