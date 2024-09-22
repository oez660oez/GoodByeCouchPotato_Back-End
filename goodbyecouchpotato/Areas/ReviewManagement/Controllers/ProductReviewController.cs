using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using goodbyecouchpotato.Areas.ReviewManagement.viewmodel;
using goodbyecouchpotato.Models;
using Microsoft.AspNetCore.Authorization;

namespace goodbyecouchpotato.Areas.ReviewManagement.Controllers
{
    [Area("ReviewManagement")]
    [Authorize(Roles = "Admin,PermiGuard")]
    public class ProductReviewController : Controller
    {
        private readonly GoodbyepotatoContext _context;

        public ProductReviewController(GoodbyepotatoContext context)
        {
            _context = context;
        }

        // GET: ReviewManagement/ProductReview

        public async Task<IActionResult> Index()
        {
            var Product = await _context.AccessoriesLists
                .Where(P => P.PReviewStatus == "待複核")
                .Select(product => new ProductReviewviewmodel
                {
                    PCode = product.PCode,
                    PClass = product.PClass,
                    PName = product.PName,
                    PPrice = product.PPrice,
                    PLevel = product.PLevel,
                    PImageShop = product.PImageShop,
                    PImageAll = product.PImageAll,
                }).ToListAsync();
            return View(Product);

        }
        [HttpGet]
      
        public async Task<IActionResult> Detail(int id)
        {
            var product = await _context.AccessoriesLists.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }

            var viewModel = new ProductReviewviewmodel
            {
                PCode = product.PCode,
                PClass = product.PClass,
                PName = product.PName,
                PPrice = product.PPrice,
                PLevel = product.PLevel,
                PImageShop = product.PImageShop,
                PImageAll = product.PImageAll,

            };

            return PartialView("_Detail", viewModel);
        }




        public async Task<IActionResult> ApproveTask(int id)
        {
            var product = await _context.AccessoriesLists.FindAsync(id);
            if (product == null)
            {
                return Json(new { success = false, message = "找不到該任務" });
            }
            product.PReviewStatus = "通過";
            product.PActive = true;
            await _context.SaveChangesAsync();
            return Json(new { success = true, message = "覆核成功" });
        }

        [HttpPost]
        public async Task<IActionResult> RejectTask(int id)
        {
            var product = await _context.AccessoriesLists.FindAsync(id);
            if (product == null)
            {
                return Json(new { success = false, message = "找不到該任務" });
            }
            product.PReviewStatus = "未通過";
            product.PActive = false;
            await _context.SaveChangesAsync();

            return Json(new { success = true, message = "覆核成功" });
        }

        //// GET: ReviewManagement/ProductReview/Create
        //public IActionResult Create()
        //{
        //    return View();
        //}

        //// POST: ReviewManagement/ProductReview/Create
        //// To protect from overposting attacks, enable the specific properties you want to bind to.
        //// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create([Bind("PCode,PClass,PName,PPrice,PLevel,PImageShop,PImageAll,PActive")] ProductReviewviewmodel productReviewviewmodel)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _context.Add(productReviewviewmodel);
        //        await _context.SaveChangesAsync();
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(productReviewviewmodel);
        //}

        //// GET: ReviewManagement/ProductReview/Edit/5
        //public async Task<IActionResult> Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var productReviewviewmodel = await _context.ProductReviewviewmodel.FindAsync(id);
        //    if (productReviewviewmodel == null)
        //    {
        //        return NotFound();
        //    }
        //    return View(productReviewviewmodel);
        //}

        //// POST: ReviewManagement/ProductReview/Edit/5
        //// To protect from overposting attacks, enable the specific properties you want to bind to.
        //// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(int id, [Bind("PCode,PClass,PName,PPrice,PLevel,PImageShop,PImageAll,PActive")] ProductReviewviewmodel productReviewviewmodel)
        //{
        //    if (id != productReviewviewmodel.PCode)
        //    {
        //        return NotFound();
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            _context.Update(productReviewviewmodel);
        //            await _context.SaveChangesAsync();
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!ProductReviewviewmodelExists(productReviewviewmodel.PCode))
        //            {
        //                return NotFound();
        //            }
        //            else
        //            {
        //                throw;
        //            }
        //        }
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(productReviewviewmodel);
        //}

        //// GET: ReviewManagement/ProductReview/Delete/5
        //public async Task<IActionResult> Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var productReviewviewmodel = await _context.ProductReviewviewmodel
        //        .FirstOrDefaultAsync(m => m.PCode == id);
        //    if (productReviewviewmodel == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(productReviewviewmodel);
        //}

        //// POST: ReviewManagement/ProductReview/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(int id)
        //{
        //    var productReviewviewmodel = await _context.ProductReviewviewmodel.FindAsync(id);
        //    if (productReviewviewmodel != null)
        //    {
        //        _context.ProductReviewviewmodel.Remove(productReviewviewmodel);
        //    }

        //    await _context.SaveChangesAsync();
        //    return RedirectToAction(nameof(Index));
        //}

        //private bool ProductReviewviewmodelExists(int id)
        //{
        //    return _context.ProductReviewviewmodel.Any(e => e.PCode == id);
        //}
    }
}
