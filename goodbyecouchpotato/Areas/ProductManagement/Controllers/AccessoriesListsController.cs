using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using goodbyecouchpotato.Models;
using Microsoft.AspNetCore.Authorization;
using goodbyecouchpotato.Areas.ProductManagement.Views;
using goodbyecouchpotato.Areas.TaskManagement.Views;
using Microsoft.AspNetCore.Hosting;

namespace goodbyecouchpotato.Areas.ProductManagement.Controllers
{
    [Area("ProductManagement")]
    [Authorize]
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
        public async Task<IActionResult> Index(int page = 1, int pageSize = 10)
        {
            var totalItems = await _context.AccessoriesLists.CountAsync(); // 計算總數
            var accessoriesList = await _context.AccessoriesLists
                .OrderBy(c => c.PName) // 按名稱排序
                .Skip((page - 1) * pageSize) // 跳過前面的頁數
                .Take(pageSize) // 取該頁資料
                .ToListAsync();

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

            // 計算總頁數
            ViewBag.TotalPages = (int)Math.Ceiling((double)totalItems / pageSize);
            ViewBag.CurrentPage = page;

            return View(viewModelList);
        }


        //局部檢視
        public IActionResult Search(string searchName = "", string searchClass = "", string searchLevel = "", string searchActive = "", string searchStatus = "",  int page = 1, int pageSize = 10)
        {
            var query = _context.AccessoriesLists.AsQueryable();

            // 根據搜尋條件篩選資料
            if (!string.IsNullOrEmpty(searchName))
            {
                query = query.Where(c => c.PName.Contains(searchName));
            }

            if (!string.IsNullOrEmpty(searchClass))
            {
                query = query.Where(c => c.PClass == searchClass);
            }

            if (!string.IsNullOrEmpty(searchLevel) && int.TryParse(searchLevel, out int level))
            {
                query = query.Where(c => c.PLevel == level);
            }

            // Active 狀態搜尋
            if (!string.IsNullOrEmpty(searchActive))
            {
                bool isActive = searchActive == "active";
                query = query.Where(c => c.PActive == isActive);
            }

            // Status 狀態搜尋
            if (!string.IsNullOrEmpty(searchStatus))
            {
                query = query.Where(c => c.PReviewStatus == searchStatus);
            }

            // 計算符合篩選條件的總數
            var totalItems = query.Count();

            // 分頁
            var pagedItems = query
                .OrderBy(a => a.PName)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToList();

            var viewModelList = pagedItems.Select(c => new _AccessoriesViewModel
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

            // 計算總頁數
            var totalPages = (int)Math.Ceiling((double)totalItems / pageSize);

            // 將符合條件的總筆數和分頁資訊傳遞給 ViewBag
            ViewBag.TotalPages = totalPages;
            ViewBag.CurrentPage = page;
            ViewBag.TotalItems = totalItems; // 總資料筆數

            return PartialView("_AccessoriesListPartial", viewModelList);
        }

        //Upload Image 
        private async Task ReadUploadImage(string Image, AccessoriesList accessoriesList)
        {
            var file = Request.Form.Files[Image];


            // 定義圖片保存的路徑
            var savePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images", file.FileName);

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
                accessoriesList.PImageShop = file.FileName;
            }
            else if (Image == "PImageAll")
            {
                accessoriesList.PImageAll = file.FileName;
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

            _AccessoriesViewModel viewmodel = transViewmodel(c);

            // 使用相對路徑，從 wwwroot/images 中尋找圖片
            string ImagePath = Path.Combine("wwwroot", "images", viewmodel.PImageShop);

            // 如果檔案不存在，返回預設圖片 NoImage.png
            if (!System.IO.File.Exists(ImagePath))
            {
                ImagePath = Path.Combine("wwwroot", "images", "NoImage.png");
            }

            var imageFileStream = System.IO.File.OpenRead(ImagePath);
            return File(imageFileStream, "image/png");
        }

        public async Task<IActionResult> GetPictureAll(int id)
        {
            AccessoriesList? c = await _context.AccessoriesLists.FindAsync(id);
            if (c == null || string.IsNullOrEmpty(c.PImageAll))
            {
                return NotFound();
            }

            _AccessoriesViewModel viewmodel = transViewmodel(c);

            // 使用相對路徑，從 wwwroot/images 中尋找圖片
            string ImagePath = Path.Combine("wwwroot", "images", viewmodel.PImageAll);

            // 如果檔案不存在，返回預設圖片 NoImage.png
            if (!System.IO.File.Exists(ImagePath))
            {
                ImagePath = Path.Combine("wwwroot", "images", "NoImage.png");
            }

            var imageFileStream = System.IO.File.OpenRead(ImagePath);
            return File(imageFileStream, "image/png");
        }

        //檢查圖片是否存在
        //public IActionResult CheckImage(string imageFile)
        //{
        //    string filePath = Path.Combine(Directory.GetCurrentDirectory(), "images", imageFile);
        //    if (!System.IO.File.Exists(imageFile))
        //    {
        //        // 如果檔案不存在，可以回傳一個預設圖片或錯誤訊息
        //        return t;
        //    }

        //}


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
                TempData["CreateProduct"] = "success";
                return RedirectToAction(nameof(Index));
            }
            TempData["CreateProduct"] = "error";
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
                TempData["EditProduct"] = "success";
                return RedirectToAction(nameof(Index));
            }
            TempData["EditProduct"] = "error";
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
