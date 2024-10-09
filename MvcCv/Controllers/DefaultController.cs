using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcCv.Models.Entity;

namespace MvcCv.Controllers
{
    [AllowAnonymous]
    public class DefaultController : Controller
    {
        // GET: Default
        DbCvEntities2 db = new DbCvEntities2();
        public ActionResult Index()
        {
            var values = db.TblAbout.ToList();
            return View(values);
        }

        public PartialViewResult SocialMedia()
        {
            var socialMedia = db.TblSocialMedia.Where(x => x.State == true).ToList();
            return PartialView(socialMedia);
        }
        public PartialViewResult Experience()
        {
            var experiences = db.TblExperiences.ToList();
            return PartialView(experiences);
        }

        public PartialViewResult Education()
        {
            var education = db.TblEducation.ToList();
            return PartialView(education);
        }

        public PartialViewResult Skill()
        {
            var skill = db.TblSkill.ToList();
            return PartialView(skill);
        }
        public PartialViewResult Interest()
        {
            var interest = db.Tbl_Interests.ToList();
            return PartialView(interest);
        }

        public PartialViewResult Awards()
        {
            var awards = db.TblAwards.ToList();
            return PartialView(awards);
        }
        [HttpGet]
        public PartialViewResult Contract()
        {
            return PartialView();
        }
        [HttpPost]
        public PartialViewResult Contract(Tbl_Contract t)
        {
            db.Tbl_Contract.Add(t);
            db.SaveChanges();
            return PartialView();
        }
    }
}