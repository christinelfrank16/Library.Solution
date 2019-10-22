using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq;
using Library.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using System.Security.Claims;

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
            var userTransactions = _db.Transactions.Where(entry => entry.User.Id == currentUser.Id);
            return View(userTransactions);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Create (Transaction transaction)
        {
            var userId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var currentUser = await _userManager.FindByIdAsync(userId);
            transaction.User = currentUser;
            _db.Transactions.Add(transaction);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}