using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

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
            return View();
        }
    }
}