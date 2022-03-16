using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net;
using System.Data.Entity;
using BookcaseManager.Models;

namespace BookcaseManager.Controllers
{
    public class BooksController : Controller
    {
        // GET: Books/Create
        [Authorize]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Books/Create
        [HttpPost]
        [Authorize]
        public ActionResult Create(Book book)
        {
            try
            {
                using (var context = new Entities())
                {
                    book.readBy = User.Identity.Name;
                    context.Books.Add(book);
                    context.SaveChanges();
                }

                return RedirectToAction("Home", "StaticPage");
            }
            catch
            {
                return View();
            }
        }

        // GET: Books/Edit/5
        [Authorize]
        public ActionResult Edit(int id)
        {
            using(var context = new Entities())
            {
                Book book = context.Books.FirstOrDefault(b => b.id == id);
                if (book == null || book.readBy != User.Identity.Name) return RedirectToAction("Home", "StaticPage"); //prevent edit unless book own to user and book is not null
                return View(book);
            }
        }

        // POST: Books/Edit/5
        [HttpPost]
        [Authorize]
        public ActionResult Edit(int id, Book book)
        {
            if (ModelState.IsValid)
            {
                try
                {

                    using (var context = new Entities())
                    {
                        Book bookSelected = context.Books.FirstOrDefault(b => b.id == id);
                        bookSelected.author = book.author;
                        bookSelected.title = book.title;
                        bookSelected.ISBN = book.ISBN;
                        bookSelected.rating = book.rating;
                        bookSelected.note = book.note;
                        context.SaveChanges();
                    }

                    return RedirectToAction("Home", "StaticPage");
                }
                catch
                {
                    return View();
                }
            }
            return View();
        }

        // GET: Books/Delete/5
        [Authorize]
        public ActionResult Delete(int id)
        {
            using (var context = new Entities())
            {
                Book book = context.Books.FirstOrDefault(b => b.id == id);
                if(book == null || book.readBy != User.Identity.Name) return RedirectToAction("Home", "StaticPage"); //prevent delete unless book own to user and book is not null
                return View(book);
            }
        }

        // POST: Books/Delete/5
        [HttpPost]
        [Authorize]
        public ActionResult Delete(Book bookParm)
        {
            try
            {
                using(var context = new Entities())
                {
                    var book = context.Books.SingleOrDefault(b => b.id == bookParm.id);
                    if(book.readBy == User.Identity.Name) //check if book own to user
                        context.Books.Remove(book);
                    context.SaveChanges();
                }
                return RedirectToAction("Home", "StaticPage");
            }
            catch
            {
                return View();
            }
        }
    }
}
