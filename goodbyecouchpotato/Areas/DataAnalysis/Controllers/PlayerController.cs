using goodbyecouchpotato.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace goodbyecouchpotato.Areas.DataAnalysis.Controllers
{
    [Area("DataAnalysis")]
    public class PlayerController : Controller
    {
        private readonly GoodbyepotatoContext _context;

        public PlayerController(GoodbyepotatoContext context)
        {
            _context = context;
        }

        [Authorize(Roles = "Admin")]

        public IActionResult Index()
        {
            // 角色總數
            var totalCharacters = _context.Characters.Count();

            // 平均等級
            var averageLevel = _context.Characters.Average(c => c.Level);

            // 平均體重
            var averageWeight = _context.Characters.Average(c => c.Weight);

            // 平均身高
            var averageHeight = _context.Characters.Average(c => c.Height);

            // 尚在居住人數
            var livingCount = _context.Characters.Count(c => c.LivingStatus == "居住");

            // 搬離人數
            var movedCount = _context.Characters.Count(c => c.LivingStatus == "搬離");

            // 傳送數據到 View
            ViewBag.TotalCharacters = totalCharacters;
            ViewBag.AverageLevel = averageLevel;
            ViewBag.AverageWeight = averageWeight;
            ViewBag.AverageHeight = averageHeight;
            ViewBag.LivingCount = livingCount;
            ViewBag.MovedCount = movedCount;

            return View();
        }
    }
}