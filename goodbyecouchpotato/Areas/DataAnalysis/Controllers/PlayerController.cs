using goodbyecouchpotato.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace goodbyecouchpotato.Areas.DataAnalysis.Controllers
{
    [Area("DataAnalysis")]
    [Authorize]
    public class PlayerController : Controller
    {
        private readonly GoodbyepotatoContext _context;

        public PlayerController(GoodbyepotatoContext context)
        {
            _context = context;
        }

        
        public IActionResult Index()
        {
            // 設置預設的日期範圍
            var endDate = DateTime.Now;
            var startDate = new DateTime(endDate.Year, endDate.Month, 1).AddMonths(-1);

            // 獲取初始統計數據
            var initialStats = GetStatsData(startDate, endDate);

            // 傳送數據到 View
            ViewBag.TotalCharacters = initialStats.TotalCharacters;
            ViewBag.AverageLevel = initialStats.AverageLevel;
            ViewBag.AverageWeight = initialStats.AverageWeight;
            ViewBag.AverageHeight = initialStats.AverageHeight;
            ViewBag.LivingCount = initialStats.LivingCount;
            ViewBag.MovedCount = initialStats.MovedCount;

            return View();
        }

        [HttpGet]
        public IActionResult GetStats(DateTime startDate, DateTime endDate)
        {
            var stats = GetStatsData(startDate, endDate);
            return Json(stats);
        }

        private dynamic GetStatsData(DateTime startDate, DateTime endDate)
        {
            var characters = _context.Characters.Where(c => c.MoveInDate >= startDate && c.MoveInDate <= endDate);

            return new
            {
                TotalCharacters = characters.Count(),
                AverageLevel = characters.Average(c => c.Level),
                AverageWeight = Math.Round((decimal)characters.Average(c => c.Weight), 1),
                AverageHeight = Math.Round((decimal)characters.Average(c => c.Height), 1),
                LivingCount = characters.Count(c => c.LivingStatus == "居住"),
                MovedCount = characters.Count(c => c.LivingStatus == "搬離")
            };
        }
    }
}