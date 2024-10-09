using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcCv.Models.Entity;
using MvcCv.Repository;

namespace MvcCv.Controllers
{
    [AllowAnonymous]
    public class AdminController : Controller
    {
        // GET: Admin
        LoginRepository repo = new LoginRepository();
        public ActionResult Index()
        {
            var liste = repo.List();
            return View(liste);
        }


        [HttpGet]
        public ActionResult AddAdmin()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddAdmin(TblLogin p)
        {
            repo.TAdd(p);
            return RedirectToAction("Index");

        }

        public ActionResult DeleteAdmin(int id)
        {
            TblLogin t = repo.Find(x => x.ID == id);
            repo.TRemove(t);
            return RedirectToAction("Index");

        }

        [HttpGet]
        public ActionResult GetAdmin(int id)
        {
            TblLogin t = repo.Find(x => x.ID == id);
            return View(t);

        }

        [HttpPost]
        public ActionResult GetAdmin(TblLogin p)
        {
            TblLogin t = repo.Find(x => x.ID == p.ID);
            t.Nickname = p.Nickname;
            t.Password = p.Password;
            repo.TUpdate(t);
            return RedirectToAction("Index");
        }
    }
}