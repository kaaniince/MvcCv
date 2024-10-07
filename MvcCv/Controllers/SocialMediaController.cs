using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcCv.Models.Entity;
using MvcCv.Repository;
namespace MvcCv.Controllers
{
    public class SocialMediaController : Controller
    {

        SocialMediaRepository repo = new SocialMediaRepository();

        // GET: SocialMedia
        public ActionResult Index()
        {
            var socialMedia = repo.List();
            return View(socialMedia);
        }

        [HttpGet]
        public ActionResult AddSocialMedia()
        {
            return View();
        }


        [HttpPost]
        public ActionResult AddSocialMedia(TblSocialMedia t)
        {
            repo.TAdd(t);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult GetSocialMedia(int p)
        {
            var socialMedia = repo.Find(x => x.ID == p);
            return View(socialMedia);
        }

        [HttpPost]
        public ActionResult GetSocialMedia(TblSocialMedia p)
        {
            var socialMedia = repo.Find(x => x.ID == p.ID);
            socialMedia.Name = p.Name;
            socialMedia.State = true;
            socialMedia.Link = p.Link;
            socialMedia.Icon = p.Icon; 
            repo.TUpdate(socialMedia);
            return RedirectToAction("Index");
        }

        public ActionResult DeleteSocialMedia(int id)
        {
            TblSocialMedia t = repo.Find(x => x.ID == id);
            t.State = false;
            repo.TUpdate(t);
            return RedirectToAction("Index");
        }
    }
}