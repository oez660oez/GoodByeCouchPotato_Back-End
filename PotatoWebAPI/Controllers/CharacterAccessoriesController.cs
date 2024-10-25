using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PotatoWebAPI.Models;

namespace PotatoWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CharacterAccessoriesController : ControllerBase
    {
        private readonly GoodbyepotatoContext _context;

        public CharacterAccessoriesController(GoodbyepotatoContext context)
        {
            _context = context;
        }

        // GET: api/CharacterAccessories
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CharacterAccessorie>>> GetCharacterAccessories()
        {
            return await _context.CharacterAccessories.ToListAsync();
        }

        // GET: api/CharacterAccessories/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CharacterAccessorie>> GetCharacterAccessorie(int id)
        {
            var characterAccessorie = await _context.CharacterAccessories.FindAsync(id);

            if (characterAccessorie == null)
            {
                return NotFound();
            }

            return characterAccessorie;
        }

        // PUT: api/CharacterAccessories/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCharacterAccessorie(int id, CharacterAccessorie characterAccessorie)
        {
            if (id != characterAccessorie.CId)
            {
                return BadRequest();
            }

            _context.Entry(characterAccessorie).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CharacterAccessorieExists(id))
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

        // POST: api/CharacterAccessories
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CharacterAccessorie>> PostCharacterAccessorie(CharacterAccessorie characterAccessorie)
        {
            _context.CharacterAccessories.Add(characterAccessorie);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (CharacterAccessorieExists(characterAccessorie.CId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetCharacterAccessorie", new { id = characterAccessorie.CId }, characterAccessorie);
        }

        // DELETE: api/CharacterAccessories/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCharacterAccessorie(int id)
        {
            var characterAccessorie = await _context.CharacterAccessories.FindAsync(id);
            if (characterAccessorie == null)
            {
                return NotFound();
            }

            _context.CharacterAccessories.Remove(characterAccessorie);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CharacterAccessorieExists(int id)
        {
            return _context.CharacterAccessories.Any(e => e.CId == id);
        }
    }
}
