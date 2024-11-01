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
    public class ReportController : ControllerBase
    {
        private readonly GoodbyepotatoContext _context;

        public ReportController(GoodbyepotatoContext context)
        {
            _context = context;
        }

        // POST: api/Report
        [HttpPost("sleep")]
        public async Task<ActionResult<IEnumerable<SleepRecordDTO>>> GetSleepRecords([FromBody]SearchdayDTO SearchdayDTO)
        {
            var result = await _context.DailyHealthRecords
               .Where(f => f.CId == SearchdayDTO.CId)
               .Where(f => f.HrecordDate >= SearchdayDTO.StartDate && f.HrecordDate <= SearchdayDTO.EndDate)
               .Select(f => new SleepRecordDTO
               {
                   HrecordDate = f.HrecordDate,
                   Sleep = f.Sleep ,
               })
              .ToListAsync();

            return Ok(result);
        }

        // POST: api/Report
        [HttpPost("water")]
        public async Task<ActionResult<IEnumerable<WaterRecordDTO>>> GetWaterRecords([FromBody] SearchdayDTO SearchdayDTO)
        {
            var result = await _context.DailyHealthRecords
               .Where(f => f.CId == SearchdayDTO.CId)
               .Where(f => f.HrecordDate >= SearchdayDTO.StartDate && f.HrecordDate <= SearchdayDTO.EndDate)
               .Select(f => new WaterRecordDTO
               {
                   HrecordDate = f.HrecordDate,
                   water = f.Water,
               })
              .ToListAsync();

            return Ok(result);
        }


        [HttpPost("step")]
        public async Task<ActionResult<IEnumerable<StepRecordDTO>>> GetStepRecords([FromBody] SearchdayDTO SearchdayDTO)
        {
            var result = await _context.DailyHealthRecords
               .Where(f => f.CId == SearchdayDTO.CId)
               .Where(f => f.HrecordDate >= SearchdayDTO.StartDate && f.HrecordDate <= SearchdayDTO.EndDate)
               .Select(f => new StepRecordDTO
               {
                   HrecordDate = f.HrecordDate,
                   step = f.Steps,
               })
              .ToListAsync();

            return Ok(result);
        }

        [HttpPost("mood")]
        public async Task<ActionResult<IEnumerable<MoodRecordDTO>>> GetMoodRecords([FromBody] SearchdayDTO SearchdayDTO)
        {
            var result = await _context.DailyHealthRecords
               .Where(f => f.CId == SearchdayDTO.CId)
               .Where(f => f.HrecordDate >= SearchdayDTO.StartDate && f.HrecordDate <= SearchdayDTO.EndDate)
               .Select(f => new MoodRecordDTO
               {
                   HrecordDate = f.HrecordDate,
                   mood = f.Mood,
               })
              .ToListAsync();

            return Ok(result);
        }

        [HttpPost("weight")]
        public async Task<ActionResult<IEnumerable<weightRecordDTO>>> GetweightRecords([FromBody] SearchdayDTO SearchdayDTO)
        {
            var result = await _context.WeightRecords
               .Where(f => f.CId == SearchdayDTO.CId)
               .Where(f => f.WRecordDate >= SearchdayDTO.StartDate && f.WRecordDate <= SearchdayDTO.EndDate)
               .Select(f => new weightRecordDTO
               {
                   HrecordDate = f.WRecordDate,
                   weight = f.Weight,
               })
              .ToListAsync();

            return Ok(result);
        }

        [HttpPost("eating")]
        public async Task<ActionResult<IEnumerable<eatRecordDTO>>> GeteatingRecords([FromBody] SearchdayDTO SearchdayDTO)
        {
            var result = await _context.DailyHealthRecords
               .Where(f => f.CId == SearchdayDTO.CId)
               .Where(f => f.HrecordDate >= SearchdayDTO.StartDate && f.HrecordDate <= SearchdayDTO.EndDate)
               .Select(f => new eatRecordDTO
               {
                   HrecordDate = f.HrecordDate,
                   good = f.Vegetables,
                   bad =f.Snacks 
               })
              .ToListAsync();

            return Ok(result);
        }

        [HttpPost("weekly")]
        public async Task<ActionResult<IEnumerable<weeklyRecordDTO>>> GetweeklyRecords([FromBody] SearchdayDTO SearchdayDTO)
        {
            var result = await _context.WeeklyHealthRecords
               .Where(f => f.CId == SearchdayDTO.CId)
               .Where(f => f.WrecordDate >= SearchdayDTO.StartDate && f.WrecordDate <= SearchdayDTO.EndDate)
               .Select(f => new weeklyRecordDTO
               {
                   HrecordDate = f.WrecordDate,
                   sport = f.Exercise,
                   cleaning = f.Cleaning
               })
              .ToListAsync();

            return Ok(result);
        }


        //    // GET: api/Report/5
        //    [HttpGet("{id}")]
        //    public async Task<ActionResult<DailyTaskRecord>> GetDailyTaskRecord(int id)
        //    {
        //        var dailyTaskRecord = await _context.DailyTaskRecords.FindAsync(id);

        //        if (dailyTaskRecord == null)
        //        {
        //            return NotFound();
        //        }

        //        return dailyTaskRecord;
        //    }

        //    // PUT: api/Report/5
        //    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //    [HttpPut("{id}")]
        //    public async Task<IActionResult> PutDailyTaskRecord(int id, DailyTaskRecord dailyTaskRecord)
        //    {
        //        if (id != dailyTaskRecord.CId)
        //        {
        //            return BadRequest();
        //        }

        //        _context.Entry(dailyTaskRecord).State = EntityState.Modified;

        //        try
        //        {
        //            await _context.SaveChangesAsync();
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!DailyTaskRecordExists(id))
        //            {
        //                return NotFound();
        //            }
        //            else
        //            {
        //                throw;
        //            }
        //        }

        //        return NoContent();
        //    }

        //    // POST: api/Report
        //    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //    [HttpPost]
        //    public async Task<ActionResult<DailyTaskRecord>> PostDailyTaskRecord(DailyTaskRecord dailyTaskRecord)
        //    {
        //        _context.DailyTaskRecords.Add(dailyTaskRecord);
        //        try
        //        {
        //            await _context.SaveChangesAsync();
        //        }
        //        catch (DbUpdateException)
        //        {
        //            if (DailyTaskRecordExists(dailyTaskRecord.CId))
        //            {
        //                return Conflict();
        //            }
        //            else
        //            {
        //                throw;
        //            }
        //        }

        //        return CreatedAtAction("GetDailyTaskRecord", new { id = dailyTaskRecord.CId }, dailyTaskRecord);
        //    }

        //    // DELETE: api/Report/5
        //    [HttpDelete("{id}")]
        //    public async Task<IActionResult> DeleteDailyTaskRecord(int id)
        //    {
        //        var dailyTaskRecord = await _context.DailyTaskRecords.FindAsync(id);
        //        if (dailyTaskRecord == null)
        //        {
        //            return NotFound();
        //        }

        //        _context.DailyTaskRecords.Remove(dailyTaskRecord);
        //        await _context.SaveChangesAsync();

        //        return NoContent();
        //    }

        //    private bool DailyTaskRecordExists(int id)
        //    {
        //        return _context.DailyTaskRecords.Any(e => e.CId == id);
        //    }
    }
}
