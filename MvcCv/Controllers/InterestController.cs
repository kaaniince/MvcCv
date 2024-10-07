using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcCv.Models.Entity;
using MvcCv.Repository;


namespace MvcCv.Controllers
{
    public class InterestController : Controller
    {
        // GET: Interest
        InterestRepository repo = new InterestRepository();

        [HttpGet]
        public ActionResult Index()
        {
            var interest = repo.List();

            return View(interest);
        }

        [HttpPost]
        public ActionResult Index(Tbl_Interests p)
        {
            var deger = repo.Find(x => x.ID == p.ID);
            deger.Description1 = p.Description1;
            deger.Description2 = p.Description2;
            repo.TUpdate(deger);
            return RedirectToAction("Index");
        }


    }
}