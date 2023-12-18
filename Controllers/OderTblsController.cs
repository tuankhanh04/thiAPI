using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Model;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OderTblsController : ControllerBase
    {
        private readonly OderTblDBcontext _context;

        public OderTblsController(OderTblDBcontext context)
        {
            _context = context;
        }

        // GET: api/OderTbls
        [HttpGet]
        public async Task<ActionResult<IEnumerable<OderTbl>>> GetOrders()
        {
          if (_context.Orders == null)
          {
              return NotFound();
          }
            return await _context.Orders.ToListAsync();
        }

        // GET: api/OderTbls/5
        [HttpGet("{id}")]
        public async Task<ActionResult<OderTbl>> GetOderTbl(int id)
        {
          if (_context.Orders == null)
          {
              return NotFound();
          }
            var oderTbl = await _context.Orders.FindAsync(id);

            if (oderTbl == null)
            {
                return NotFound();
            }

            return oderTbl;
        }

        // PUT: api/OderTbls/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOderTbl(int id, OderTbl oderTbl)
        {
            if (id != oderTbl.ItemCode)
            {
                return BadRequest();
            }

            _context.Entry(oderTbl).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OderTblExists(id))
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

        // POST: api/OderTbls
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<OderTbl>> PostOderTbl(OderTbl oderTbl)
        {
          if (_context.Orders == null)
          {
              return Problem("Entity set 'OderTblDBcontext.Orders'  is null.");
          }
            _context.Orders.Add(oderTbl);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetOderTbl", new { id = oderTbl.ItemCode }, oderTbl);
        }

        // DELETE: api/OderTbls/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOderTbl(int id)
        {
            if (_context.Orders == null)
            {
                return NotFound();
            }
            var oderTbl = await _context.Orders.FindAsync(id);
            if (oderTbl == null)
            {
                return NotFound();
            }

            _context.Orders.Remove(oderTbl);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool OderTblExists(int id)
        {
            return (_context.Orders?.Any(e => e.ItemCode == id)).GetValueOrDefault();
        }
    }
}
