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
    public class PCMsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PCMsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: PCMs
        public async Task<IActionResult> Index()
        {
            return View(await _context.PCM.ToListAsync());
        }

        // GET: PCMs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pCM = await _context.PCM
                .FirstOrDefaultAsync(m => m.PCMID == id);
            if (pCM == null)
            {
                return NotFound();
            }

            return View(pCM);
        }

        // GET: PCMs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PCMs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("pcmFName,pcmLName,PCMID,Specialty")] PCM pCM)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pCM);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(pCM);
        }

        // GET: PCMs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pCM = await _context.PCM.FindAsync(id);
            if (pCM == null)
            {
                return NotFound();
            }
            return View(pCM);
        }

        // POST: PCMs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("pcmFName,pcmLName,PCMID,Specialty")] PCM pCM)
        {
            if (id != pCM.PCMID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pCM);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PCMExists(pCM.PCMID))
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
            return View(pCM);
        }

        // GET: PCMs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pCM = await _context.PCM
                .FirstOrDefaultAsync(m => m.PCMID == id);
            if (pCM == null)
            {
                return NotFound();
            }

            return View(pCM);
        }

        // POST: PCMs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var pCM = await _context.PCM.FindAsync(id);
            _context.PCM.Remove(pCM);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PCMExists(int id)
        {
            return _context.PCM.Any(e => e.PCMID == id);
        }
    }
}
