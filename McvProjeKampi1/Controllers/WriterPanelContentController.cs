﻿using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFreamwork;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace McvProjeKampi1.Controllers
{
    public class WriterPanelContentController : Controller
    {
        ContentManager cm = new ContentManager(new EfContentDal());
        Context c = new Context();
        // GET: WriterPanelContact
        public ActionResult MyContent(String p)
        {
            
            p = (string)Session["WriterMail"];
            var writeridinfo = c.Writers.Where(x => x.WriterMail == p).Select(y=>y.WriterID).FirstOrDefault();
            var contentvalues = cm.GetListByWriter(writeridinfo);
            return View(contentvalues);
        }
        [HttpGet]
        public ActionResult AddContent(int id)
        {
            ViewBag.d = id;
            return View();
        }
        [HttpPost]
        public ActionResult AddContent(Content p )
        {
            string mail = (string)Session["WriterMail"];
            var writeridinfo = c.Writers.Where(x => x.WriterMail == mail).Select(y => y.WriterID).FirstOrDefault();
            var contentvalues = cm.GetListByWriter(writeridinfo);
            p.ContentDate=DateTime.Parse( DateTime.Now.ToShortDateString());
            p.WriterID = writeridinfo;
            p.ContentStatus = true;
            cm.ContentAdd(p);
            return RedirectToAction("MyContent");
        }
        public ActionResult ToDoList()
        {
            return View();
        }
    }
}