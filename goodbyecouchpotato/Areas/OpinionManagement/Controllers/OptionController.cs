using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using goodbyecouchpotato.Areas.OpinionManagement.viewmodel;
using goodbyecouchpotato.Models;


namespace goodbyecouchpotato.Areas.OpinionManagement.Controllers
{
    [Area("OpinionManagement")]
    public class OptionController : Controller
    {
        private readonly GoodbyepotatoContext _context;
        private readonly MailService _mailService;

        public OptionController(GoodbyepotatoContext context , MailService mailService)
        {
            _context = context;
            _mailService = mailService;
        }

        // GET: OpinionManagement/Option
        public async Task<IActionResult> Index(string search)
        {
            var feedbacksearch = _context.Feedbacks.Where(f => f.ProActive == false);
            if (search == null) {
                feedbacksearch = _context.Feedbacks.Where(f => f.ProActive == false);
            }
            else
            {
                DateTime searchDate;
                bool isdate = DateTime.TryParse(search, out searchDate);

                if (isdate) {
                feedbacksearch = _context.Feedbacks.Where(f =>
                f.ProActive == false &&
                f.Submitted.Month == searchDate.Month && f.Submitted.Day == searchDate.Day);
                }
                else {
                    feedbacksearch = _context.Feedbacks.Where(f =>
                f.ProActive == false &&
                f.Email.Contains(search));
                }
            }

            var feedback = await feedbacksearch.Select(F => new Optionviewmodel
            {
                FeedbackNo = F.FeedbackNo,
                Email = F.Email,
                Content = F.Content,
                Submitted = F.Submitted,
                //ProActive = F.ProActive,
                //ProDate = F.ProDate,

            }).ToListAsync();
            ViewData["inputword"] = search;
            return View(feedback);

        }

        public async Task<IActionResult> Index2(string search)
        {
            var feedbacksearch = _context.Feedbacks.Where(f => f.ProActive == true);
            if (search == null)
            {
                feedbacksearch = _context.Feedbacks.Where(f => f.ProActive == true);
            }
            else
            {
                DateTime searchDate;
                bool isdate = DateTime.TryParse(search, out searchDate);

                if (isdate)
                {
                    feedbacksearch = _context.Feedbacks.Where(f =>
                    f.ProActive == true &&
                    ((f.Submitted.Month == searchDate.Month && f.Submitted.Day == searchDate.Day) ||
                    (f.ProDate.HasValue && f.ProDate.Value.Month == searchDate.Month && f.ProDate.Value.Day == searchDate.Day)));
                }
                else
                {
                    feedbacksearch = _context.Feedbacks.Where(f =>
                f.ProActive == true &&
                f.Email.Contains(search));
                }
            }

            var feedback = await feedbacksearch.Select(F => new Optionviewmodel
            {
                FeedbackNo = F.FeedbackNo,
                Email = F.Email,
                Content = F.Content,
                Submitted = F.Submitted,
                //ProActive = F.ProActive,
                ProDate = F.ProDate,

            }).ToListAsync();
            ViewData["inputword"] = search;
            return View(feedback);

        }

        

        //}
        // GET: OpinionManagement/Option/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var Detail = await _context.Feedbacks
                .Where(m => m.FeedbackNo == id)
                .Select(f => new Optionviewmodel
                {
                    FeedbackNo = f.FeedbackNo,
                    Email = f.Email,
                    Content = f.Content,
                    Submitted = f.Submitted,
                    ProActive = f.ProActive,
                    ProDate = f.ProDate,
                })
                .FirstOrDefaultAsync();

            if (Detail == null)
            {
                return NotFound();
            }

            return View(Detail);
        }

        // GET: OpinionManagement/Option/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: OpinionManagement/Option/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create([Bind("FeedbackNo,Email,Content,Submitted,ProActive,ProDate,Pro_Content")] Optionviewmodel optionviewmodel)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _context.Add(optionviewmodel);
        //        await _context.SaveChangesAsync();
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(optionviewmodel);
        //}

        // GET: OpinionManagement/Option/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var feedback = await _context.Feedbacks
                .Where(f => f.FeedbackNo == id)
                .Select(f => new Optionviewmodel
                {
                    FeedbackNo = f.FeedbackNo,
                    Email = f.Email,
                    Content = f.Content,
                    Submitted = f.Submitted,
                    ProActive = f.ProActive,
                    ProDate = f.ProDate,
                })
                .FirstOrDefaultAsync();

            if (feedback == null)
            {
                return NotFound();
            }

            return View(feedback);
        }

        // POST: OpinionManagement/Option/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("FeedbackNo,Email,Content,Submitted,ProActive,ProDate,Pro_Content")] Optionviewmodel optionviewmodel)
        {
            
            if (id != optionviewmodel.FeedbackNo)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    // 找到資料庫中的反饋記錄
                    var feedback = await _context.Feedbacks.FindAsync(id);
                    if (feedback == null)
                    {
                        return NotFound();
                    }


                    // 更新反饋內容
                    feedback.FeedbackNo = optionviewmodel.FeedbackNo;
                    feedback.Email = optionviewmodel.Email;                            
                    feedback.Content = optionviewmodel.Content;
                    feedback.Submitted = optionviewmodel.Submitted;
                    var date= DateTime.Now;
                    feedback.ProDate = date;
                    feedback.ProActive = true;
                    feedback.Pro_Content = optionviewmodel.Pro_Content; 

                    // 更新資料庫
                    _context.Update(feedback);
                    await _context.SaveChangesAsync();

                    // 發送回覆郵件給反饋者
                    string subject = "回覆您的意見回饋";
                    string message = $"<p>親愛的用戶：</p><p>謝謝您的意見回饋：</p><p>{optionviewmodel.Content}。</p><p>我們的回覆如下：</p><p>{optionviewmodel.Pro_Content}</p><p>敬祝順利</p><p>byepotato團隊</p>";

                    await _mailService.SendEmailAsync(optionviewmodel.Email, subject, message);

                    // 返回列表頁面
                    return RedirectToAction(nameof(Index));
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FeedbackExists(optionviewmodel.FeedbackNo))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
            }
            return View(optionviewmodel);
        }

        private bool FeedbackExists(int id)
        {
            return _context.Feedbacks.Any(e => e.FeedbackNo == id);
        }
        //if (id != optionviewmodel.FeedbackNo)
        //{
        //    return NotFound();
        //}

        //if (ModelState.IsValid)
        //{
        //    try
        //    {
        //        _context.Update(optionviewmodel);
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!OptionviewmodelExists(optionviewmodel.FeedbackNo))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }
        //    return RedirectToAction(nameof(Index));
        //}
        //return View(optionviewmodel);



        // GET: OpinionManagement/Option/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var optionviewmodel = await _context.Optionviewmodel
                .FirstOrDefaultAsync(m => m.FeedbackNo == id);
            if (optionviewmodel == null)
            {
                return NotFound();
            }

            return View(optionviewmodel);
        }

        // POST: OpinionManagement/Option/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var optionviewmodel = await _context.Optionviewmodel.FindAsync(id);
            if (optionviewmodel != null)
            {
                _context.Optionviewmodel.Remove(optionviewmodel);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OptionviewmodelExists(int id)
        {
            return _context.Optionviewmodel.Any(e => e.FeedbackNo == id);
        }
    }
}
