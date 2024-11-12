using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NuGet.Protocol.Plugins;
using PotatoWebAPI.DTO;
using PotatoWebAPI.Models;

namespace PotatoWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WeeklyHealthRecordsController : ControllerBase
    {
        private readonly GoodbyepotatoContext _context;

        public WeeklyHealthRecordsController(GoodbyepotatoContext context)
        {
            _context = context;
        }

        private (DateOnly monday, DateOnly sunday) GetCurrentWeekDates()
        {
            DateOnly today = DateOnly.FromDateTime(DateTime.Today);
            DayOfWeek dayOfWeek = today.DayOfWeek;
            int daysUntilMonday = (int)dayOfWeek - (int)DayOfWeek.Monday;
            if (daysUntilMonday < 0) { daysUntilMonday += 7; }

            DateOnly monday = today.AddDays(-daysUntilMonday);
            DateOnly sunday = monday.AddDays(6);

            return (monday, sunday);
        }

        // 計算運動次數的通用方法
        private async Task<int> CountWeeklySport(int CId)
        {
            var (monday, sunday) = GetCurrentWeekDates();
            int countsport = await _context.WeeklyHealthRecords
                .CountAsync(c => c.CId == CId &&
                              c.Exercise == true &&
                             c.WrecordDate >= monday &&
                             c.WrecordDate <= sunday);
            return (countsport);
        }

        private async Task<int> CountWeeklyClean(int CId)
        {
            var (monday, sunday) = GetCurrentWeekDates();
            int countclean = await _context.WeeklyHealthRecords
                            .Where(c => c.CId == CId)
                            .Where(c => c.Cleaning == true)
                            .Where(c => c.WrecordDate >= monday && c.WrecordDate <= sunday)
                            .CountAsync();
            return (countclean);
        }


        // POST: api/WeeklyHealthRecords
        [HttpPost("GetWeeklyHealthRecords")]
        public async Task<ActionResult<IEnumerable<WeeklyHealthRecord>>> GetWeeklyHealthRecords(DailytaskgetidDTO getid)
        {
         
            //呼叫計算本周已達成次數的方法
            int countsport = await CountWeeklySport(getid.CId);
            int countclean = await CountWeeklyClean(getid.CId);

            //得出今日日期，找出今日是否已經達成
            DateOnly today = DateOnly.FromDateTime(DateTime.Today); //今天日期(年月日)
            var todayrecord = await _context.WeeklyHealthRecords
                            .Where(c => c.CId == getid.CId)
                            .Where(c => c.WrecordDate == today)
                            .FirstOrDefaultAsync();
            bool todaysport = false;
            bool todayclean = false;
            //如果有紀錄就塞紀錄，沒有則回null，但不需要先建一筆資料
            if (todayrecord != null)
            {
                todaysport = todayrecord.Exercise;
                todayclean = todayrecord.Cleaning;
            }

            //存入DTO，回傳
            WeeklyTaskDTO WeeklyTaskDTO = new WeeklyTaskDTO
            {
                CId = getid.CId,
                countsport = countsport,
                countclean = countclean,
                todaysport = todaysport,
                todayclean = todayclean,
            };

            return Ok(WeeklyTaskDTO);
        }

        [HttpPost]
        public async Task<ActionResult<IEnumerable<WeeklyHealthRecord>>> UpdateWeeklyHealthRecords(WeeklyTaskDTO WeeklyTaskDTO)
        {
            //如果有True的話，到資料庫尋找有沒有今日資料
            string returnword = "";

            DateOnly today = DateOnly.FromDateTime(DateTime.Today);
            var oldrecord = await _context.WeeklyHealthRecords
                            .Where(o => o.CId == WeeklyTaskDTO.CId)
                            .Where(o => o.WrecordDate == today)
                            .FirstOrDefaultAsync();
            //沒有資料，建一筆新的資料
            //先判斷她回傳的是不是兩個False 是的話直接回傳結果
            if (WeeklyTaskDTO.todayclean == false && WeeklyTaskDTO.todaysport == false)
            {
                returnword = "今天還沒達成任務呢 繼續加油(๑•̀ㅂ•́)و✧";
                int countsport = await CountWeeklySport(WeeklyTaskDTO.CId);
                int countclean = await CountWeeklyClean(WeeklyTaskDTO.CId);
                var rerecord = await _context.WeeklyHealthRecords
                               .Where(o => o.CId == WeeklyTaskDTO.CId)
                               .FirstOrDefaultAsync();
                updateWeeklyTaskDTO updateok = new updateWeeklyTaskDTO
                {
                    countsport = countsport,
                    countclean = countclean,
                    todaysport = false,
                    todayclean = false,
                    returnword = returnword,
                };
                return Ok(updateok);
            }
            else
            {
                if (oldrecord == null)
                {
                    var DBnew = new WeeklyHealthRecord
                    {
                        CId = WeeklyTaskDTO.CId,
                        WrecordDate = today,
                        Exercise = WeeklyTaskDTO.todaysport,
                        Cleaning = WeeklyTaskDTO.todayclean,
                    };
                    _context.WeeklyHealthRecords.Add(DBnew);
                    await _context.SaveChangesAsync();
                    returnword = "更新成功 離Potato越來越遠啦٩(๑•̀ω•́๑)۶";

                }

                //有資料的話
                else
                {
                    //判斷舊資料跟新資料是否都相同(沒更新)
                    if ((oldrecord.Exercise == WeeklyTaskDTO.todaysport) && (oldrecord.Cleaning == WeeklyTaskDTO.todayclean))
                    {
                        returnword = "本次沒有更新任何資料 \n ｡ﾟヽ(ﾟ´Д`)ﾉﾟ｡";
                    }
                    else
                    {
                        oldrecord.Exercise = WeeklyTaskDTO.todaysport;
                        oldrecord.Cleaning = WeeklyTaskDTO.todayclean;
                        _context.WeeklyHealthRecords.Update(oldrecord);
                        await _context.SaveChangesAsync();
                        returnword = "更新成功 離Potato越來越遠啦٩(๑•̀ω•́๑)۶";
                    }
                }

                //到這裡應該是全部更新好了，呼叫計算本周已達成次數的方法，想確保有更新成功就再查本日最新資料一次
                int countsport = await CountWeeklySport(WeeklyTaskDTO.CId);
                int countclean = await CountWeeklyClean(WeeklyTaskDTO.CId);
                var rerecord = await _context.WeeklyHealthRecords
                                .Where(o => o.CId == WeeklyTaskDTO.CId)
                                .Where(o => o.WrecordDate == today)
                                .FirstOrDefaultAsync();

                //
                updateWeeklyTaskDTO updateok = new updateWeeklyTaskDTO
                {
                    countsport = countsport,
                    countclean = countclean,
                    todaysport = rerecord.Exercise,
                    todayclean = rerecord.Cleaning,
                    returnword = returnword,
                };
                return Ok(updateok);
            }

        }




        //// GET: api/WeeklyHealthRecords/5
        //[HttpGet("{id}")]
        //public async Task<ActionResult<WeeklyHealthRecord>> GetWeeklyHealthRecord(int id)
        //{
        //    var weeklyHealthRecord = await _context.WeeklyHealthRecords.FindAsync(id);

        //    if (weeklyHealthRecord == null)
        //    {
        //        return NotFound();
        //    }

        //    return weeklyHealthRecord;
        //}

        //// PUT: api/WeeklyHealthRecords/5
        //// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutWeeklyHealthRecord(int id, WeeklyHealthRecord weeklyHealthRecord)
        //{
        //    if (id != weeklyHealthRecord.CId)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(weeklyHealthRecord).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!WeeklyHealthRecordExists(id))
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

        //// POST: api/WeeklyHealthRecords
        //// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPost]
        //public async Task<ActionResult<WeeklyHealthRecord>> PostWeeklyHealthRecord(WeeklyHealthRecord weeklyHealthRecord)
        //{
        //    _context.WeeklyHealthRecords.Add(weeklyHealthRecord);
        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateException)
        //    {
        //        if (WeeklyHealthRecordExists(weeklyHealthRecord.CId))
        //        {
        //            return Conflict();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return CreatedAtAction("GetWeeklyHealthRecord", new { id = weeklyHealthRecord.CId }, weeklyHealthRecord);
        //}

        //// DELETE: api/WeeklyHealthRecords/5
        //[HttpDelete("{id}")]
        //public async Task<IActionResult> DeleteWeeklyHealthRecord(int id)
        //{
        //    var weeklyHealthRecord = await _context.WeeklyHealthRecords.FindAsync(id);
        //    if (weeklyHealthRecord == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.WeeklyHealthRecords.Remove(weeklyHealthRecord);
        //    await _context.SaveChangesAsync();

        //    return NoContent();
        //}

        //private bool WeeklyHealthRecordExists(int id)
        //{
        //    return _context.WeeklyHealthRecords.Any(e => e.CId == id);
        //}
    }
}
