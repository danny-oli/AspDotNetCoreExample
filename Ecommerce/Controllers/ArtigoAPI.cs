using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Domain;
using Repository;

namespace JornalOnline.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArtigoAPI : ControllerBase
    {
        private readonly Context _context;

        public ArtigoAPI(Context context)
        {
            _context = context;
        }

        // GET: api/ArtigoAPI
        [HttpGet]
        public IEnumerable<Artigo> GetArtigos()
        {
            return _context.Artigos;
        }

        // GET: api/ArtigoAPI/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetArtigo([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var artigo = await _context.Artigos.FindAsync(id);

            if (artigo == null)
            {
                return NotFound();
            }

            return Ok(artigo);
        }

        // PUT: api/ArtigoAPI/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutArtigo([FromRoute] int id, [FromBody] Artigo artigo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != artigo.IdArtigo)
            {
                return BadRequest();
            }

            _context.Entry(artigo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ArtigoExists(id))
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

        // POST: api/ArtigoAPI
        [HttpPost]
        public async Task<IActionResult> PostArtigo([FromBody] Artigo artigo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Artigos.Add(artigo);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetArtigo", new { id = artigo.IdArtigo }, artigo);
        }

        // DELETE: api/ArtigoAPI/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteArtigo([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var artigo = await _context.Artigos.FindAsync(id);
            if (artigo == null)
            {
                return NotFound();
            }

            _context.Artigos.Remove(artigo);
            await _context.SaveChangesAsync();

            return Ok(artigo);
        }

        private bool ArtigoExists(int id)
        {
            return _context.Artigos.Any(e => e.IdArtigo == id);
        }
    }
}