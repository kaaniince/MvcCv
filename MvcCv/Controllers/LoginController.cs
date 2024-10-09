using MvcCv.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MvcCv.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        // GET: Login

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(TblLogin p)
        {
            DbCvEntities2 db = new DbCvEntities2();
            var userInfo=db.TblLogin.FirstOrDefault(x => x.Nickname == p.Nickname && x.Password == p.Password);
            if (userInfo != null)
            {
                FormsAuthentication.SetAuthCookie(userInfo.Nickname, false); 
                Session["Nickname"] = userInfo.Nickname.ToString();
                return RedirectToAction("Index", "Experience");
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("Index", "Login");
        }
    }
}