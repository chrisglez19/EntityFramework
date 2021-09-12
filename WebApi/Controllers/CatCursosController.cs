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
    public class CatCursosController : ControllerBase
    {
        private readonly AppContext _context;

        public CatCursosController(AppContext context)
        {
            _context = context;
        }

        // GET: api/CatCursos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CatCurso>>> GetCatCursos()
        {
            return await _context.CatCursos.ToListAsync();
        }

        // GET: api/CatCursos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CatCurso>> GetCatCurso(short id)
        {
            var catCurso = await _context.CatCursos.FindAsync(id);

            if (catCurso == null)
            {
                return NotFound();
            }

            return catCurso;
        }

        // PUT: api/CatCursos/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCatCurso(short id, CatCurso catCurso)
        {
            if (id != catCurso.Id)
            {
                return BadRequest();
            }

            _context.Entry(catCurso).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CatCursoExists(id))
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

        // POST: api/CatCursos
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CatCurso>> PostCatCurso(CatCurso catCurso)
        {
            _context.CatCursos.Add(catCurso);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCatCurso", new { id = catCurso.Id }, catCurso);
        }

        // DELETE: api/CatCursos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCatCurso(short id)
        {
            var catCurso = await _context.CatCursos.FindAsync(id);
            if (catCurso == null)
            {
                return NotFound();
            }

            _context.CatCursos.Remove(catCurso);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CatCursoExists(short id)
        {
            return _context.CatCursos.Any(e => e.Id == id);
        }
    }
}
