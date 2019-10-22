using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq;
using Library.Models;

namespace Library.Controllers
{
    public class AuthorController : Controller
    {
        private readonly LibraryContext _db;
        public AuthorController(LibraryContext db)
        {
            _db = db;
        }
        public ActionResult Index()
        {
            List<Author> model = _db.Authors.ToList();
            return View(model);
        }

        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Author author)
        {
            _db.Authors.Add(author);
            _db.SaveChanges();
            return RedirectToAction("Index", "Home");
        }

        public ActionResult Details(int id)
        {
           List<AuthorBook> model = _db.AuthorBooks.Where(author => author.AuthorId == id).ToList();
            return View(model);
        }

        public ActionResult Edit(int id)
        {
            Author model = _db.Authors.FirstOrDefault(author => author.AuthorId == id);
            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(Author author)
        {
            _db.Entry(author).State = EntityState.Modified;
            _db.SaveChanges();
            return RedirectToAction("Index", "Home");
        }

        public ActionResult Delete(int id)
        {
           Author model = _db.Authors.FirstOrDefault(author => author.AuthorId == id);
            return View(model);
        }

        public ActionResult DeleteBook(int joinId)
        {
            var joinEntry = _db.AuthorBooks.FirstOrDefault(entry => entry.AuthorBookId == joinId);
            _db.AuthorBooks.Remove(joinEntry);
            _db.SaveChanges();
            return RedirectToAction("Index", "Home");
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Author thisAuthor = _db.Authors.FirstOrDefault(author => author.AuthorId == id);
            _db.Authors.Remove(thisAuthor);
            _db.SaveChanges();
            return RedirectToAction("Index", "Home");
        }

    }
}