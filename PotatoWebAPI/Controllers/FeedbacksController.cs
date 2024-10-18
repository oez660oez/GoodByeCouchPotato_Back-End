using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PotatoWebAPI.Models;
using PotatoWebAPI.DTO;

namespace PotatoWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeedbacksController : ControllerBase
    {
        private readonly GoodbyepotatoContext _context;

        public FeedbacksController(GoodbyepotatoContext context)
        {
            _context = context;
        }

        // POST: api/Feedbacks
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        // 表單提交
        [HttpPost("PostFeedback")]
        public async Task<ActionResult<Feedback>> PostFeedback(FeedbackDTO feedbackDTO)
        {
            var feedback = new Feedback
            {
                Email = feedbackDTO.Email,
                Content = feedbackDTO.Content,
                Submitted = DateTime.Now,  // 這裡可以自動設置提交的時間
                ProActive = false  // 預設回復還沒處理
            };

            _context.Feedbacks.Add(feedback); 
            await _context.SaveChangesAsync();

            return Ok(new { Message = "已收到你的回饋，我們將盡速回覆" });
        }


        // POST: api/Feedbacks
        // 得到信箱
        [HttpPost]
        public async Task<ActionResult<IEnumerable<Feedback>>> Getemail([FromBody] string account)
        {
            var find = await _context.Players.FindAsync(account);
            var email = find.Email;
            return Ok(new { Message = email });
        }





        // GET: api/Feedbacks/5
        //[HttpGet("{id}")]
        //public async Task<ActionResult<Feedback>> GetFeedback(int id)
        //{
        //    var feedback = await _context.Feedbacks.FindAsync(id);

        //    if (feedback == null)
        //    {
        //        return NotFound();
        //    }

        //    return feedback;
        //}

        // PUT: api/Feedbacks/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutFeedback(int id, Feedback feedback)
        //{
        //    if (id != feedback.FeedbackNo)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(feedback).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!FeedbackExists(id))
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

        

        // DELETE: api/Feedbacks/5
        //[HttpDelete("{id}")]
        //public async Task<IActionResult> DeleteFeedback(int id)
        //{
        //    var feedback = await _context.Feedbacks.FindAsync(id);
        //    if (feedback == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.Feedbacks.Remove(feedback);
        //    await _context.SaveChangesAsync();

        //    return NoContent();
        //}

        //private bool FeedbackExists(int id)
        //{
        //    return _context.Feedbacks.Any(e => e.FeedbackNo == id);
        //}
    }
}
