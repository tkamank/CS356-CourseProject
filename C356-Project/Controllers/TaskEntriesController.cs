using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using C356_Project.Areas.Identity.Data;
using C356_Project.Models;
using System.Security.Claims;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;

namespace C356_Project.Controllers
{
    public class TaskEntriesController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly C356_AuthDbContext _context;

        public TaskEntriesController(C356_AuthDbContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: TaskEntries
        [Authorize]
        public async Task<IActionResult> Index()
        {
            var user = await _userManager.GetUserAsync(HttpContext.User);
            var userId = user.Id;
            return View(await _context.TaskEntry.Where(t => t.UserId == userId).ToListAsync());
        }

        // GET: TaskEntries/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var taskEntry = await _context.TaskEntry
                .FirstOrDefaultAsync(m => m.ID == id);
            if (taskEntry == null)
            {
                return NotFound();
            }

            return View(taskEntry);
        }

        // GET: TaskEntries/Create
        public IActionResult Create()
        {
            return View();
        }

   

        // POST: TaskEntries/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,userTask")] TaskEntry taskEntry)
        {
            var currentUserId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            if (ModelState.IsValid)
            {
                taskEntry.UserId = currentUserId;
                _context.Add(taskEntry);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(taskEntry);
        }

        // GET: TaskEntries/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var taskEntry = await _context.TaskEntry.FindAsync(id);
            if (taskEntry == null)
            {
                return NotFound();
            }
            return View(taskEntry);
        }

        // POST: TaskEntries/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,userTask")] TaskEntry taskEntry)
        {
            if (id != taskEntry.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(taskEntry);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TaskEntryExists(taskEntry.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(taskEntry);
        }

        // GET: TaskEntries/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var taskEntry = await _context.TaskEntry
                .FirstOrDefaultAsync(m => m.ID == id);
            if (taskEntry == null)
            {
                return NotFound();
            }

            return View(taskEntry);
        }

        // POST: TaskEntries/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var taskEntry = await _context.TaskEntry.FindAsync(id);
            _context.TaskEntry.Remove(taskEntry);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TaskEntryExists(int id)
        {
            return _context.TaskEntry.Any(e => e.ID == id);
        }
    }
}
