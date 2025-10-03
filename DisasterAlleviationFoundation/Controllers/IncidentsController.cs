using DisasterAlleviationFoundation.Data;
using DisasterAlleviationFoundation.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DisasterAlleviationFoundation.Controllers
{
    public class IncidentsController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly UserManager<IdentityUser> _userMgr;

        public IncidentsController(ApplicationDbContext db, UserManager<IdentityUser> userMgr)
        { _db = db; _userMgr = userMgr; }

        public async Task<IActionResult> Index() =>
            View(await _db.Incidents.OrderByDescending(i => i.CreatedAt).ToListAsync());

        [AllowAnonymous]
        public async Task<IActionResult> Details(int id)
            => View(await _db.Incidents.FindAsync(id) ?? (object)NotFound());

        [Authorize]
        public IActionResult Create() => View();

        [Authorize, HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Incident model)
        {
            if (!ModelState.IsValid) return View(model);
            model.ReporterUserId = _userMgr.GetUserId(User);
            model.CreatedAt = DateTime.UtcNow;
            _db.Add(model); await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        [Authorize]
        public async Task<IActionResult> Edit(int id)
            => View(await _db.Incidents.FindAsync(id) ?? (object)NotFound());

        [Authorize, HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Incident model)
        {
            if (id != model.Id) return BadRequest();
            if (!ModelState.IsValid) return View(model);
            _db.Update(model); await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Details), new { id = model.Id });
        }

        [Authorize]
        public async Task<IActionResult> Delete(int id)
            => View(await _db.Incidents.FindAsync(id) ?? (object)NotFound());

        [Authorize, HttpPost, ActionName("Delete"), ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var entity = await _db.Incidents.FindAsync(id);
            if (entity != null) { _db.Incidents.Remove(entity); await _db.SaveChangesAsync(); }
            return RedirectToAction(nameof(Index));
        }
    }
}
