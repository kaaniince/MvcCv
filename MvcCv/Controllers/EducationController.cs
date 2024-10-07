using MvcCv.Models.Entity;
using MvcCv.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcCv.Controllers
{
    public class EducationController : Controller
    {
        EducationRepository repo = new EducationRepository();
        // GET: Education
        public ActionResult Index()
        {
            var education = repo.List();
            return View(education);
        }

        [HttpGet]
        public ActionResult AddEducation()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddEducation(TblEducation p)
        {
            if (!ModelState.IsValid)
            {
                return View("AddEducation");
            }
            repo.TAdd(p);
            return RedirectToAction("Index");
        }


        public ActionResult DeleteEducation(int id)
        {
            var education = repo.Find(x=>x.ID == id);
            repo.TRemove(education);
            return RedirectToAction("Index");

        }

        [HttpGet]
        public ActionResult GetEducation(int id)
        {
            var education = repo.Find(x => x.ID == id);
            return View(education);
        }

        [HttpPost]
        public ActionResult GetEducation(TblEducation t)
        {
            if (!ModelState.IsValid)
            {
                return View("GetEducation");
            }
            var education = repo.Find(x => x.ID == t.ID);
            education.Header = t.Header;
            education.SubTitle1 = t.SubTitle1;
            education.SubTitle2 = t.SubTitle2;
            education.GNO = t.GNO;
            education.Date = t.Date;
            repo.TUpdate(education);
            return RedirectToAction("Index");
        }
    }
}