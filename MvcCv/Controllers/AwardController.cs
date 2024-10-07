using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcCv.Models.Entity;
using MvcCv.Repository;

namespace MvcCv.Controllers
{
    public class AwardController : Controller
    {
        // GET: Award

        AwardRepository repo = new AwardRepository();
        public ActionResult Index()
        {
            var awards = repo.List();
            return View(awards);
        }

        [HttpGet]
        public ActionResult GetAward(int id)
        {
            var award = repo.Find(x => x.ID == id);
            return View(award);
        }

        [HttpPost]
        public ActionResult GetAward(TblAwards t)
        {
            var award = repo.Find(x => x.ID == t.ID);
            award.Description = t.Description;
            repo.TUpdate(award);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult AddAward()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddAward(TblAwards t)
        {
            repo.TAdd(t);
            return RedirectToAction("Index");
        }

        public ActionResult DeleteAward(int id)
        {
            TblAwards t = repo.Find(x => x.ID == id);
            repo.TRemove(t);
            return RedirectToAction("Index");
        }


    }
}