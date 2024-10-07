using MvcCv.Models.Entity;
using MvcCv.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcCv.Controllers
{
    public class AboutController : Controller
    {
        // GET: About

        AboutRepository repo = new AboutRepository();
        [HttpGet]

        public ActionResult Index()
        {
            var about = repo.List();

            return View(about);
        }

        [HttpPost]
        public ActionResult Index(TblAbout p)
        {
            var deger = repo.Find(x => x.ID == 1);
            deger.Name = p.Name;
            deger.Surname = p.Surname;
            deger.PhoneNumber = p.PhoneNumber;
            deger.Mail = p.Mail;
            deger.Description = p.Description;

            repo.TUpdate(deger);
            return RedirectToAction("Index");
        }

    }
}