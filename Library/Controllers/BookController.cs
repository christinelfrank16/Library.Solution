using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq;
using Library.Models;
using Library.ViewModels;

namespace Library.Controllers
{
    public class BookController : Controller
    {
        private readonly LibraryContext _db;
        public BookController(LibraryContext db)
        {
            _db = db;
        }
        public ActionResult Index()
        {
            List<Book> books = _db.Books.Include(book => book.Authors).ThenInclude(entry => entry.Author).ToList();
            List<int> bookIds = books.Select(book => book.BookId).ToList();
            List<Copy> copies = _db.Copies.Where(copy => bookIds.Contains(copy.BookId) ).ToList();
            ViewBag.BookBag = Checkout.BookBag;
            BookIndexViewModel model = new BookIndexViewModel() {Books = books, Copies = copies };

            return View(model);
        }

        public ActionResult Create()
        {
            ViewBag.AuthorId = new SelectList(_db.Authors.ToList(), "AuthorId", "WholeName");
            return View();
        }

        [HttpPost]
        public ActionResult Create(Book book, int AuthorId)
        {
            _db.Books.Add(book);
            _db.AuthorBooks.Add(new AuthorBook() { AuthorId = AuthorId, BookId = book.BookId });
            _db.Copies.Add(new Copy() { BookId = book.BookId });
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Details(int id)
        {
            Book thisBook = _db.Books.Include(book => book.Authors).ThenInclude(entry => entry.Author).FirstOrDefault(book => book.BookId == id);
            List<Author> authors = thisBook.Authors.Select(entry => entry.Author).ToList();
            BookDetailsViewModel model = new BookDetailsViewModel() { Book = thisBook, Authors = authors };
            return View(model);
        }

        public ActionResult Edit(int id)
        {
            Book model = _db.Books.FirstOrDefault(book => book.BookId == id);
            ViewBag.AuthorId = new SelectList(_db.Authors.ToList(), "AuthorId", "WholeName");
            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(Book book)
        {
            _db.Entry(book).State = EntityState.Modified;
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        // public ActionResult Delete(int id)
        // {
        //     Book model = _db.Books.FirstOrDefault(book => book.BookId == id);
        //     return View(model);
        // }

        [HttpPost]
        public ActionResult DeleteAuthor(int joinId)
        {
            var joinEntry = _db.AuthorBooks.FirstOrDefault(entry => entry.AuthorBookId == joinId);
            _db.AuthorBooks.Remove(joinEntry);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            Book thisBook = _db.Books.FirstOrDefault(book => book.BookId == id);
            _db.Books.Remove(thisBook);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult AddAuthor(int id)
        {
            Book model = _db.Books.Include(book => book.Authors).ThenInclude(entry => entry.Author).FirstOrDefault(book => book.BookId == id);
            List<int> bookAuthorIds = model.Authors.Select(a => a.AuthorId).ToList();
             ViewBag.AuthorId = new SelectList(_db.Authors
             .Where(author => 
                !bookAuthorIds.Contains(author.AuthorId)).ToList(), 
             "AuthorId", "WholeName");
            return View(model);
        }
        [HttpPost]
        public ActionResult AddAuthor(int BookId, int AuthorId)
        {
            _db.AuthorBooks.Add(new AuthorBook(){AuthorId = AuthorId, BookId = BookId});
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
