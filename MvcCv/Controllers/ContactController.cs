﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcCv.Models.Entity;
using MvcCv.Repository;

namespace MvcCv.Controllers
{
    public class ContactController : Controller
    {
        // GET: Contact

        ContactRepository repo = new ContactRepository();
        public ActionResult Index()
        {
            var degerler = repo.List();
            return View(degerler);
        }
    }
}