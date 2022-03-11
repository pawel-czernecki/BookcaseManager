using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using BookcaseManager.Models;

namespace BookcaseManager.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account/Login
        public ActionResult Login()
        {
            return View();
        }

        //Post: Account/Login
        [HttpPost]
        public ActionResult Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                if (Membership.ValidateUser(model.Nickname, model.Password))
                {
                    FormsAuthentication.SetAuthCookie(model.Nickname, true);

                    return RedirectToAction("Home", "StaticPage");
                }
                else
                    ModelState.AddModelError("", "Niepoprawne dane uwierzytelniające.");
            }
            return View(model);
        }

        //GET: Account/Register
        public ActionResult Register()
        {
            return View();
        }

        //POST: Account/Register
        [HttpPost]
        public ActionResult Register(RegisterModel model)
        {
            if (ModelState.IsValid)
            {
                MembershipCreateStatus createStatus;
                Membership.CreateUser(model.Nickname, model.Password, model.Email, null, null, true, out createStatus);

                if(createStatus == MembershipCreateStatus.Success)
                {
                    FormsAuthentication.SetAuthCookie(model.Nickname, true);
                    return RedirectToAction("Home", "StaticPage");
                }
                else
                {
                    ModelState.AddModelError("", createStatus.ToString());
                }   
            }
            return View(model);
        }

        //GET: Account/Logout
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Home", "StaticPage");
        }
    }
}