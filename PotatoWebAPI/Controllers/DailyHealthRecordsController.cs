using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PotatoWebAPI.Models;
using PotatoWebAPI.Models.DTO;

namespace PotatoWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DailyHealthRecordsController : ControllerBase
    {
        private readonly GoodbyepotatoContext _context;

        public DailyHealthRecordsController(GoodbyepotatoContext context)
        {
            _context = context;
        }

        // GET: api/DailyHealthRecords
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DailyHealthRecord>>> GetDailyHealthRecords()
        {
            return await _context.DailyHealthRecords.ToListAsync();
        }

        // GET: api/DailyHealthRecords/5
        // GET: api/DailyHealthRecords/{cId}/{hrecordDate}
        [HttpGet("{cId}/{hrecordDate}")]
        public async Task<DailyHealthRecordDTO> GetDailyHealthRecord(int cId, DateOnly hrecordDate)
        {
            // 使用 Where 查詢複合主鍵
            var dailyHealthRecord = await _context.DailyHealthRecords
                .Where(d => d.CId == cId && d.HrecordDate == hrecordDate)
                .FirstOrDefaultAsync();

            DailyHealthRecordDTO recordDTO = null;

            if (dailyHealthRecord != null)
            {
                var sleep = dailyHealthRecord.Sleep.Value;

                string sleepTime = "00:00";
                // 檢查 Sleep 是否是當天的時間
                if (sleep.Date == DateTime.Today)
                {
                    // 如果 Sleep 是當天的，格式化時間為 HH:mm
                    sleepTime = sleep.ToString("HH:mm");
                }
                else
                {
                    // 如果不是當天的時間，設置為預設值 00:00
                    sleepTime = "00:00";
                }
                // 檢查 Sleep 的日期部分是否等於 hrecordDate
                //if (sleep.Date == hrecordDate.ToDateTime(new TimeOnly(0, 0)).Date)
                //{
                //    // 如果 Sleep 是當天的，格式化為 HH:mm
                //    sleepTime = sleep.ToString("HH:mm");
                //}
                // 將查詢結果轉換為 DTO
                recordDTO = new DailyHealthRecordDTO
                {
                    Water = dailyHealthRecord.Water,
                    Steps = dailyHealthRecord.Steps,
                    Vegetables = dailyHealthRecord.Vegetables,
                    Snacks = dailyHealthRecord.Snacks,
                    Sleep = sleepTime,
                    Mood = dailyHealthRecord.Mood
                };
            }

            // 返回查詢結果
            return recordDTO;
        }

        // PUT: api/DailyHealthRecords/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDailyHealthRecord(int id, DailyHealthRecord dailyHealthRecord)
        {
            if (id != dailyHealthRecord.CId)
            {
                return BadRequest();
            }

            _context.Entry(dailyHealthRecord).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DailyHealthRecordExists(id))
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

        // POST: api/DailyHealthRecords
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<DailyHealthRecord>> PostDailyHealthRecord(DailyHealthRecord dailyHealthRecord)
        {
            _context.DailyHealthRecords.Add(dailyHealthRecord);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (DailyHealthRecordExists(dailyHealthRecord.CId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetDailyHealthRecord", new { id = dailyHealthRecord.CId }, dailyHealthRecord);
        }

        // DELETE: api/DailyHealthRecords/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDailyHealthRecord(int id)
        {
            var dailyHealthRecord = await _context.DailyHealthRecords.FindAsync(id);
            if (dailyHealthRecord == null)
            {
                return NotFound();
            }

            _context.DailyHealthRecords.Remove(dailyHealthRecord);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DailyHealthRecordExists(int id)
        {
            return _context.DailyHealthRecords.Any(e => e.CId == id);
        }
    }
}
