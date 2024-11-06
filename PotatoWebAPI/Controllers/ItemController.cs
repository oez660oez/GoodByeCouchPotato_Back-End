using Microsoft.AspNetCore.Cors;
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
    private readonly IConfiguration _configuration;
    private readonly string _baseUrl;

    private readonly Dictionary<string, string> _typeMapping = new Dictionary<string, string> {
        { "accessory", "飾品" },
        { "hairstyle", "髮型" },
        { "outfit", "衣服" },
        { "飾品", "accessory" },
        { "髮型", "hairstyle" },
        { "衣服", "outfit" }
    };

    public ItemController(GoodbyepotatoContext context, IConfiguration configuration)
    {
        _context = context;
        _configuration = configuration;
        _baseUrl = _configuration["ImgSetting:ImgUrl"];
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

        var result = new
        {
            pCode = accessory.PCode,
            pClass = accessory.PClass,
            pImageShop = $"{_baseUrl}/images/{accessory.PImageShop}",
            pImageAll = $"{_baseUrl}/images/{accessory.PImageAll}"
        };

        return Ok(result);
    }

    [HttpGet("userItems/{account}")]
    public async Task<ActionResult<IEnumerable<object>>> GetUserItems(string account)
    {
        var userItems = await (from ci in _context.CharacterItems
                               join al in _context.AccessoriesLists
                               on ci.PCode equals al.PCode
                               where ci.Account == account
                               select new
                               {
                                   type = _typeMapping.ContainsKey(al.PClass)
                                       ? _typeMapping[al.PClass]
                                       : al.PClass,
                                   imageName = $"{_baseUrl}/images/{al.PImageShop}"
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
            var character = await _context.Characters
                .Where(w => w.LivingStatus == "居住")
                .FirstOrDefaultAsync(c => c.Account == account);

            if (character == null)
                return NotFound($"No character found for account: {account}");

            var characterAccessories = await _context.CharacterAccessories
               .FirstOrDefaultAsync(ca => ca.CId == character.CId);

            if (characterAccessories == null)
                return NotFound($"No accessories found for character ID: {character.CId}");

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

        if (accessory == null)
            return null;

        var englishType = _typeMapping.ContainsKey(accessory.PClass)
            ? _typeMapping[accessory.PClass]
            : accessory.PClass;

        return new
        {
            type = englishType,
            imageName = $"{_baseUrl}/images/{accessory.PImageShop}"
        };
    }
    [HttpPost("updateEquipment")]
    public async Task<IActionResult> UpdateEquipment([FromBody] EquipmentUpdateDTO dto)
    {
        try
        {
            // 1. 獲取角色 ID
            var character = await _context.Characters
                .Where(w => w.LivingStatus == "居住")
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

    private async Task<int?> GetPCodeFromImageName(string imageName)
    {
        if (string.IsNullOrEmpty(imageName))
            return 0;

        var accessory = await _context.AccessoriesLists
            .FirstOrDefaultAsync(a => a.PImageShop == imageName);

        return accessory?.PCode ?? 0;
    }
}