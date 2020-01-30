using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using KenkoApp.Data;
using KenkoApp.Models;

namespace KenkoApp.Controllers
{
    public class CustomIdentityUsersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CustomIdentityUsersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: CustomIdentityUsers
        public async Task<IActionResult> Index()
        {
            return View(await _context.Users.ToListAsync());
        }

        // GET: CustomIdentityUsers/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customIdentityUser = await _context.Users
                .FirstOrDefaultAsync(m => m.Id == id);
            if (customIdentityUser == null)
            {
                return NotFound();
            }

            return View(customIdentityUser);
        }

        // GET: CustomIdentityUsers/Register
        public IActionResult Register()
        {
            
            return View();
        }

        // POST: CustomIdentityUsers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FirstName,LastName,DateofBirth,Gender,SocialSecurityNumber,Email,Phone,SecondaryPhone,Address,City,State,ZipCode,MaritalStatus,EmergencyContact,Relationship,InsuranceProvider,InsurancePolicyNumber")] CustomIdentityUser customIdentityUser)
        {
            if (ModelState.IsValid)
            {
                _context.Add(customIdentityUser);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(customIdentityUser);
        }

        // GET: CustomIdentityUsers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customIdentityUser = await _context.CustomIdentityUsers.FindAsync(id); //Ana changed Users to CustomIdentityUsers, idk if tha'ts correct
            if (customIdentityUser == null)
            {
                return NotFound();
            }
            return View(customIdentityUser);
        }

        // POST: CustomIdentityUsers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Id,FirstName,LastName,DateofBirth,Gender,SocialSecurityNumber,Email,Phone,SecondaryPhone,Address,City,State,ZipCode,MaritalStatus,EmergencyContact,Relationship,InsuranceProvider,InsurancePolicyNumber")] CustomIdentityUser customIdentityUser)
        {
            if (id != customIdentityUser.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(customIdentityUser);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CustomIdentityUserExists(customIdentityUser.Id))
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
            return View(customIdentityUser);
        }

        // GET: CustomIdentityUsers/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customIdentityUser = await _context.Users
                .FirstOrDefaultAsync(m => m.Id == id);
            if (customIdentityUser == null)
            {
                return NotFound();
            }

            return View(customIdentityUser);
        }

        // POST: CustomIdentityUsers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var customIdentityUser = await _context.Users.FindAsync(id);
            _context.Users.Remove(customIdentityUser);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CustomIdentityUserExists(string id)
        {
            return _context.Users.Any(e => e.Id == id);
        }
    }
}
