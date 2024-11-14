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
public class CreateCharacterController : ControllerBase
{
    private readonly GoodbyepotatoContext _context;
    private readonly ILogger<CreateCharacterController> _logger;

    public CreateCharacterController(GoodbyepotatoContext context, ILogger<CreateCharacterController> logger)
    {
        _context = context;
        _logger = logger;
    }

    [HttpGet("Status/{account}")]
    public async Task<IActionResult> GetCharacterStatus(string account)
    {
        var character = await _context.Characters
           .Where(c => c.Account == account)
           .OrderByDescending(c => c.CId)
           .FirstOrDefaultAsync();
        if (character == null)
        {
            return Ok(new { livingStatus = "none" });
        }

        return Ok(new { livingStatus = character.LivingStatus });
    }

    [HttpPost]
    //https://localhost:7180/api/CreateCharacter
    public async Task<IActionResult> CreateCharacter([FromBody] CreateCharacterDTO dto)
    {
        //使用交易，若前面新建失敗後面會回滾，防止建一半的狀況。
        using var transaction = await _context.Database.BeginTransactionAsync();
        try
        {
            var existingCharacter = await _context.Characters
                    .FirstOrDefaultAsync(c => c.Name == dto.Name);

            if (existingCharacter != null)
            {
                return BadRequest(new { message = "角色名稱已存在" });
            }

            // 檢查該帳號是否已有活躍角色
            var activeCharacter = await _context.Characters
                .FirstOrDefaultAsync(c => c.Account == dto.Account && c.LivingStatus == "居住");

            if (activeCharacter != null)
            {
                return BadRequest(new { message = "該帳號已有活躍角色" });
            }

            var character = new Character
            {
                Name = dto.Name,
                Height = dto.Height,
                Weight = dto.Weight,
                Account = dto.Account,
                // 設定運動目標步數
                TargetStep = dto.ExerciseIntensity switch
                {
                    "久坐" => 5000,
                    "低活動" => 7500,
                    "中活動" => 10000,
                    "高活動" => 12500,
                    _ => 5000
                },
                // 設定標準步數
                StandardStep = dto.ExerciseIntensity switch
                {
                    "久坐" => 3000,
                    "低活動" => 6000,
                    "中活動" => 8000,
                    "高活動" => 10000,
                    _ => 3000
                },
                // 計算目標飲水量（四捨五入到百位數）
                TargetWater = (int)(Math.Round(dto.Weight * 30 / 100m, 0) * 100),
                // 計算標準飲水量
                StandardWater = CalculateStandardWater(dto.Weight * 30),
                // 預設值
                Environment = 80,
                LivingStatus = "居住",
                Coins = 0,
                GetEnvironment = 0,
                GetExperience = 0,
                GetCoins = 0
            };
            // 使用 ExecuteAsync 確保資料庫操作的原子性
            await using (var command = _context.Database.GetDbConnection().CreateCommand())
            {
                if (command.Connection.State != System.Data.ConnectionState.Open)
                    await command.Connection.OpenAsync();

                try
                {
                    _context.Characters.Add(character);
                    await _context.SaveChangesAsync();

                    var characterAccessorie = new CharacterAccessorie
                    {
                        CId = character.CId,
                        Head = 0,
                        Upper = 0,
                        Lower = 0
                    };

                    _context.CharacterAccessories.Add(characterAccessorie);

                    var weightRecord = new WeightRecord
                    {
                        CId = character.CId,
                        Weight = dto.Weight,
                        WRecordDate = DateOnly.FromDateTime(DateTime.Now)
                    };

                    _context.WeightRecords.Add(weightRecord);
                    await _context.SaveChangesAsync();

                    await transaction.CommitAsync();

                    return Ok(new
                    {
                        Character = character,
                        CharacterAccessorie = characterAccessorie,
                        WeightRecord = weightRecord
                    });
                }
                catch (DbUpdateException ex)
                {
                    _logger.LogError(ex, "資料庫更新錯誤: {Message}", ex.InnerException?.Message ?? ex.Message);
                    await transaction.RollbackAsync();
                    return BadRequest(new { message = "資料庫更新錯誤，請稍後再試" });
                }
            }
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "創建角色時發生未預期的錯誤: {Message}", ex.Message);
            await transaction.RollbackAsync();
            return BadRequest(new { message = "發生未預期的錯誤，請稍後再試" });
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