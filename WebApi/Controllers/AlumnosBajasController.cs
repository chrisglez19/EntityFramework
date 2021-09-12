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
    public class AlumnosBajasController : ControllerBase
    {
        private readonly AppContext _context;

        public AlumnosBajasController(AppContext context)
        {
            _context = context;
        }

        // GET: api/AlumnosBajas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AlumnosBaja>>> GetAlumnosBajas()
        {
            return await _context.AlumnosBajas.ToListAsync();
        }

        // GET: api/AlumnosBajas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AlumnosBaja>> GetAlumnosBaja(int id)
        {
            var alumnosBaja = await _context.AlumnosBajas.FindAsync(id);

            if (alumnosBaja == null)
            {
                return NotFound();
            }

            return alumnosBaja;
        }

        // PUT: api/AlumnosBajas/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAlumnosBaja(int id, AlumnosBaja alumnosBaja)
        {
            if (id != alumnosBaja.Id)
            {
                return BadRequest();
            }

            _context.Entry(alumnosBaja).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AlumnosBajaExists(id))
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

        // POST: api/AlumnosBajas
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<AlumnosBaja>> PostAlumnosBaja(AlumnosBaja alumnosBaja)
        {
            _context.AlumnosBajas.Add(alumnosBaja);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAlumnosBaja", new { id = alumnosBaja.Id }, alumnosBaja);
        }

        // DELETE: api/AlumnosBajas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAlumnosBaja(int id)
        {
            var alumnosBaja = await _context.AlumnosBajas.FindAsync(id);
            if (alumnosBaja == null)
            {
                return NotFound();
            }

            _context.AlumnosBajas.Remove(alumnosBaja);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AlumnosBajaExists(int id)
        {
            return _context.AlumnosBajas.Any(e => e.Id == id);
        }
    }
}
