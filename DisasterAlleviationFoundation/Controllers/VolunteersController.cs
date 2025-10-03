using DisasterAlleviationFoundation.Data;
using DisasterAlleviationFoundation.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DisasterAlleviationFoundation.Controllers
{
    public class VolunteersController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly UserManager<IdentityUser> _userMgr;

        public VolunteersController(ApplicationDbContext db, UserManager<IdentityUser> userMgr)
        { _db = db; _userMgr = userMgr; }

        // Everyone can browse tasks
        public async Task<IActionResult> Tasks() =>
            View(await _db.VolunteerTasks.OrderBy(t => t.ScheduledAt).ToListAsync());

        // Admin/staff could create tasks (for marks you can keep it open)
        [Authorize] public IActionResult CreateTask() => View();

        [Authorize, HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateTask(VolunteerTask model)
        {
            if (!ModelState.IsValid) return View(model);
            _db.Add(model); await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Tasks));
        }

        // Sign up current user to a task
        [Authorize]
        public async Task<IActionResult> SignUp(int id)
        {
            var task = await _db.VolunteerTasks.FindAsync(id);
            if (task == null) return NotFound();

            var userId = _userMgr.GetUserId(User);
            var exists = await _db.VolunteerSignups
                .AnyAsync(s => s.VolunteerTaskId == id && s.UserId == userId);
            if (!exists)
            {
                _db.VolunteerSignups.Add(new VolunteerSignup { VolunteerTaskId = id, UserId = userId! });
                await _db.SaveChangesAsync();
            }
            return RedirectToAction(nameof(MySignups));
        }

        [Authorize]
        public async Task<IActionResult> MySignups()
        {
            var uid = _userMgr.GetUserId(User);
            var list = await _db.VolunteerSignups
                .Include(s => s.VolunteerTask)
                .Where(s => s.UserId == uid)
                .OrderByDescending(s => s.SignedAt)
                .ToListAsync();
            return View(list);
        }
    }
}
