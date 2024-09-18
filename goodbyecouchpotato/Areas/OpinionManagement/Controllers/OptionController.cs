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

        public OptionController(GoodbyepotatoContext context)
        {
            _context = context;
        }

        // GET: OpinionManagement/Option
        public async Task<IActionResult> Index()
        {
            var feedback = await _context.Feedbacks
                .Where(f => f.ProActive == false)
            .Select(F => new Optionviewmodel
            {
                FeedbackNo = F.FeedbackNo,
                Email = F.Email,
                Content = F.Content,
                Submitted = F.Submitted,
                //ProActive = F.ProActive,
                //ProDate = F.ProDate,

            }).ToListAsync();
            return View(feedback);

        }

        public async Task<IActionResult> Index2()
        {
            var feedback = await _context.Feedbacks
                .Where(f => f.ProActive == true)
            .Select(F => new Optionviewmodel
            {
                FeedbackNo = F.FeedbackNo,
                Email = F.Email,
                Content = F.Content,
                Submitted = F.Submitted,
                //ProActive = F.ProActive,
                //ProDate = F.ProDate,

            }).ToListAsync();
            return View(feedback);

        }
        // GET: OpinionManagement/Option/Details/5
        public async Task<IActionResult> Details(int? id)
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

        // GET: OpinionManagement/Option/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: OpinionManagement/Option/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FeedbackNo,Email,Content,Submitted,ProActive,ProDate,Pro_Content")] Optionviewmodel optionviewmodel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(optionviewmodel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(optionviewmodel);
        }

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
                    _context.Update(optionviewmodel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OptionviewmodelExists(optionviewmodel.FeedbackNo))
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
            return View(optionviewmodel);
        }

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
