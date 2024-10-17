using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
}