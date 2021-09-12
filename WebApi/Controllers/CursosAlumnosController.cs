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
    public class CursosAlumnosController : ControllerBase
    {
        private readonly AppContext _context;

        public CursosAlumnosController(AppContext context)
        {
            _context = context;
        }

        // GET: api/CursosAlumnos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CursoAlumno>>> GetCursoAlumnos()
        {
            return await _context.CursoAlumnos.ToListAsync();
        }

        // GET: api/CursosAlumnos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CursoAlumno>> GetCursoAlumno(int id)
        {
            var cursoAlumno = await _context.CursoAlumnos.FindAsync(id);

            if (cursoAlumno == null)
            {
                return NotFound();
            }

            return cursoAlumno;
        }

        // PUT: api/CursosAlumnos/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCursoAlumno(int id, CursoAlumno cursoAlumno)
        {
            if (id != cursoAlumno.Id)
            {
                return BadRequest();
            }

            _context.Entry(cursoAlumno).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CursoAlumnoExists(id))
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

        // POST: api/CursosAlumnos
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CursoAlumno>> PostCursoAlumno(CursoAlumno cursoAlumno)
        {
            _context.CursoAlumnos.Add(cursoAlumno);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCursoAlumno", new { id = cursoAlumno.Id }, cursoAlumno);
        }

        // DELETE: api/CursosAlumnos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCursoAlumno(int id)
        {
            var cursoAlumno = await _context.CursoAlumnos.FindAsync(id);
            if (cursoAlumno == null)
            {
                return NotFound();
            }

            _context.CursoAlumnos.Remove(cursoAlumno);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CursoAlumnoExists(int id)
        {
            return _context.CursoAlumnos.Any(e => e.Id == id);
        }
    }
}
