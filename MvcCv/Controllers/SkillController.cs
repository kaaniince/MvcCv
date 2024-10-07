using MvcCv.Models.Entity;
using MvcCv.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcCv.Controllers
{
    public class SkillController : Controller
    {
        // GET: Skill
        SkillRepository repo = new SkillRepository();

        public ActionResult Index()
        {
            var skill = repo.List();
            return View(skill);
        }
        [HttpGet]
        public ActionResult AddNewSkill()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddNewSkill(TblSkill p)
        {
            repo.TAdd(p);
            return RedirectToAction("Index");
        }

        public ActionResult DeleteSkill(int id)
        {
            var skill = repo.Find(x => x.ID == id);
            repo.TRemove(skill);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult GetSkill(int id)
        {
            var skill = repo.Find(x=>x.ID == id);
            return View(skill);

        }

        [HttpPost]
        public ActionResult GetSkill(TblSkill t)
        {
            var skill = repo.Find(x => x.ID == t.ID);
            skill.Skill = t.Skill;
            skill.Rate = t.Rate;
            repo.TUpdate(skill);
            return RedirectToAction("Index");
        }

    }
}