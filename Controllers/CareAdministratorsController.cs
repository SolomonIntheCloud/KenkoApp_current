using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using KenkoApp.Data;
using KenkoApp.Models;

namespace KenkoApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CareAdministratorsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public CareAdministratorsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/CareAdministrators
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CareAdministrator>>> GetCareAdministrator()
        {
            return await _context.CareAdministrator.ToListAsync();
        }

        // GET: api/CareAdministrators/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CareAdministrator>> GetCareAdministrator(int id)
        {
            var careAdministrator = await _context.CareAdministrator.FindAsync(id);

            if (careAdministrator == null)
            {
                return NotFound();
            }

            return careAdministrator;
        }

        // PUT: api/CareAdministrators/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCareAdministrator(int id, CareAdministrator careAdministrator)
        {
            if (id != careAdministrator.CareAdministratorId)
            {
                return BadRequest();
            }

            _context.Entry(careAdministrator).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CareAdministratorExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/CareAdministrators
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<CareAdministrator>> PostCareAdministrator(CareAdministrator careAdministrator)
        {
            _context.CareAdministrator.Add(careAdministrator);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCareAdministrator", new { id = careAdministrator.CareAdministratorId }, careAdministrator);
        }

        // DELETE: api/CareAdministrators/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<CareAdministrator>> DeleteCareAdministrator(int id)
        {
            var careAdministrator = await _context.CareAdministrator.FindAsync(id);
            if (careAdministrator == null)
            {
                return NotFound();
            }

            _context.CareAdministrator.Remove(careAdministrator);
            await _context.SaveChangesAsync();

            return careAdministrator;
        }

        private bool CareAdministratorExists(int id)
        {
            return _context.CareAdministrator.Any(e => e.CareAdministratorId == id);
        }
    }
}
