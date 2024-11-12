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
            var character = await _context.Characters
                            .FirstOrDefaultAsync(c => c.Account == account && c.LivingStatus == "居住");
            if (character == null)
            {
                return NotFound("找不到該帳號的角色資料");
            }

            // 使用 DateOnly包Datetime.now取現在時間
            var today = DateOnly.FromDateTime(DateTime.Now);
            var lastMonth = today.AddMonths(-1);
            var firstDayOfLastMonth = new DateOnly(lastMonth.Year, lastMonth.Month, 1);
            var lastDayOfLastMonth = firstDayOfLastMonth.AddMonths(1).AddDays(-1);

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
    public async Task<IActionResult> CreateWeightRecord([FromBody] WeightRecordDTO dto)
    {
        using var transaction = await _context.Database.BeginTransactionAsync();
        try
        {
            var character = await _context.Characters
                            .FirstOrDefaultAsync(c => c.Account == dto.Account && c.LivingStatus == "居住");
            if (character == null)
            {
                return NotFound("找不到該帳號的居住狀態角色資料");
            }

            var today = DateOnly.FromDateTime(DateTime.Now);
            var firstDayOfMonth = new DateOnly(today.Year, today.Month, 1);
            var lastDayOfMonth = firstDayOfMonth.AddMonths(1).AddDays(-1);

			var existingRecord = await _context.WeightRecords.FirstOrDefaultAsync(w =>
											w.CId == character.CId &&
											w.WRecordDate == today);

			if (existingRecord != null)
            {
                existingRecord.Weight = dto.Weight;
            }
            else
            {
                var newRecord = new WeightRecord
                {
                    CId = character.CId,
                    Weight = dto.Weight,
                    WRecordDate = today
                };
                _context.WeightRecords.Add(newRecord);
            }
            character.TargetWater = (int)(Math.Round(dto.Weight * 30 / 100m, 0) * 100);
            character.StandardWater = CalculateStandardWater(dto.Weight * 30);

            await _context.SaveChangesAsync();
            await transaction.CommitAsync();

            return Ok(new
            {
                message = "體重記錄已更新",
                targetWater = character.TargetWater,
                standardWater = character.StandardWater
            });
        }
        catch (Exception ex)
        {
            await transaction.RollbackAsync();
            return StatusCode(500, new { message = "發生錯誤：" + ex.Message });
        }
    }
    private int CalculateStandardWater(decimal waterAmount)
    {
        var ranges = new List<(decimal Lower, decimal Upper, int Standard)>
    {
        (0, 500, 500),
        (500, 1000, 500),
        (1000, 1500, 700),
        (1500, 2000, 1200),
        (2000, 2500, 1700),
        (2500, 3000, 2200),
        (3000, 3500, 2700),
        (3500, 4000, 3200),
        (4000, 4500, 3700),
        (4500, 5000, 4200),
        (5000, 5500, 4700),
        (5500, 6000, 5200),
        (6000, 6500, 5700),
        (6500, 7000, 6200),
        (7000, 7500, 6700),
        (7500, 8000, 7200),
        (8000, 8500, 7700),
        (8500, 9000, 8200),
        (9000, 9500, 8700),
        (9500, 10000, 9200)
    };

        foreach (var range in ranges)
        {
            if (waterAmount > range.Lower && waterAmount <= range.Upper)
            {
                return range.Standard;
            }
        }

        return waterAmount > 10000 ? 10000 : 500;
    }
}