using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.DotNet.Scaffolding.Shared.Messaging;
using Microsoft.EntityFrameworkCore;
using PotatoWebAPI.DTO;
using PotatoWebAPI.Models;
using X.PagedList.Extensions;

namespace PotatoWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class ShopAccessoriesListsController : ControllerBase
    {
        private readonly GoodbyepotatoContext _context;
        private readonly IConfiguration _configuration;

        public ShopAccessoriesListsController(GoodbyepotatoContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }



        // GET: api/ShopAccessoriesLists
        [HttpPost("GetList")]                    //直接用int page接不到前端的數字，因為前端傳遞的時候是json對象，是page:2這樣的規格，int page期待的是一個單一整數型態會無法解析
        public async Task<ActionResult<IEnumerable<AccessoriesList>>> GetAccessoriesLists([FromBody] PageRequestDTO request)
        {
            int page = request.Page > 0 ? request.Page : 1;
            string baseUrl = _configuration["ImgSetting:ImgUrl"];  //用來串接圖片
            var allclass = _context.AccessoriesLists.Select(s => s.PClass).Distinct();  //求類別
            Console.WriteLine( request.Account);
            var Items = _context.AccessoriesLists
                .Where(s => s.PActive == true);  //求所有商品
            var haveitem =from list in _context.AccessoriesLists join myitems in _context.CharacterItems on list.PCode equals myitems.PCode where myitems.Account==request.Account select myitems.PCode;  //求玩家持有物品
            var GetphotoItems = Items.Select(s => new AccessoriesListsDTO
            {
                PCode = s.PCode,
                PClass = s.PClass,
                PName = s.PName,
                PPrice = s.PPrice,
                PLevel = s.PLevel,
                PImageShop = $"{baseUrl}/images/{s.PImageShop}",
                PImageAll = $"{baseUrl}/images/{s.PImageAll}",
                ishaveitem =haveitem.Any(myitem=>myitem==s.PCode) ,  //確認是否有重複pcode，如果有表示有持有
            });

            GetphotoItems = GetphotoItems.OrderBy(s => s.ishaveitem).ThenBy(s => s.PLevel);
            var PageItem = GetphotoItems.ToPagedList(page, 10);  //使用page的資料必須用資料庫數據，不能先做tolist

            int currentpages = PageItem.PageNumber;   //目前在第幾頁
            int totalpages = PageItem.PageCount;  //所有頁數

            return Ok(new
            {
                Allclass = allclass,
                QualifiedItem =PageItem,
                Currentpage = PageItem.PageNumber,
                Totalpages = PageItem.PageCount,
                AllqualifiedItem= GetphotoItems,  //取全部不分頁的商品
            });
        }

        [HttpPost("purchase")]
        public async Task<ActionResult<PurchaseDTO>> PurchaseAccessoriesLists([FromBody] PurchaseDTO purchase)
        {
            bool isplayercharacter = _context.Characters.Any(s => s.CId == purchase.CId);
            if (isplayercharacter)
            {
                var player = _context.Players.Where(s => s.Account == purchase.Account);
                var playercharacte = _context.Characters.Where(s => s.Account == purchase.Account && s.LivingStatus=="居住").FirstOrDefault();
                if (playercharacte.Coins.Equals((int)purchase.Coins))  //確認抓到的金額是正確的
                {
                    if (purchase.PPrice <= purchase.Coins)
                    {
                        if (player != null && playercharacte != null)
                        {
                            var newpurchase = new CharacterItem
                            {
                                Account = purchase.Account,
                                PCode = (int)purchase.PCode
                            };
                            _context.CharacterItems.Add(newpurchase);
                            int Newcoins= (int)playercharacte.Coins - (int)purchase.PPrice;
                            playercharacte.Coins = Newcoins;
                            await _context.SaveChangesAsync();
                            return Ok(new { Message = "購買成功", newcoins = Newcoins });  //回傳金額，確保前後儲存的金額是一致的
                        }
                        return Ok(new { Message = "購買失敗，商品已重複"});
                    }
                    return Ok(new { Message = "Coins不足" });
                }
                    return Ok(new { Message = $"coin不相符，${playercharacte.Coins}" });
            }
                return Ok(new { Message = "查無此帳號，或此角色已搬離" });
        }
        [HttpPost("GetNowBody")]
        public async Task<ActionResult> Getbodyaccessory([FromBody] bodyaccessoryDTO bodyaccessoryDTO)
        {
            //int head = string.IsNullOrEmpty(bodyaccessoryDTO.head) ? 0 : int.Parse(bodyaccessoryDTO.head);
            //int body = string.IsNullOrEmpty(bodyaccessoryDTO.body) ? 0 : int.Parse(bodyaccessoryDTO.body);
            //int accessory = string.IsNullOrEmpty(bodyaccessoryDTO.accessory) ? 0 : int.Parse(bodyaccessoryDTO.accessory);
            int head = (int)bodyaccessoryDTO.head < 0 ? 0 : (int)bodyaccessoryDTO.head;
            int body = (int)bodyaccessoryDTO.body < 0 ? 0 : (int)bodyaccessoryDTO.body;
            int accessory = (int)bodyaccessoryDTO.accessory < 0 ? 0 : (int)bodyaccessoryDTO.accessory;

            string headImage = "";
            string bodyImage = "";
            string accessoryImage = "";

            if (head > 0)
            {
                headImage = _context.AccessoriesLists
                                    .Where(s => s.PCode.Equals(head))
                                    .Select(s => s.PImageAll)
                                    .FirstOrDefault() ?? "";  //沒有內容則回傳空
            }
            if (body > 0)
            {
                bodyImage = _context.AccessoriesLists
                                    .Where(s => s.PCode.Equals(body))
                                    .Select(s => s.PImageAll)
                                    .FirstOrDefault() ?? "";
            }
            if (accessory > 0)
            {
                accessoryImage = _context.AccessoriesLists
                                         .Where(s => s.PCode.Equals(accessory))
                                         .Select(s => s.PImageAll)
                                         .FirstOrDefault() ?? "";
            }

            return Ok(new { Head = headImage, Body = bodyImage, Accessory = accessoryImage });
        }

        // GET: api/ShopAccessoriesLists/5
        //[HttpGet("{id}")]
        //public async Task<ActionResult<AccessoriesList>> GetAccessoriesList(int id)
        //{
        //    var accessoriesList = await _context.AccessoriesLists.FindAsync(id);

        //    if (accessoriesList == null)
        //    {
        //        return NotFound();
        //    }

        //    return accessoriesList;
        //}

        // PUT: api/ShopAccessoriesLists/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutAccessoriesList(int id, AccessoriesList accessoriesList)
        //{
        //    if (id != accessoriesList.PCode)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(accessoriesList).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!AccessoriesListExists(id))
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

        // POST: api/ShopAccessoriesLists
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPost]
        //public async Task<ActionResult<AccessoriesList>> PostAccessoriesList(AccessoriesList accessoriesList)
        //{
        //    _context.AccessoriesLists.Add(accessoriesList);
        //    await _context.SaveChangesAsync();

        //    return CreatedAtAction("GetAccessoriesList", new { id = accessoriesList.PCode }, accessoriesList);
        //}

        // DELETE: api/ShopAccessoriesLists/5
        //[HttpDelete("{id}")]
        //public async Task<IActionResult> DeleteAccessoriesList(int id)
        //{
        //    var accessoriesList = await _context.AccessoriesLists.FindAsync(id);
        //    if (accessoriesList == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.AccessoriesLists.Remove(accessoriesList);
        //    await _context.SaveChangesAsync();

        //    return NoContent();
        //}




        private bool AccessoriesListExists(int id)
        {
            return _context.AccessoriesLists.Any(e => e.PCode == id);
        }
    }
}
