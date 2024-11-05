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
    public class DailyHealthRecordsController : ControllerBase
    {
        private readonly GoodbyepotatoContext _context;

        public DailyHealthRecordsController(GoodbyepotatoContext context)
        {
            _context = context;
        }

        // GET: api/DailyHealthRecords
        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<DailyHealthRecord>>> GetDailyHealthRecords()
        //{
        //    return await _context.DailyHealthRecords.ToListAsync();
        //}

        // GET: api/DailyHealthRecords/5
        // GET: api/DailyHealthRecords/{cId}/{hrecordDate}
        [HttpGet("{cId}/{hrecordDate}")]
        public async Task<IActionResult> GetDailyHealthRecord(int cId, DateOnly hrecordDate)
        {
            // 使用 Where 查詢複合主鍵
            var dailyHealthRecord = await _context.DailyHealthRecords
                .Where(d => d.CId == cId && d.HrecordDate == hrecordDate)
                .FirstOrDefaultAsync();

            if (dailyHealthRecord == null)
            {
                // 如果資料不存在，返回 404
                return NotFound();
            }

            // 檢查 Sleep 是否存在
            var sleep = dailyHealthRecord.Sleep.HasValue ? dailyHealthRecord.Sleep.Value : DateTime.MinValue;

            string sleepTime = "00:00";

            // 檢查 Sleep 是否是當天的時間
            if (sleep != DateTime.MinValue && sleep.Date == DateTime.Today)
            {
                // 如果 Sleep 是當天的，格式化時間為 HH:mm
                sleepTime = sleep.ToString("HH:mm");
            }

            // 將查詢結果轉換為 DTO
            var recordDTO = new DailyHealthRecordDTO
            {
                CId = dailyHealthRecord.CId,
                HrecordDate = dailyHealthRecord.HrecordDate,
                Water = dailyHealthRecord.Water,
                Steps = dailyHealthRecord.Steps,
                Vegetables = dailyHealthRecord.Vegetables,
                Snacks = dailyHealthRecord.Snacks,
                Sleep = sleepTime,
                Mood = dailyHealthRecord.Mood
            };

            // 返回查詢結果
            return Ok(recordDTO);
        }


        // GET: api/DailyHealthRecords/{cId}
        [HttpGet("{cid}")]
        public async Task<IActionResult> GetAllDailyHealthRecordsByCId(int cId)
        {
            // 使用 Where 只根據 cId 查詢所有資料
            var dailyHealthRecords = await _context.DailyHealthRecords
                .Where(d => d.CId == cId)
                .ToListAsync();

            var weeklyHealthRecords = await _context.WeeklyHealthRecords
                .Where(d => d.CId == cId)
                .ToListAsync();

            // 如果每日和每週資料都不存在，返回 404
            if ((dailyHealthRecords == null || !dailyHealthRecords.Any()) &&
                (weeklyHealthRecords == null || !weeklyHealthRecords.Any()))
            {
                return NotFound();
            }

            // 將每日健康紀錄轉換為 DTO 列表
            var recordDTOs = dailyHealthRecords.Select((d, index) => new
            {
                CId = d.CId,
                HrecordDate = d.HrecordDate,
                Water = d.Water,
                Steps = d.Steps,
                Vegetables = d.Vegetables,
                Snacks = d.Snacks,
                Sleep = d.Sleep.HasValue ? d.Sleep.Value.ToString("HH:mm") : "00:00",
                Mood = d.Mood,
                Exercise = weeklyHealthRecords.ElementAtOrDefault(index)?.Exercise ?? false,
                Cleaning = weeklyHealthRecords.ElementAtOrDefault(index)?.Cleaning ?? false
            }).ToList();

            // 返回查詢結果的 JSON 物件
            return Ok(recordDTOs);
        }


        // PUT: api/DailyHealthRecords/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPut("{cid}")]
        //    public async Task<string> PutDailyHealthRecord(int cid,[FromBody] DailyHealthRecordDTO dailyHealthRecord)
        //    {
        //        if (cid != dailyHealthRecord.CId)
        //        {
        //            return "修改記錄失敗，ID 不一致"; 
        //        }

        //        var dhr = await _context.DailyHealthRecords.Where(e=>e.CId == cid).SingleOrDefaultAsync();


        //        if(dhr == null)
        //        {
        //            return "修改失敗，玩家記錄未找到";
        //        }
        //        // 將 HH:mm 的時間字串轉換為當天的 DateTime
        //        string timeString = dailyHealthRecord.Sleep; // HH:mm 格式
        //        DateTime dateToday = DateTime.Today;  // 取得今天的日期，時間部分為 00:00:00

        //        // 將時間部分解析並加上今天的年月日
        //        DateTime dateTimeWithTime = DateTime.ParseExact(timeString, "HH:mm", System.Globalization.CultureInfo.InvariantCulture);
        //        dateTimeWithTime = dateToday.AddHours(dateTimeWithTime.Hour).AddMinutes(dateTimeWithTime.Minute);
        //        if(dailyHealthRecord.Water == null)
        //        {
        //            dailyHealthRecord.Water = dhr.Water;
        //        }
        //        else
        //        {
        //            dailyHealthRecord.Water += dhr.Water;
        //            if(dailyHealthRecord.Water >= 99999)
        //            {
        //                dailyHealthRecord.Water = 99999;
        //            }
        //        }

        //        dhr.Water = dailyHealthRecord.Water;
        //        dhr.Steps = dailyHealthRecord.Steps;
        //        dhr.Vegetables = dailyHealthRecord.Vegetables;
        //        dhr.Snacks = dailyHealthRecord.Snacks;
        //        dhr.Sleep = dateTimeWithTime;
        //        dhr.Mood = dailyHealthRecord.Mood;

        //        _context.Entry(dhr).State = EntityState.Modified;

        //        try
        //        {
        //            await _context.SaveChangesAsync();
        //            return "修改成功";
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            return "修改失敗，發生並發衝突";
        //        }
        //    }

        // POST: api/DailyHealthRecords
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<IActionResult> PostDailyHealthRecord([FromBody] DailyHealthRecordDTO dailyHealthRecord)
        {
            try
            {
                DateTime dateTimeWithTime;

                // 檢查 Sleep 是否為 null
                if (string.IsNullOrEmpty(dailyHealthRecord.Sleep))
                {
                    // 如果 Sleep 為 null，設置為預設日期 2001/8/13 上午 12:00:00
                    dateTimeWithTime = new DateTime(2001, 8, 13, 0, 0, 0);
                }
                else
                {
                    // 將 HH:mm 的時間字串轉換為當天的 DateTime
                    string timeString = dailyHealthRecord.Sleep; // HH:mm 格式
                    DateTime dateToday = DateTime.Today;  // 取得今天的日期，時間部分為 00:00:00

                    // 將時間部分解析並加上今天的年月日
                    dateTimeWithTime = DateTime.ParseExact(timeString, "HH:mm", System.Globalization.CultureInfo.InvariantCulture);
                    dateTimeWithTime = dateToday.AddHours(dateTimeWithTime.Hour).AddMinutes(dateTimeWithTime.Minute);
                }

                // 建立新的 DailyHealthRecord 實例
                DailyHealthRecord dhr = new DailyHealthRecord
                {
                    CId = dailyHealthRecord.CId,
                    HrecordDate = dailyHealthRecord.HrecordDate,
                    Water = dailyHealthRecord.Water ?? 0,
                    Steps = dailyHealthRecord.Steps ?? 0,
                    Vegetables = dailyHealthRecord.Vegetables ?? 0,
                    Snacks = dailyHealthRecord.Snacks ?? 0,
                    Sleep = dateTimeWithTime,  // 解析後的時間
                    Mood = dailyHealthRecord.Mood ?? "不透露"
                };

                // 新增紀錄到資料庫
                _context.DailyHealthRecords.Add(dhr);
                await _context.SaveChangesAsync();

                // 返回成功訊息和資料
                return Ok($"新增紀錄成功，玩家編號: {dhr.CId}");
            }
            catch (FormatException ex)
            {
                // 捕捉格式錯誤的例外，返回錯誤訊息
                return BadRequest($"時間格式錯誤: {ex.Message}");
            }
            catch (Exception ex)
            {
                // 捕捉其他例外狀況
                return StatusCode(500, $"伺服器內部錯誤: {ex.Message}");
            }
        }

        // DELETE: api/DailyHealthRecords/5
        //[HttpDelete("{id}")]
        //public async Task<IActionResult> DeleteDailyHealthRecord(int id)
        //{
        //    var dailyHealthRecord = await _context.DailyHealthRecords.FindAsync(id);
        //    if (dailyHealthRecord == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.DailyHealthRecords.Remove(dailyHealthRecord);
        //    await _context.SaveChangesAsync();

        //    return NoContent();
        //}

        //private bool DailyHealthRecordExists(int id)
        //{
        //    return _context.DailyHealthRecords.Any(e => e.CId == id);
        //}

        [HttpPatch("{cid}/{hrecordDate}")]
        public async Task<IActionResult> PatchDailyHealthRecord(int cid, DateOnly hrecordDate, [FromBody] DailyHealthRecordDTO dailyHealthRecord)
        {
            // 檢查是否存在該玩家記錄
            var dhr = await _context.DailyHealthRecords
                .Where(e => e.CId == cid && e.HrecordDate == hrecordDate)
                .SingleOrDefaultAsync();

            if (dhr == null)
            {
                return NotFound("玩家記錄未找到");
            }

            // 更新水量 (Water)，如果不為 null
            if (dailyHealthRecord.Water.HasValue)
            {
                // 將資料庫中的 water 與請求的 water 相加
                int currentWater = dhr.Water ?? 0;  // 確保資料庫中沒有水量時使用 0
                dhr.Water = currentWater + dailyHealthRecord.Water.Value;  // 加法操作

                // 設定上限為 99999，避免超過上限
                if (dhr.Water >= 99999)
                {
                    dhr.Water = 99999;
                }
            }            
            
            // 更新步數 (Steps)，如果不為 null
            if (dailyHealthRecord.Steps.HasValue)
            {
                dhr.Steps = dailyHealthRecord.Steps;
            }

            // 更新睡眠時間 (Sleep)，如果不為 null 或空字符串
            if (!string.IsNullOrEmpty(dailyHealthRecord.Sleep))
            {
                DateTime dateToday = DateTime.Today; // 當天的日期
                DateTime dateTimeWithTime = DateTime.ParseExact(dailyHealthRecord.Sleep, "HH:mm", System.Globalization.CultureInfo.InvariantCulture);
                dhr.Sleep = dateToday.AddHours(dateTimeWithTime.Hour).AddMinutes(dateTimeWithTime.Minute);
            }

            // 更新心情 (Mood)，如果不為 null 或空字符串
            if (!string.IsNullOrEmpty(dailyHealthRecord.Mood))
            {
                dhr.Mood = dailyHealthRecord.Mood;
            }

            // 更新蔬果數量 (Vegetables)，如果不為 null
            if (dailyHealthRecord.Vegetables.HasValue)
            {
                dhr.Vegetables = dailyHealthRecord.Vegetables;
            }

            // 更新零食數量 (Snacks)，如果不為 null
            if (dailyHealthRecord.Snacks.HasValue)
            {
                dhr.Snacks = dailyHealthRecord.Snacks;
            }

            // 將實體標記為已修改
            _context.Entry(dhr).State = EntityState.Modified;

            try
            {
                // 保存修改
                await _context.SaveChangesAsync();
                return Ok("部分記錄已成功更新");
            }
            catch (DbUpdateConcurrencyException)
            {
                return Conflict("更新失敗，發生並發衝突");
            }
        }

    }
}
