using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using goodbyecouchpotato.Models;
using goodbyecouchpotato.Areas.TaskManagement.Views;
using Microsoft.Build.Framework;
using Microsoft.Identity.Client;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Authorization;
using X.PagedList;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Drawing.Printing;

namespace goodbyecouchpotato.Areas.TaskManagement.Controllers
{
    [Area("TaskManagement")]
    [Authorize]
    public class DailyTasksController : Controller
    {
        private readonly GoodbyepotatoContext _context;

        public DailyTasksController(GoodbyepotatoContext context)
        {
            _context = context;
        }

        // GET: TaskManagement/DailyTasks
        //public async Task<IActionResult> Index()
        //{
        //    return View(await _context.DailyTasks.ToListAsync());
        //      //}
        //public async Task<IActionResult> Index()
        //{
        //	return View();
        //}
        //      public JsonResult IndexJson()
        //      {
        //          return Json(_context.DailyTasks);
        //      }
        

        public async Task<IActionResult> Index()  //顯示畫面
        {
            return View();
        }

        //public JsonResult IndexJson(int page=1,int pagesize=10)  //先顯示所有資料
        //{
        //    var data = _context.DailyTasks;
        //    var datapage = data.ToPagedList(page, pagesize);

        //    return Json(new {data=datapage,totalpages=datapage.PageCount,currentpage=datapage.PageNumber});
        //}

        public IActionResult TaskSearch(_SearchViewModel searchViewModel, int page = 1)
        {
            var tasks=_context.DailyTasks.AsQueryable();
            if (!string.IsNullOrEmpty(searchViewModel.TaskName))
            {
                tasks = tasks.Where(s => s.TaskName.Contains(searchViewModel.TaskName));
            }
            if (searchViewModel.Reward.HasValue)  //int是一個可有可無值的情況下才可以使用HasValue，如果不是，則預設為0
            {
                tasks=tasks.Where(s=>s.Reward==searchViewModel.Reward);
            }
            if (searchViewModel.TaskActive != null)
            {
                tasks=tasks.Where(s=>s.TaskActive==searchViewModel.TaskActive);
            }
            if (!string.IsNullOrEmpty(searchViewModel.TReviewStatus))
            {
                tasks=tasks.Where(s=>s.TReviewStatus==searchViewModel.TReviewStatus);
            }
            var model = tasks.Select(t => new _SearchViewModel
            {
                TaskId = t.TaskId,
                TaskName = t.TaskName,
                Reward = t.Reward,
                TaskActive = t.TaskActive,
                TReviewStatus = t.TReviewStatus
            });
            var modelpage=model.ToPagedList(page, 10);

            ViewBag.currentpages= modelpage.PageNumber;
            ViewBag.totalpages= modelpage.PageCount;
            ViewBag.totaltask = model.Count();

            return PartialView("_TaskSearchPartial", modelpage);
        }

        [HttpPost]
        public  IActionResult GetTaskName(string taskname)
        {
                                            //any回傳bool值，求是否有完全相同的名字
            var result= _context.DailyTasks.Any(s=>s.TaskName==taskname);
            if (result)
            {
                return Json(new {message=true });  //如果名稱重複的話
            }
            return Json(new { message = false });
        }

        // GET: TaskManagement/DailyTasks/Details/5
        //public async Task<IActionResult> Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var dailyTask = await _context.DailyTasks
        //        .FirstOrDefaultAsync(m => m.TaskId == id);
        //    if (dailyTask == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(dailyTask);
        //}

        // GET: TaskManagement/DailyTasks/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TaskManagement/DailyTasks/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TaskId,TaskName,Reward,TaskActive,TReviewStatus")] DailyTask dailyTask)
        {
            if (ModelState.IsValid)
            {
                _context.Add(dailyTask);
                await _context.SaveChangesAsync();
                TempData["CreateTask"] = "success";
                return RedirectToAction(nameof(Index));
            }
            TempData["CreateTask"] = "error";
            return View(dailyTask);
        }

        // GET: TaskManagement/DailyTasks/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dailyTask = await _context.DailyTasks.Where(m => m.TaskId == id).Select(t => new _SearchViewModel
            {  //.Select(t => new _SearchViewModel {...}) 用來從 DailyTask 實體轉換成 _SearchViewModel 實例。這裡將 DailyTask 的屬性映射到 _SearchViewModel 的屬性中。
                TaskId = t.TaskId,
                TaskName = t.TaskName,
                Reward = t.Reward,
                TaskActive = t.TaskActive,
                TReviewStatus = t.TReviewStatus
            }
                ).FirstOrDefaultAsync(m => m.TaskId == id);

            if (dailyTask == null)
            {
                return NotFound();
            }
            return View(dailyTask);
        }

        // POST: TaskManagement/DailyTasks/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TaskId,TaskName,Reward,TaskActive,TReviewStatus")] DailyTask dailyTask)
        {
            if (id != dailyTask.TaskId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(dailyTask);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DailyTaskExists(dailyTask.TaskId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                TempData["EditTask"] = "success";
                return RedirectToAction(nameof(Index));
            }
            TempData["EditTask"] = "error";
            return View(dailyTask);
        }

        // GET: TaskManagement/DailyTasks/Delete/5
        //public async Task<IActionResult> Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var dailyTask = await _context.DailyTasks
        //        .FirstOrDefaultAsync(m => m.TaskId == id);
        //    if (dailyTask == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(dailyTask);
        //}

        // POST: TaskManagement/DailyTasks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var dailyTask = await _context.DailyTasks.FindAsync(id);
            if (dailyTask != null)
            {
                _context.DailyTasks.Remove(dailyTask);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DailyTaskExists(int id)
        {
            return _context.DailyTasks.Any(e => e.TaskId == id);
        }
    }
}
