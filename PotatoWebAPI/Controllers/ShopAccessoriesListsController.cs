using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AccessoriesList>>> GetAccessoriesLists()
        {
            string baseUrl = _configuration["ImgSetting:ImgUrl"];  //用來串接圖片
            var Items = await _context.AccessoriesLists
                .Where(s => s.PActive == true)
                .ToListAsync();
            var allclass = _context.AccessoriesLists.Select(s => s.PClass).Distinct();
            var GetphotoItems = Items.Select(s => new AccessoriesListsDTO
            {
                PCode = s.PCode,
                PClass=s.PClass,
                PName=s.PName,
                PPrice=s.PPrice,
                PLevel=s.PLevel,
                PImageShop=$"{baseUrl}/images/{s.PImageShop}",
            });
            //var PageItem = GetphotoItems.ToPagedList(page, 12);

            return Ok(new { Allclass=allclass,QualifiedItem= GetphotoItems });
        }

        // GET: api/ShopAccessoriesLists/5
        [HttpGet("{id}")]
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
        [HttpPost]
        public async Task<ActionResult<AccessoriesList>> PostAccessoriesList(AccessoriesList accessoriesList)
        {
            _context.AccessoriesLists.Add(accessoriesList);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAccessoriesList", new { id = accessoriesList.PCode }, accessoriesList);
        }

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
