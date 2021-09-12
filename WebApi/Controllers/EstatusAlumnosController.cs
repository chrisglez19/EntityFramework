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
    public class EstatusAlumnosController : ControllerBase
    {
        private readonly AppContext _context;

        public EstatusAlumnosController(AppContext context)
        {
            _context = context;
        }

        // GET: api/EstatusAlumnos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EstatusAlumno>>> GetEstatusAlumnos()
        {
            return await _context.EstatusAlumnos.ToListAsync();
        }

        // GET: api/EstatusAlumnos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EstatusAlumno>> GetEstatusAlumno(short id)
        {
            var estatusAlumno = await _context.EstatusAlumnos.FindAsync(id);

            if (estatusAlumno == null)
            {
                return NotFound();
            }

            return estatusAlumno;
        }

        // PUT: api/EstatusAlumnos/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEstatusAlumno(short id, EstatusAlumno estatusAlumno)
        {
            if (id != estatusAlumno.Id)
            {
                return BadRequest();
            }

            _context.Entry(estatusAlumno).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EstatusAlumnoExists(id))
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

        // POST: api/EstatusAlumnos
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<EstatusAlumno>> PostEstatusAlumno(EstatusAlumno estatusAlumno)
        {
            _context.EstatusAlumnos.Add(estatusAlumno);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (EstatusAlumnoExists(estatusAlumno.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetEstatusAlumno", new { id = estatusAlumno.Id }, estatusAlumno);
        }

        // DELETE: api/EstatusAlumnos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEstatusAlumno(short id)
        {
            var estatusAlumno = await _context.EstatusAlumnos.FindAsync(id);
            if (estatusAlumno == null)
            {
                return NotFound();
            }

            _context.EstatusAlumnos.Remove(estatusAlumno);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EstatusAlumnoExists(short id)
        {
            return _context.EstatusAlumnos.Any(e => e.Id == id);
        }
    }
}
