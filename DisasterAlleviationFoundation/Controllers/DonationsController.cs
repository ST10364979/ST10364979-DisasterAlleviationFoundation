using DisasterAlleviationFoundation.Data;
using DisasterAlleviationFoundation.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DisasterAlleviationFoundation.Controllers
{
    public class DonationsController : Controller
    {
        private readonly ApplicationDbContext _db;
        public DonationsController(ApplicationDbContext db) { _db = db; }

        public async Task<IActionResult> Index() =>
            View(await _db.Donations.OrderByDescending(d => d.CreatedAt).ToListAsync());

        [Authorize] public IActionResult Create() => View();

        [Authorize, HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Donation model)
        {
            if (!ModelState.IsValid) return View(model);
            _db.Add(model); await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Details(int id)
        {
            var donation = await _db.Donations.FindAsync(id);
            if (donation == null) return NotFound();
            return View(donation);   
        }

    }
}
