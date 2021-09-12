using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApi.DB.Context;
using WebApi.DB.Models;
using AppContext = WebApi.DB.Context.AppContext;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CursoInstructoresController : ControllerBase
    {
        private readonly AppContext _context;

        public CursoInstructoresController(AppContext context)
        {
            _context = context;
        }

        // GET: api/CursoInstructores
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CursoInstructore>>> GetCursoInstructores()
        {
            return await _context.CursoInstructores.ToListAsync();
        }

        // GET: api/CursoInstructores/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CursoInstructore>> GetCursoInstructore(int id)
        {
            var cursoInstructore = await _context.CursoInstructores.FindAsync(id);

            if (cursoInstructore == null)
            {
                return NotFound();
            }

            return cursoInstructore;
        }

        // PUT: api/CursoInstructores/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCursoInstructore(int id, CursoInstructore cursoInstructore)
        {
            if (id != cursoInstructore.Id)
            {
                return BadRequest();
            }

            _context.Entry(cursoInstructore).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CursoInstructoreExists(id))
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

        // POST: api/CursoInstructores
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CursoInstructore>> PostCursoInstructore(CursoInstructore cursoInstructore)
        {
            _context.CursoInstructores.Add(cursoInstructore);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCursoInstructore", new { id = cursoInstructore.Id }, cursoInstructore);
        }

        // DELETE: api/CursoInstructores/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCursoInstructore(int id)
        {
            var cursoInstructore = await _context.CursoInstructores.FindAsync(id);
            if (cursoInstructore == null)
            {
                return NotFound();
            }

            _context.CursoInstructores.Remove(cursoInstructore);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CursoInstructoreExists(int id)
        {
            return _context.CursoInstructores.Any(e => e.Id == id);
        }
    }
}
