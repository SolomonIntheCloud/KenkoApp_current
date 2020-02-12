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
    public class CustomIdentityUsersController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<CustomIdentityUser> _userManager;
        public CustomIdentityUsersController(ApplicationDbContext context, UserManager<CustomIdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: CustomIdentityUsers
        public async Task<IActionResult> Index()
        {
            return View(await _context.Users.ToListAsync());
        }


        public async Task<IActionResult> Details() //view details of logged in user only
        {
            //ViewBag.id = _userManager.GetUserId(HttpContext.User);
            var currentUser = await _userManager.GetUserAsync(User);
            if (currentUser == null) return Challenge();
            return View(currentUser);
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
        [HttpGet]
        public async Task<IActionResult> Edit(string id)
        {
            //ViewBag.id = _userManager.GetUserId(HttpContext.User);

            //var currentUser = await _userManager.GetUserAsync(User);
            //if (currentUser == null) return Challenge();

            //return View(currentUser);

            if (id == null)
            {
                return NotFound();
            }

            var customIdentityUser = await _context.Users.FindAsync(id);
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
        public async Task<IActionResult> Edit(string id, [Bind("FirstName,LastName,DateofBirth,Gender,SocialSecurityNumber,Email,Phone,SecondaryPhone,Address,City,State,ZipCode,MaritalStatus,EmergencyContact,Relationship,InsuranceProvider,InsurancePolicyNumber")] CustomIdentityUser model)
        {
            //the ConcurrencyStamp was not correct. the update statement looks for the existing user's
            //id and ConcurrencyStamp in the where, ex...
            //
            //update user set name = @n where id = @id and @ConcurrencyStamp = @c
            //
            //this gets the current identity user
            var existingUser = _context.Users.SingleOrDefault(x => x.Id == id);
            //this correctc the damn concurrency stamp
            model.ConcurrencyStamp = existingUser.ConcurrencyStamp;
            //this needs to be updated to include all managed fields. 
            //don't include fields not to be edited like id or user name.
            existingUser.FirstName = model.FirstName;
            existingUser.LastName = model.LastName;
            existingUser.DateofBirth = model.DateofBirth;
            existingUser.Gender = model.Gender;
            existingUser.SocialSecurityNumber = model.SocialSecurityNumber;
            existingUser.PhoneNumber = model.PhoneNumber;
            existingUser.SecondaryPhone = model.SecondaryPhone;
            existingUser.Address = model.Address;
            existingUser.City = model.City;
            existingUser.State = model.State;
            existingUser.ZipCode = model.ZipCode;
            existingUser.MaritalStatus = model.MaritalStatus;
            existingUser.EmergencyContact = model.EmergencyContact;
            existingUser.Relationship = model.Relationship;
            existingUser.InsuranceProvider = model.InsuranceProvider;
            existingUser.InsurancePolicyNumber = existingUser.InsurancePolicyNumber;
            if (ModelState.IsValid)
            {
                try
                {
                    //the update statement was throwing an error because the entity was loaded by my new code 
                    //above. This HACK removed the entity so we can keep the same simpler code. 
                    //_context.Entry(existingUser).State = EntityState.Detached;
                    //_context.Update(customIdentityUser);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {

                    if (!CustomIdentityUserExists(model.Id))
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
            return View(model);
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