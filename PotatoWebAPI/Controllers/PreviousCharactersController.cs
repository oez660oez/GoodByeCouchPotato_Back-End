using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PotatoWebAPI.DTO;
using PotatoWebAPI.Models;

namespace PotatoWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PreviousCharactersController : ControllerBase
    {
        private readonly GoodbyepotatoContext _context;

        public PreviousCharactersController(GoodbyepotatoContext context)
        {
            _context = context;
        }

        // GET: api/PreviousCharacters
        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<Character>>> GetCharacters()
        //{
        //    return await _context.Characters.ToListAsync();
        //}

        // GET: api/PreviousCharacters/5
        //[HttpGet("{id}")]
        //public async Task<ActionResult<Character>> GetCharacter(int id)
        //{
        //    var character = await _context.Characters.FindAsync(id);

        //    if (character == null)
        //    {
        //        return NotFound();
        //    }

        //    return character;
        //}



        // GET: api/PreviousCharacters/{account}
        [HttpGet("{account}")]
        public async Task<IActionResult> GetPreviousCharactersAllData(string account)
        {
            // Step 1: 通過 account 查詢角色
            var characters = await _context.Characters
                .Where(c => c.Account == account)
                .ToListAsync();

            if (!characters.Any())
            {
                return NotFound("No characters found for this account");
            }

            // 取得所有角色的 ID
            var characterIds = characters.Select(c => c.CId).ToList();

            // Step 2: 使用角色的 ID 列表查詢角色配件
            var accessories = await _context.CharacterAccessories
                .Where(a => characterIds.Contains(a.CId))
                .ToListAsync();

            // Step 3: 將查詢結果合併並返回 DTO
            var previousCharactersDTOs = characters.Select(character => new PreviousCharactersDTO
            {
                CId = character.CId,
                Name = character.Name,
                Level = character.Level,
                Weight = character.Weight,
                Height = character.Height,
                LivingStatus = character.LivingStatus,
                Coins = character.Coins,
                MoveInDate = character.MoveInDate.HasValue ? character.MoveInDate.Value.ToString("yyyy-M-d") : "2001-8-13",
                MoveOutDate = character.MoveOutDate.HasValue ? character.MoveOutDate.Value.ToString("yyyy-M-d") : "2001-8-13",
                Head = accessories.FirstOrDefault(a => a.CId == character.CId)?.Head ?? 0,
                Upper = accessories.FirstOrDefault(a => a.CId == character.CId)?.Upper ?? 0,
                Lower = accessories.FirstOrDefault(a => a.CId == character.CId)?.Lower ?? 0
            }).ToList();

            return Ok(previousCharactersDTOs);
        }




        // PUT: api/PreviousCharacters/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutCharacter(int id, Character character)
        //{
        //    if (id != character.CId)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(character).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!CharacterExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return NoContent();
        //}

        // POST: api/PreviousCharacters
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPost]
        //public async Task<ActionResult<Character>> PostCharacter(Character character)
        //{
        //    _context.Characters.Add(character);
        //    await _context.SaveChangesAsync();

        //    return CreatedAtAction("GetCharacter", new { id = character.CId }, character);
        //}

        // DELETE: api/PreviousCharacters/5
        //[HttpDelete("{id}")]
        //public async Task<IActionResult> DeleteCharacter(int id)
        //{
        //    var character = await _context.Characters.FindAsync(id);
        //    if (character == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.Characters.Remove(character);
        //    await _context.SaveChangesAsync();

        //    return NoContent();
        //}

        //private bool CharacterExists(int id)
        //{
        //    return _context.Characters.Any(e => e.CId == id);
        //}
    }
}
