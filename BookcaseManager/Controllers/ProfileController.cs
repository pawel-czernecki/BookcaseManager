using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using BookcaseManager.Models;

namespace BookcaseManager.Controllers
{
    public class ProfileController : Controller
    {
        // GET: Profile/List
        // PROVIDE: List of all users
        public ActionResult List()
        {
            var users = Membership.GetAllUsers();
            ViewBag.OnlineCount = Membership.GetNumberOfUsersOnline();
            ViewBag.UsersCount = users.Count;
            var ProfileList = new List<KeyValuePair<MembershipUser, int>>(); //create list for users with number of read books
            using(var context = new Entities())
            {
                foreach(MembershipUser user in users) //assing number of books for users
                {
                    var bookCount = context.Books.Where(b => b.readBy == user.UserName).Count();
                    ProfileList.Add(new KeyValuePair<MembershipUser, int>(user, bookCount));
                }
            }
            
            return View(ProfileList);
        }
    }
}