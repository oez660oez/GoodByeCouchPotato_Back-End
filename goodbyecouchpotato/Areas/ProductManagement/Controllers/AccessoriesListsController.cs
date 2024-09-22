using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using goodbyecouchpotato.Models;
using Microsoft.AspNetCore.Authorization;
using goodbyecouchpotato.Areas.ProductManagement.Views;
using goodbyecouchpotato.Areas.TaskManagement.Views;

namespace goodbyecouchpotato.Areas.ProductManagement.Controllers
{
    [Area("ProductManagement")]
    public class AccessoriesListsController : Controller
    {
        private readonly GoodbyepotatoContext _context;

        public AccessoriesListsController(GoodbyepotatoContext context)
        {
            _context = context;
        }

        // GET: ProductManagement/AccessoriesLists
        public _AccessoriesViewModel transViewmodel(AccessoriesList c)
        {
            return new _AccessoriesViewModel
            {
                PName = c.PName,
                PClass = c.PClass,
                PPrice = c.PPrice,
                PCode = c.PCode,
                PLevel = c.PLevel,
                PReviewStatus = c.PReviewStatus,
                PActive = c.PActive,
                PImageShop = c.PImageShop,
                PImageAll = c.PImageAll
            };
        }
        public async Task<IActionResult> Index()
        {
            var accessoriesList = _context.AccessoriesLists.ToList();
            if (accessoriesList == null)
            {
                return NotFound();
            }

            // 將 AccessoriesList 轉換成 ViewModel
            var viewModelList = accessoriesList.Select(c => new _AccessoriesViewModel
            {
                PName = c.PName,
                PClass = c.PClass,
                PPrice = c.PPrice,
                PCode = c.PCode,
                PLevel = c.PLevel,
                PReviewStatus = c.PReviewStatus,
                PActive = c.PActive,
                PImageShop = c.PImageShop,
                PImageAll = c.PImageAll
            }).ToList();
            return View(viewModelList);
        }

        //Upload Image 
        private async Task ReadUploadImage(string Image, AccessoriesList accessoriesList)
        {
            var file = Request.Form.Files[Image];

            // 生成唯一的檔案名稱以避免名稱衝突
            var uniqueFileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);

            // 定義圖片保存的路徑
            var savePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images", uniqueFileName);

