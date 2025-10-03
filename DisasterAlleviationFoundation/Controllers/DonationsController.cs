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

        // Query runs in DB; ToListAsync materializes the results.
        public async Task<IActionResult> Index() =>
            View(await _db.Donations.OrderByDescending(d => d.CreatedAt).ToListAsync());

        // If validation attributes on the model fail, re-render the form with messages.
        [Authorize] public IActionResult Create() => View();

        [Authorize, HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Donation model)
        {
            if (!ModelState.IsValid) return View(model);

            // Add the donation and save in a single unit of work.
            _db.Add(model); await _db.SaveChangesAsync();

            // Back to the list page after success.
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Details(int id)
        {

            // Primary-key lookup; efficient and returns null if missing.
            var donation = await _db.Donations.FindAsync(id);
            if (donation == null) return NotFound();
            return View(donation);   
        }

    }
}
