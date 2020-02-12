using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using KenkoApp.Data;
using KenkoApp.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;

namespace KenkoApp.Controllers
{
    [Authorize]
    public class HealthRecordsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<CustomIdentityUser> _userManager;

        public HealthRecordsController(ApplicationDbContext context, UserManager<CustomIdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: HealthRecords
        public async Task<IActionResult> Index()
        {
            var currentUser = await _userManager.GetUserAsync(User);
            if (currentUser == null) return Challenge();
           
            List<HealthRecord> model = _context
                .HealthRecords
                .Where(x => x.CustomIdentityUser.Id == currentUser.Id)
                .ToList();
            return View(model); 

            //return View(currentUser);
            //if the current user id matches the CustomerUserID associated with the healthrecord, show those records.
            //code from Michael
        }

        // GET: HealthRecords/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var healthRecord = await _context.HealthRecords
                .FirstOrDefaultAsync(m => m.HealthRecordID == id);

            if (healthRecord == null)
            {
                return NotFound();
            }

            return View(healthRecord);
        }

        public async Task<IActionResult> Display(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var record = await _context.HealthRecords
                .FirstOrDefaultAsync(m => m.HealthRecordID == id);
            if (record == null)
            {
                return NotFound();
            }

            return File(record.RecordData, record.FileType);
        }

        // GET: HealthRecords/Create
        public IActionResult Upload()
        {
            return View();
        }

        // POST: HealthRecords/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Upload([Bind("HealthRecordID,Title,RecordData,FileType,RecordNotes,")] HealthRecord healthRecord,List<IFormFile> fileInputData, string UserID) //removed CustomerUserId from Bind
        {
            //var CurrentUser = _context
            //   .CustomIdentityUsers
            //   .SingleOrDefault(x => x.Id == UserID);

            //healthRecord.CustomIdentityUser = CurrentUser;

            var user = await _userManager.GetUserAsync(User);
            healthRecord.CustomIdentityUser = user;



            //ViewBag.id = _userManager.GetUserId(HttpContext.User);  what I had before
            //var currentUser = await _userManager.GetUserAsync(User);
            //healthRecord.CustomIdentityUser = currentUser;


            if (ModelState.IsValid)
            {
                if (fileInputData.Count > 1)
                {
                    ModelState.AddModelError("RecordData", "Please upload only one file.");
                }
                var formFile = fileInputData[0]; //get first file
                var readStream = formFile.OpenReadStream(); //get stream of uploaded data
                healthRecord.RecordData = new byte[formFile.Length]; // create array on database photo object big enough to hold
                readStream.Read(healthRecord.RecordData, 0, (int)formFile.Length);//load data from stream into database phot object
                healthRecord.FileType = formFile.ContentType; //set database photo mime type based on type of file; png, jpg, etc.
                _context.Add(healthRecord); //add database photo object database gateway DbContext
                await _context.SaveChangesAsync(); //save changes to create insert statement
                return RedirectToAction(nameof(Index));
            }
            return View(healthRecord);
        }

        // GET: HealthRecords/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var healthRecord = await _context.HealthRecords.FindAsync(id);
            if (healthRecord == null)
            {
                return NotFound();
            }
            return View(healthRecord);
        }

        // POST: HealthRecords/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("HealthRecordID,Title,RecordData,MimeType")] HealthRecord healthRecord)
        {
            if (id != healthRecord.HealthRecordID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(healthRecord);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HealthRecordExists(healthRecord.HealthRecordID))
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
            return View(healthRecord);
        }

        // GET: HealthRecords/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var healthRecord = await _context.HealthRecords
                .FirstOrDefaultAsync(m => m.HealthRecordID == id);
            if (healthRecord == null)
            {
                return NotFound();
            }

            return View(healthRecord);
        }

        // POST: HealthRecords/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var healthRecord = await _context.HealthRecords.FindAsync(id);
            _context.HealthRecords.Remove(healthRecord);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HealthRecordExists(int id)
        {
            return _context.HealthRecords.Any(e => e.HealthRecordID == id);
        }
    }
}
