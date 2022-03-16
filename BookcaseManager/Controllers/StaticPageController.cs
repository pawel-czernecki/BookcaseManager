using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BookcaseManager.Models;

namespace BookcaseManager.Controllers
{
    public class StaticPageController : Controller
    {
        //<summary>
        //Provides a static pages
        //</summary>

        // GET: StaticPage
        public ActionResult Home()
        {
            using(var context = new Entities())
            {
                ViewBag.BookCount = context.Books.Count();
            }
            return View();
        }
    }
}