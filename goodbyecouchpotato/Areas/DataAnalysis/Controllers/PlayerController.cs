using goodbyecouchpotato.Models;
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

        public async Task<IActionResult> ECharts()
        {
            // 获取玩家 coins 的区间分布，比如 <1000, 1000-5000, >5000
            var coinGroups = await _context.Players
                .GroupBy(p => new
                {
                    CoinRange = p.Coins < 50 ? "<50" :
                                p.Coins > 100 ? "50-100" : ">100"
                })
                .Select(g => new
                {
                    Range = g.Key.CoinRange,
                    Count = g.Count()
                })
                .ToListAsync();

            // 设置 ECharts 配置
            var options = $@"{{
                                xAxis: {{
                                    type: 'category',
                                    data: {JsonSerializer.Serialize(coinGroups.Select(g => g.Range))}
                                }},
                                yAxis: {{
                                    type: 'value'
                                }},
                                series: [{{
                                    data: {JsonSerializer.Serialize(coinGroups.Select(g => g.Count))},
                                    type: 'bar'
                                }}]
                          }}";
            ViewBag.Options = options;
            return View();
        }
    }
}
