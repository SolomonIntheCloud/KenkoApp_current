using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using KenkoApp.Data;
using KenkoApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

namespace KenkoApp.Controllers
{
    [Authorize]
    public class CareAdministratorsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<CustomIdentityUser> _userManager;
        public CareAdministratorsController(ApplicationDbContext context, UserManager<CustomIdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: CareAdministrators
        public async Task<IActionResult> Index()
        {
            return View(await _context.CareAdministrator.ToListAsync());
        }

        // GET: CareAdministrators/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var careAdministrator = await _context.CareAdministrator
                .FirstOrDefaultAsync(m => m.CareAdministratorId == id);
            if (careAdministrator == null)
            {
                return NotFound();
            }

            return View(careAdministrator);
        }

        // GET: CareAdministrators/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CareAdministrators/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CareAdministratorId,AdminEmail,AdminPassword")] CareAdministrator careAdministrator)
        {
            if (ModelState.IsValid)
            {
                _context.Add(careAdministrator);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(careAdministrator);
        }

        // GET: CareAdministrators/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var careAdministrator = await _context.CareAdministrator.FindAsync(id);
            if (careAdministrator == null)
            {
                return NotFound();
            }
            return View(careAdministrator);
        }

        // POST: CareAdministrators/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CareAdministratorId,AdminEmail,AdminPassword")] CareAdministrator careAdministrator)
        {
            if (id != careAdministrator.CareAdministratorId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(careAdministrator);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CareAdministratorExists(careAdministrator.CareAdministratorId))
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
            return View(careAdministrator);
        }

        // GET: CareAdministrators/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var careAdministrator = await _context.CareAdministrator
                .FirstOrDefaultAsync(m => m.CareAdministratorId == id);
            if (careAdministrator == null)
            {
                return NotFound();
            }

            return View(careAdministrator);
        }

        // POST: CareAdministrators/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var careAdministrator = await _context.CareAdministrator.FindAsync(id);
            _context.CareAdministrator.Remove(careAdministrator);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CareAdministratorExists(int id)
        {
            return _context.CareAdministrator.Any(e => e.CareAdministratorId == id);
        }
    }
}
