using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq;
using System;
using Library.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using System.Security.Claims;
using Library.ViewModels;

namespace Library.Controllers
{
    [Authorize]
    public class TransactionController : Controller
    {
        private readonly LibraryContext _db;
        private readonly UserManager<ApplicationUser> _userManager;

        public TransactionController(UserManager<ApplicationUser> userManager, LibraryContext db)
        {
            _userManager = userManager;
            _db = db;
        }

        public async Task<ActionResult> Index()
        {

            var userId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var currentUser = await _userManager.FindByIdAsync(userId);
            var userTransactions = _db.Transactions.Include(transaction => transaction.Checkouts).Where(entry => entry.User.Id == currentUser.Id).ToList();
            var transactionIds = userTransactions.Select(txn => txn.TransactionId);
            var userCheckouts = _db.Checkouts.Include(checkout => checkout.Copy).Where(checkout => transactionIds.Contains(checkout.TransactionId)).ToList();
            var copies = _db.Copies.Include(copy => copy.Book).ToList();
            TransactionIndexViewModel model = new TransactionIndexViewModel(){Transactions = userTransactions, Books = copies, Checkouts = userCheckouts};
            // var userCopies = userTransactions.Select()
            return View(model);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Create (List<int> BookCopy)
        {
            Transaction transaction = new Transaction();
            var userId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var currentUser = await _userManager.FindByIdAsync(userId);
            var patron = _db.Patrons.FirstOrDefault(entry => entry.User.Id == currentUser.Id);
            
            transaction.User = currentUser;
            _db.Transactions.Add(transaction);
            _db.SaveChanges();
            Transaction dbTransaction = _db.Transactions.LastOrDefault();
            List<Checkout> checkouts = new List<Checkout>();
            foreach(int copyId in BookCopy)
            {
                Checkout checkout = new Checkout(){PatronId = patron.PatronId, CopyId = copyId, TransactionId = dbTransaction.TransactionId, CheckoutDate = DateTime.Today, DueDate = DateTime.Today.AddDays(14)};
                _db.Checkouts.Add(checkout);
                checkouts.Add(checkout);
            }
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult AddToBookBag(List<int> InBookBag)
        {
            InBookBag.ForEach(b => Console.WriteLine("in book bag: " + b));
            
            for(var i=0; i<InBookBag.Count; i++)
            {
                Copy thisCopy = _db.Copies.Include(book => book.Book).FirstOrDefault(copy => copy.CopyId == InBookBag[i] && copy.CheckoutId == 0);
                Checkout.BookBag.Add(thisCopy);
            }
            Checkout.BookBag = Checkout.BookBag.Distinct().ToList();
            return RedirectToAction("Create");
        }
    }
}