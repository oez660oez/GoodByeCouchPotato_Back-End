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

    public class TASKReviewController : Controller
    {
        private readonly GoodbyepotatoContext _context;

        public TASKReviewController(GoodbyepotatoContext context)
        {
            _context = context;
        }

        // GET: ReviewManagement/TASKReview
        

        public async Task<IActionResult> Index()
        {
            var TASK = await _context.DailyTasks
                 .Where(T => T.TReviewStatus == "待複核")
                 .Select(task => new TASKReviewviewmodel
                 {
                     TaskID = task.TaskId,
                     TaskName = task.TaskName,
                     Reward = task.Reward,
                     TaskActive = task.TaskActive
                 }).ToListAsync();
            return View(TASK);
        }

        [HttpGet]
        public async Task<IActionResult> GetTaskDetails(int id)
        {
            var task = await _context.DailyTasks.FindAsync(id);
            if (task == null)
            {
                return NotFound();
            }

            var viewModel = new TASKReviewviewmodel
            {
                TaskID = task.TaskId,
                TaskName = task.TaskName,
                Reward = task.Reward,
                TaskActive = task.TaskActive,

            };

            return PartialView("_TaskDetails", viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> ApproveTask(int id)
        {
            var task = await _context.DailyTasks.FindAsync(id);
            if (task == null)
            {
                return Json(new { success = false, message = "找不到該任務" });
            }
            task.TReviewStatus = "通過";
            task.TaskActive = true;
            await _context.SaveChangesAsync();
            return Json(new { success = true, message = "覆核成功" });
        }

        [HttpPost]
        public async Task<IActionResult> RejectTask(int id)
        {
            var task = await _context.DailyTasks.FindAsync(id);
            if (task == null)
            {
                return Json(new { success = false, message = "找不到該任務" });
            }
            task.TReviewStatus = "未通過";
            task.TaskActive = false;
            await _context.SaveChangesAsync();

            return Json(new { success = true, message = "覆核成功" });
        }



    }
}




//        // GET: ReviewManagement/TASKReview/Details/5
//        public async Task<IActionResult> Details(int? id)
//        {
//            if (id == null)
//            {
//                return NotFound();
//            }

//            var tASKReviewviewmodel = await _context.TASKReviewviewmodel
//                .FirstOrDefaultAsync(m => m.TaskID == id);
//            if (tASKReviewviewmodel == null)
//            {
//                return NotFound();
//            }

//            return View(tASKReviewviewmodel);
//        }

//        // GET: ReviewManagement/TASKReview/Create
//        public IActionResult Create()
//        {
//            return View();
//        }

//        // POST: ReviewManagement/TASKReview/Create
//        // To protect from overposting attacks, enable the specific properties you want to bind to.
//        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> Create([Bind("TaskID,TaskName,Reward,TaskActive")] TASKReviewviewmodel tASKReviewviewmodel)
//        {
//            if (ModelState.IsValid)
//            {
//                _context.Add(tASKReviewviewmodel);
//                await _context.SaveChangesAsync();
//                return RedirectToAction(nameof(Index));
//            }
//            return View(tASKReviewviewmodel);
//        }

//        // GET: ReviewManagement/TASKReview/Edit/5
//        public async Task<IActionResult> Edit(int? id)
//        {
//            if (id == null)
//            {
//                return NotFound();
//            }

//            var tASKReviewviewmodel = await _context.TASKReviewviewmodel.FindAsync(id);
//            if (tASKReviewviewmodel == null)
//            {
//                return NotFound();
//            }
//            return View(tASKReviewviewmodel);
//        }

//        // POST: ReviewManagement/TASKReview/Edit/5
//        // To protect from overposting attacks, enable the specific properties you want to bind to.
//        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> Edit(int id, [Bind("TaskID,TaskName,Reward,TaskActive")] TASKReviewviewmodel tASKReviewviewmodel)
//        {
//            if (id != tASKReviewviewmodel.TaskID)
//            {
//                return NotFound();
//            }

//            if (ModelState.IsValid)
//            {
//                try
//                {
//                    _context.Update(tASKReviewviewmodel);
//                    await _context.SaveChangesAsync();
//                }
//                catch (DbUpdateConcurrencyException)
//                {
//                    if (!TASKReviewviewmodelExists(tASKReviewviewmodel.TaskID))
//                    {
//                        return NotFound();
//                    }
//                    else
//                    {
//                        throw;
//                    }
//                }
//                return RedirectToAction(nameof(Index));
//            }
//            return View(tASKReviewviewmodel);
//        }

//        // GET: ReviewManagement/TASKReview/Delete/5
//        public async Task<IActionResult> Delete(int? id)
//        {
//            if (id == null)
//            {
//                return NotFound();
//            }

//            var tASKReviewviewmodel = await _context.TASKReviewviewmodel
//                .FirstOrDefaultAsync(m => m.TaskID == id);
//            if (tASKReviewviewmodel == null)
//            {
//                return NotFound();
//            }

//            return View(tASKReviewviewmodel);
//        }

//        // POST: ReviewManagement/TASKReview/Delete/5
//        [HttpPost, ActionName("Delete")]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> DeleteConfirmed(int id)
//        {
//            var tASKReviewviewmodel = await _context.TASKReviewviewmodel.FindAsync(id);
//            if (tASKReviewviewmodel != null)
//            {
//                _context.TASKReviewviewmodel.Remove(tASKReviewviewmodel);
//            }

//            await _context.SaveChangesAsync();
//            return RedirectToAction(nameof(Index));
//        }

//        private bool TASKReviewviewmodelExists(int id)
//        {
//            return _context.TASKReviewviewmodel.Any(e => e.TaskID == id);
//        }
//    }
//}
