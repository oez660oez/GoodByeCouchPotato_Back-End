using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PotatoWebAPI.DTO;
using PotatoWebAPI.Models;
using System;
using System.Transactions;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
namespace PotatoWebAPI.Controllers;
[ApiController]
[Route("api/[controller]")]
public class WeightRecordController : ControllerBase
{
    private readonly GoodbyepotatoContext _context;

    public WeightRecordController(GoodbyepotatoContext context)
    {
        _context = context;
    }

    [HttpGet("Status/{account}")]
    public async Task<IActionResult> GetWeightRecord(string account)
    {
        try
        {
            //找到對應的Character ID
            var character = await _context.Characters
                            .FirstOrDefaultAsync(c => c.Account == account);
            if (character == null)
            {
                return NotFound("找不到該帳號的角色資料");
            }

            //取得上個月的第一天和最後一天
            var lastMonth = DateTime.Now.AddMonths(-1);
            var firstDayOfLastMonth = new DateTime(lastMonth.Year, lastMonth.Month, 1);
            var lastDayOfLastMonth = firstDayOfLastMonth.AddMonths(1).AddDays(-1);

            //查詢上個月的體重紀錄
            var lastMonthRecord = await _context.WeightRecords
                    .Where(w => w.CId == character.CId &&
                           w.WRecordDate >= firstDayOfLastMonth &&
                           w.WRecordDate <= lastDayOfLastMonth)
                    .OrderByDescending(w => w.WRecordDate)
                    .FirstOrDefaultAsync();
            if (lastMonthRecord == null)
            {
                return Ok(new { message = "暫無體重紀錄" });
            }

            return Ok(new { weight = lastMonthRecord.Weight });
        }
        catch (Exception ex) 
        {
            return StatusCode(500, new { message = "發生錯誤：" + ex.Message });
        }
    }

    [HttpPost]
    //https://localhost:7180/api/WeightRecord
    public async Task<IActionResult> CreateWeightRecord([FromBody] WeightRecordDTO dto)
    {
        try
        {
            //找到對應的Character ID
            var character = await _context.Characters
                            .FirstOrDefaultAsync(c => c.Account == dto.Account);
            if (character == null)
            {
                return NotFound("找不到該帳號的角色資料");
            }
            //取得當前月份的第一天和最後一天
            var now = DateTime.Now;
            var firstDayOfMonth = new DateTime(now.Year, now.Month, 1);
            var lastDayOfMonth = firstDayOfMonth.AddMonths(1).AddDays(-1);
            //查詢本月是否已有紀錄
            var existingRecord = await _context.WeightRecords.FirstOrDefaultAsync(w => w.CId == character.CId &&
                                            w.WRecordDate >= firstDayOfMonth &&
                                            w.WRecordDate <= lastDayOfMonth);
            if (existingRecord != null)
            {
                //更新現有紀錄
                existingRecord.Weight = dto.Weight;
            }
            else
            {
                //創建新紀錄
                var newRecord = new WeightRecord
                {
                    CId = character.CId,
                    Weight = dto.Weight
                };
                _context.WeightRecords.Add(newRecord);
            }
            await _context.SaveChangesAsync();
            return Ok(new { message = "體重記錄已更新" });
        }
        catch (Exception ex) 
        {
            return StatusCode(500, new { message = "發生錯誤：" + ex.Message });
        }
    }

}