            // 確保目錄存在
            if (!Directory.Exists(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images")))
            {
                Directory.CreateDirectory(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images"));
            }

            // 將圖片保存到伺服器
            using (var stream = new FileStream(savePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            // 將圖片的相對路徑保存到資料庫
            if (Image == "PImageShop")
            {
                accessoriesList.PImageShop = "/images/" + uniqueFileName;
            }
            else if (Image == "PImageAll")
            {
                accessoriesList.PImageAll = "/images/" + uniqueFileName;
            }
        }

        //GET: AccessoriesLists/Index
  //      public IActionResult Index()
		//{
		//	return View();
		//}

		//GET:AccessoriesLists/Json
		public JsonResult IndexJson()
		{
            return Json(_context.AccessoriesLists);
		}

        //[HttpPost]
        //public async Task<IActionResult> DeactivateProduct(int id)
        //{
        //    // 查找商品
        //    if (id == null)
        //    {
        //        return NotFound();  // 如果找不到該商品，返回 404
        //    }
        //   AccessoriesList? c = await _context.AccessoriesLists.FindAsync(id);

        //    // 將商品設置為下架狀態
        //    c.PActive = false;

        //    // 保存更改
        //    _context.Update(c);
        //    await _context.SaveChangesAsync();

        //    return Ok(new { message = "商品已成功下架" });
        //}



        //取得檔案路徑
        public async Task<IActionResult> GetPicture(int id)
        {
            AccessoriesList? c = await _context.AccessoriesLists.FindAsync(id);
            if (c == null || string.IsNullOrEmpty(c.PImageShop))
            {
                return NotFound();
            }
            _AccessoriesViewModel viewmodel=transViewmodel(c);

            string ImagePath= Path.Combine(Directory.GetCurrentDirectory(), "/images", viewmodel.PImageShop);
            return File(ImagePath, "image/png");
        }

        public async Task<IActionResult> GetPictureAll(int id)
        {
            AccessoriesList? c = await _context.AccessoriesLists.FindAsync(id);
            if (c == null || string.IsNullOrEmpty(c.PImageShop))
            {
                return NotFound();
            }
            _AccessoriesViewModel viewmodel = transViewmodel(c);
            string ImagePath = Path.Combine(Directory.GetCurrentDirectory(), "/images", viewmodel.PImageAll);
            return File(ImagePath, "image/png");
        }

        // GET: ProductManagement/AccessoriesLists/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.AccessoriesLists == null)
            {
                return NotFound();
            }

            // 查 AccessoriesList 對象 
            var accessoriesList = await _context.AccessoriesLists.FindAsync(id);
            if (accessoriesList == null)
            {
                return NotFound();
            }

            // 將 AccessoriesList 轉換成 ViewModel
            _AccessoriesViewModel viewModel=transViewmodel(accessoriesList);

            return View(viewModel);
        }

        // GET: ProductManagement/AccessoriesLists/Create
        public IActionResult Create()
        {
            var list = new _AccessoriesViewModel  //預設值
            {
                PReviewStatus = "待複核",
            };
            return View(list);
        }

        // POST: ProductManagement/AccessoriesLists/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PCode,PClass,PName,PPrice,PLevel,PImageShop,PImageAll,PActive,PReviewStatus")] AccessoriesList accessoriesList)
        {

            if (ModelState.IsValid)
            {
                if (Request.Form.Files["PImageShop"] != null)
                { 
                    await ReadUploadImage("PImageShop",accessoriesList);
                }

                // 處理第二個圖片欄位 PImageAll
                if (Request.Form.Files["PImageAll"] != null )
                {
                    await ReadUploadImage("PImageAll",accessoriesList);
                }

                _context.Add(accessoriesList);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(accessoriesList);
        }

        // GET: ProductManagement/AccessoriesLists/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var accessoriesList = await _context.AccessoriesLists.Select(c => new AccessoriesList
            {
                PName = c.PName,
                PClass = c.PClass,
                PPrice = c.PPrice,
                PCode = c.PCode,
                PLevel=c.PLevel,
                PReviewStatus = c.PReviewStatus,
                PActive = c.PActive,
                PImageShop =null,
                PImageAll = null,
            })
                .FirstOrDefaultAsync(m => m.PCode == id);
            if (accessoriesList == null)
            {
                return NotFound();
            }
            _AccessoriesViewModel viewModel = transViewmodel(accessoriesList);
            return View(viewModel);
        }

        // POST: ProductManagement/AccessoriesLists/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PCode,PClass,PName,PPrice,PLevel,PImageShop,PImageAll,PActive,PReviewStatus")] AccessoriesList accessoriesList)
        {
            if (id != accessoriesList.PCode)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    // 查詢現有的 AccessoriesList 物件
                    AccessoriesList c = await _context.AccessoriesLists.FindAsync(accessoriesList.PCode);
                    if (c == null)
                    {
                        return NotFound();
                    }

                    // 處理第一個圖片欄位 PImageShop
                    if (Request.Form.Files["PImageShop"] != null && Request.Form.Files["PImageShop"].Length > 0)
                    {
                        await ReadUploadImage("PImageShop", accessoriesList);
                    }
                    else
                    {
                        // 如果沒有上傳新圖片，保留現有的圖片路徑
                        accessoriesList.PImageShop = c.PImageShop;
                    }

                    // 處理第二個圖片欄位 PImageAll
                    if (Request.Form.Files["PImageAll"] != null && Request.Form.Files["PImageAll"].Length > 0)
                    {
                        await ReadUploadImage("PImageAll", accessoriesList);
                    }
                    else
                    {
                        // 如果沒有上傳新圖片，保留現有的圖片路徑
                        accessoriesList.PImageAll = c.PImageAll;
                    }

                    // 將查詢出的實體從追蹤中分離，避免多重追蹤的衝突
                    _context.Entry(c).State = EntityState.Detached;

                    // 更新資料庫中的 AccessoriesList 物件
                    _context.Update(accessoriesList);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AccessoriesListExists(accessoriesList.PCode))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }

            return View(accessoriesList);
        }

        // GET: ProductManagement/AccessoriesLists/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var accessoriesList = await _context.AccessoriesLists.FirstOrDefaultAsync(m => m.PCode == id);
            if (accessoriesList == null)
            {
                return NotFound();
            }

            return View(accessoriesList);
        }

        // POST: ProductManagement/AccessoriesLists/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var accessoriesList = await _context.AccessoriesLists.FindAsync(id);
            if (accessoriesList != null)
            {
                _context.AccessoriesLists.Remove(accessoriesList);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AccessoriesListExists(int id)
        {
            return _context.AccessoriesLists.Any(e => e.PCode == id);
        }
    }
}
