using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PotatoWebAPI.DTO;
using PotatoWebAPI.Models;
using System;
namespace PotatoWebAPI.Controllers;
[ApiController]
[Route("api/[controller]")]
public class ItemController : ControllerBase
{
    private readonly GoodbyepotatoContext _context;

    public ItemController(GoodbyepotatoContext context)
    {
        _context = context;
    }

    [HttpGet("byShopImage")]
    public async Task<ActionResult<AccessoriesList>> GetByShopImage(string shopImage)
    {
        var accessory = await _context.AccessoriesLists
            .FirstOrDefaultAsync(a => a.PImageShop == shopImage);
        if (accessory == null)
        {
            return NotFound();
        }
        return accessory;
    }

    // 新增: 獲取用戶物品列表的端點
    [HttpGet("userItems/{account}")]
    public async Task<ActionResult<IEnumerable<object>>> GetUserItems(string account)
    {
        var userItems = await (from ci in _context.CharacterItems
                               join al in _context.AccessoriesLists
                               on ci.PCode equals al.PCode
                               where ci.Account == account
                               select new
                               {
                                   type = al.PClass,
                                   imageName = al.PImageShop
                               }).ToListAsync();

        if (!userItems.Any())
        {
            return NotFound($"No items found for account: {account}");
        }

        return Ok(userItems);
    }
    [HttpGet("characterEquipment/{account}")]
    public async Task<ActionResult<object>> GetCharacterEquipment(string account)
    {
        try
        {
            // 1. 先從 Character 表獲取 C_ID
            var character = await _context.Characters
                .FirstOrDefaultAsync(c => c.Account == account);

            if (character == null)
                return NotFound($"No character found for account: {account}");

            // 2. 使用 C_ID 從 CharacterAccessorie 表獲取裝備資訊
            var characterAccessories = await _context.CharacterAccessories
                .FirstOrDefaultAsync(ca => ca.CId == character.CId);

            if (characterAccessories == null)
                return NotFound($"No accessories found for character ID: {character.CId}");

            // 3. 獲取各個裝備的詳細資訊
            var equipmentInfo = new
            {
                accessory = await GetEquipmentDetails((int)characterAccessories.Head),
                hairstyle = await GetEquipmentDetails((int)characterAccessories.Upper),
                outfit = await GetEquipmentDetails((int)characterAccessories.Lower)
            };

            return Ok(equipmentInfo);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }

    private async Task<object> GetEquipmentDetails(int equipmentCode)
    {
        if (equipmentCode == 0)
            return null;

        var accessory = await _context.AccessoriesLists
            .FirstOrDefaultAsync(a => a.PCode == equipmentCode);

        return accessory == null ? null : new
        {
            type = accessory.PClass,
            imageName = accessory.PImageShop
        };
    }
    [HttpPost("updateEquipment")]
    public async Task<IActionResult> UpdateEquipment([FromBody] EquipmentUpdateDTO dto)
    {
        try
        {
            // 1. 獲取角色 ID
            var character = await _context.Characters
                .FirstOrDefaultAsync(c => c.Account == dto.Account);

            if (character == null)
                return NotFound($"No character found for account: {dto.Account}");

            // 2. 獲取或創建 CharacterAccessorie 記錄
            var characterAccessories = await _context.CharacterAccessories
                .FirstOrDefaultAsync(ca => ca.CId == character.CId);

            if (characterAccessories == null)
            {
                characterAccessories = new CharacterAccessorie
                {
                    CId = character.CId
                };
                _context.CharacterAccessories.Add(characterAccessories);
            }

            // 3. 更新裝備
            characterAccessories.Head = await GetPCodeFromImageName(dto.Accessory?.ImageName);
            characterAccessories.Upper = await GetPCodeFromImageName(dto.Hairstyle?.ImageName);
            characterAccessories.Lower = await GetPCodeFromImageName(dto.Outfit?.ImageName);

            await _context.SaveChangesAsync();
            return Ok();
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }

    [HttpPost("updateInventory")]
    public async Task<IActionResult> UpdateInventory([FromBody] InventoryUpdateDTO dto)
    {
        try
        {
            // 1. 刪除現有物品
            var existingItems = await _context.CharacterItems
                .Where(ci => ci.Account == dto.Account)
                .ToListAsync();

            _context.CharacterItems.RemoveRange(existingItems);

            // 2. 添加新物品
            if (dto.Items != null)
            {
                foreach (var item in dto.Items)
                {
                    var pCode = await GetPCodeFromImageName(item.ImageName);
                    if (pCode.HasValue)
                    {
                        var characterItem = new CharacterItem
                        {
                            Account = dto.Account,
                            PCode = pCode.Value
                        };
                        _context.CharacterItems.Add(characterItem);
                    }
                }
            }

            await _context.SaveChangesAsync();
            return Ok();
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }

    private async Task<int?> GetPCodeFromImageName(string imageName)
    {
        if (string.IsNullOrEmpty(imageName))
            return 0;

        var accessory = await _context.AccessoriesLists
            .FirstOrDefaultAsync(a => a.PImageShop == imageName);

        return accessory?.PCode ?? 0;
    }
}
