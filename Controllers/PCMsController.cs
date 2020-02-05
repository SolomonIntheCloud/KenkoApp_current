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
    public class PCMsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public PCMsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/PCMs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PCM>>> GetPCM()
        {
            return await _context.PCM.ToListAsync();
        }

        // GET: api/PCMs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PCM>> GetPCM(int id)
        {
            var pCM = await _context.PCM.FindAsync(id);

            if (pCM == null)
            {
                return NotFound();
            }

            return pCM;
        }

        // PUT: api/PCMs/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPCM(int id, PCM pCM)
        {
            if (id != pCM.PCMID)
            {
                return BadRequest();
            }

            _context.Entry(pCM).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PCMExists(id))
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

        // POST: api/PCMs
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<PCM>> PostPCM(PCM pCM)
        {
            _context.PCM.Add(pCM);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPCM", new { id = pCM.PCMID }, pCM);
        }

        // DELETE: api/PCMs/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<PCM>> DeletePCM(int id)
        {
            var pCM = await _context.PCM.FindAsync(id);
            if (pCM == null)
            {
                return NotFound();
            }

            _context.PCM.Remove(pCM);
            await _context.SaveChangesAsync();

            return pCM;
        }

        private bool PCMExists(int id)
        {
            return _context.PCM.Any(e => e.PCMID == id);
        }
    }
}
