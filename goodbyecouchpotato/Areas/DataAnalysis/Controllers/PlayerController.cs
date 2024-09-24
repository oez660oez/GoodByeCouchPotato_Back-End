using goodbyecouchpotato.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
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

            // 計算環境值的平均值，排除環境值為0的角色
            var charactersWithEnvironment = _context.Characters.Where(p => p.Environment > 0);
            var averageEnvironment = charactersWithEnvironment.Any()
                ? charactersWithEnvironment.Average(p => p.Environment) / 100
                : 0;

            // 傳送數據到 View
            ViewBag.TotalCharacters = initialStats.totalCharacters;
            ViewBag.AverageLevel = initialStats.averageLevel;
            ViewBag.AverageWeight = initialStats.averageWeight;
            ViewBag.AverageHeight = initialStats.averageHeight;
            ViewBag.LivingCount = initialStats.livingCount;
            ViewBag.MovedCount = initialStats.movedCount;
            ViewBag.AverageEnvironment = averageEnvironment;

            return View();
        }

        [HttpGet]
        public JsonResult GetProductData()
        {
            // 使用 join 連接 CharacterItems 和 AccessoriesList，並依照 P_Code 匹配
            var topProducts = (from c in _context.CharacterItems
                               join a in _context.AccessoriesLists
                               on c.PCode equals a.PCode
                               group new { c, a } by new { c.PCode, a.PName } into g
                               select new
                               {
                                   PCode = g.Key.PCode, // 保留 PCode 用於顏色選擇
                                   Name = g.Key.PName, // 取出產品名稱 (PName)
                                   Value = g.Count()
                               })
                              .OrderByDescending(g => g.Value)
                              .Take(5)
                              .ToList();

            var total = topProducts.Sum(p => p.Value);

            // 準備圖表數據
            var pieChartData = topProducts.Select((p, index) => new
            {
                name = p.Name, // 直接顯示產品名稱 (PName)
                value = p.Value,
                percentage = Math.Round((double)p.Value / total * 100, 2),
                color = GetColorForIndex(index) // 使用排名索引來決定顏色
            }).ToList();

            return Json(new { pieChartData });
        }

        private string GetColorForIndex(int index)
        {
            var colors = new List<string>
            {
                "#D1DDDB", "#85B8C8", "#1D6A96", "#034B61", "#283B42"
            };

            // 确保索引在顏色範圍內
            if (index >= 0 && index < colors.Count)
            {
                return colors[index];
            }

            // 預設顏色
            return "#000000";
        }

        [HttpGet]
        public IActionResult GetStats(DateTime startDate, DateTime endDate)
        {
            var stats = GetStatsData(startDate, endDate);
            return Json(stats);
        }

        private dynamic GetStatsData(DateTime startDate, DateTime endDate)
        {
            // 查詢角色資料
            var characters = _context.Characters.Where(c => c.MoveInDate >= startDate && c.MoveInDate <= endDate);
            if (characters.Any())
            {
                // 計算統計數據
                var totalCharacters = characters.Count();
                var averageLevel = characters.Average(c => c.Level);
                var averageWeight = Math.Round((decimal)characters.Average(c => c.Weight), 1);
                var averageHeight = Math.Round((decimal)characters.Average(c => c.Height), 1);
                var livingCount = characters.Count(c => c.LivingStatus == "居住");
                var movedCount = characters.Count(c => c.LivingStatus == "搬離");

                // 計算圖表數據
                var dates = new List<string>();
                var totalCharactersData = new List<int>();
                var averageLevelsData = new List<double>();
                var livingCountsData = new List<int>();
                var movedCountData = new List<int>();

                for (DateTime date = startDate; date <= endDate; date = date.AddDays(1))
                {
                    dates.Add(date.ToString("yyyy-MM-dd"));

                    var charactersOnDate = _context.Characters
                        .Where(c => c.MoveInDate.HasValue && c.MoveInDate.Value.Date <= date.Date);

                    var totalCharactersCount = charactersOnDate.Count();
                    var averageLevelOnDate = charactersOnDate.Any() ? charactersOnDate.Average(c => c.Level) : 0;
                    var livingCountOnDate = charactersOnDate.Count(c => c.LivingStatus == "居住");
                    var moveoutCount = _context.Characters
                        .Count(c => c.LivingStatus == "搬離" && c.MoveOutDate.HasValue && c.MoveOutDate.Value.Date <= date.Date);

                    totalCharactersData.Add(totalCharactersCount);
                    averageLevelsData.Add(Math.Round(averageLevelOnDate, 2));
                    livingCountsData.Add(livingCountOnDate);
                    movedCountData.Add(moveoutCount);
                }

                // 創建返回的數據對象
                var result = new
                {
                    totalCharacters,
                    averageLevel,
                    averageWeight,
                    averageHeight,
                    livingCount,
                    movedCount,
                    chartData = new
                    {
                        dates,
                        totalCharacters = totalCharactersData,
                        averageLevels = averageLevelsData,
                        livingCounts = livingCountsData,
                        movedCount = movedCountData
                    }
                };
                return result;
            }
            return Json(123);
        }
    }
}