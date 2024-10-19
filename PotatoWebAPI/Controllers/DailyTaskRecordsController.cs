using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PotatoWebAPI.DTO;
using PotatoWebAPI.Models;

namespace PotatoWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DailyTaskRecordsController : ControllerBase
    {
        private readonly GoodbyepotatoContext _context;

        public DailyTaskRecordsController(GoodbyepotatoContext context)
        {
            _context = context;
    
        }

        // POST: api/DailyTaskRecords
        // 打開任務區時呼叫
        [HttpPost]
        public async Task<ActionResult<IEnumerable<DailyTaskRecord>>> GetDailyTaskRecords(int ID)
        {
            var today = DateOnly.FromDateTime(DateTime.Today);
            var find = await _context.DailyTaskRecords
                       .Where(f => f.CId == ID && f.TrecordDate == today)
                       .FirstOrDefaultAsync();
            Random random = new Random();
            if (find == null) {
                //隨機挑出三個任務
                //var randomTasks = _context.DailyTasks
                //    .Where(r=> r.TaskActive==true)
                //    .OrderBy(task => random.Next())  
                //    // ()每個符合Where的task都會去調用一次random.Next，在依照生成的隨機數排序
                //    .Take(3)  // 選取三個任務
                //    .ToList();
                var randomTasks = await _context.DailyTasks
                                .FromSqlRaw("SELECT TOP 3 * FROM DailyTask WHERE TaskActive = 1 ORDER BY NEWID()")
                                .ToListAsync();

                //將任務存到DTO
                var Dailytask = new DailytaskDTO
                {
                    CId = ID,
                    //檢查randomTasks的這個List長度有沒有>0 若有則將索引值為0的放入T1name
                    T1name = randomTasks.Count > 0 ? randomTasks[0].TaskName : null,
                    T1completed = false, // 默認為未完成
                    T2name = randomTasks.Count > 1 ? randomTasks[1].TaskName : null,
                    T2completed = false, // 默認為未完成
                    T3name = randomTasks.Count > 2 ? randomTasks[2].TaskName : null,
                    T3completed = false  // 默認為未完成
                };

                //將任務存到資料庫
                var DBtask = new DailyTaskRecord
                {
                    CId = ID,
                    TrecordDate = today,
                    T1name = randomTasks.Count > 0 ? randomTasks[0].TaskName : null,
                    T1completed = false,
                    T2name = randomTasks.Count > 1 ? randomTasks[1].TaskName : null,
                    T2completed = false, 
                    T3name = randomTasks.Count > 2 ? randomTasks[2].TaskName : null,
                    T3completed = false  
                };
                _context.DailyTaskRecords.Add(DBtask);
                await _context.SaveChangesAsync();

                return Ok(Dailytask);
            }
            else { 
                var Dailytask = new DailytaskDTO
                {
                    CId = ID,
                    //檢查randomTasks的這個List長度有沒有>0 若有則將索引值為0的放入T1name
                    T1name = find.T1name,
                    T1completed = find.T1completed, 
                    T2name = find.T2name,
                    T2completed = find.T2completed,
                    T3name = find.T3name,
                    T3completed = find.T3completed,
                };
                return Ok(Dailytask);
            }
        }

        // GET: api/DailyTaskRecords/5
        //[HttpGet("{id}")]
        //public async Task<ActionResult<DailyTaskRecord>> GetDailyTaskRecord(int id)
        //{
        //    var dailyTaskRecord = await _context.DailyTaskRecords.FindAsync(id);

        //    if (dailyTaskRecord == null)
        //    {
        //        return NotFound();
        //    }

        //    return dailyTaskRecord;
        //}

        // PUT: api/DailyTaskRecords/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutDailyTaskRecord(int id, DailyTaskRecord dailyTaskRecord)
        //{
        //    if (id != dailyTaskRecord.CId)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(dailyTaskRecord).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!DailyTaskRecordExists(id))
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

        // POST: api/DailyTaskRecords
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPost]
        //public async Task<ActionResult<DailyTaskRecord>> PostDailyTaskRecord(DailyTaskRecord dailyTaskRecord)
        //{
        //    _context.DailyTaskRecords.Add(dailyTaskRecord);
        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateException)
        //    {
        //        if (DailyTaskRecordExists(dailyTaskRecord.CId))
        //        {
        //            return Conflict();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return CreatedAtAction("GetDailyTaskRecord", new { id = dailyTaskRecord.CId }, dailyTaskRecord);
        //}

        // DELETE: api/DailyTaskRecords/5
        //[HttpDelete("{id}")]
        //public async Task<IActionResult> DeleteDailyTaskRecord(int id)
        //{
        //    var dailyTaskRecord = await _context.DailyTaskRecords.FindAsync(id);
        //    if (dailyTaskRecord == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.DailyTaskRecords.Remove(dailyTaskRecord);
        //    await _context.SaveChangesAsync();

        //    return NoContent();
        //}

        //private bool DailyTaskRecordExists(int id)
        //{
        //    return _context.DailyTaskRecords.Any(e => e.CId == id);
        //}
    }
}
