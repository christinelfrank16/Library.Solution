using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Library.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace Library.Controllers
{
    [Authorize]
    public class PatronController : Controller
    {
        private readonly LibraryContext _db;
        private readonly UserManager<ApplicationUser> _userManager;
        public PatronController(UserManager<ApplicationUser> userManager, LibraryContext db)
        {
            _userManager = userManager;
            _db = db;
        }
        public async Task<ActionResult> Details()
        {
            var userId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var currentUser = await _userManager.FindByIdAsync(userId);
            Patron thisPatron = _db.Patrons.FirstOrDefault(entry => entry.User.Id == currentUser.Id);
            Console.WriteLine(thisPatron == null);
            if(thisPatron != null)
            {
                return View(thisPatron);
            }
            else
            {
                return RedirectToAction("Create");
            }
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Create(Patron patron)
        {
            
            var userId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var currentUser = await _userManager.FindByIdAsync(userId);
            patron.User = currentUser;
            _db.Patrons.Add(patron);
            _db.SaveChanges();
            return RedirectToAction("Details");
        }
    }
}

