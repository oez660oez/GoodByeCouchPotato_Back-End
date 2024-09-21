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
        public async Task<IActionResult> ECharts()
        {
            // 獲取玩家 coins 的區間，比如 <50, 50-100, >100
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

            // 獲取 Character 的 MoveInDate 和總人數數據
            var characterData = await _context.Characters
                .GroupBy(c => c.MoveInDate)
                .Select(g => new
                {
                    Date = g.Key,
                    Count = g.Count()
                })
                .ToListAsync();

            // 設置折線圖配置
            var playerOptions = $@"{{
                                xAxis: {{
                                    type: 'category',
                                    data: {JsonSerializer.Serialize(coinGroups.Select(g => g.Range))}
                                }},
                                yAxis: {{
                                    type: 'value'
                                }},
                                series: [{{
                                    data: {JsonSerializer.Serialize(coinGroups.Select(g => g.Count))},
                                    type: 'bar',
                                    name: 'Coin Distribution'
                                }}]
                          }}";

            // 設置折線圖數據
            // areaStyle開啟面積填充與自訂顏色
            // itemStyle自訂折線顏色
            var characterOptions = $@"{{
                                    xAxis: {{
                                        type: 'category',
                                        boundaryGap: false,
                                        data: {JsonSerializer.Serialize(characterData.Select(c => c.Date.HasValue ? c.Date.Value.ToShortDateString() : "Unknown"))}
                                    }},
                                    yAxis: {{
                                        type: 'value'
                                    }},
                                    series: [{{
                                        data: {JsonSerializer.Serialize(characterData.Select(c => c.Count))},
                                        type: 'line',
                                        areaStyle: {{}},
                                        itemStyle: {{
                                            color: '#ff7f50'
                                        }},
                                        lineStyle: {{
                                            color: '#ff7f50'
                                        }},
                                        areaStyle: {{
                                            color: 'rgba(255,127,80, 0.5)'
                                        }}
                                    }}]
                                }}";

            ViewBag.PlayerOptions = playerOptions;
            ViewBag.CharacterOptions = characterOptions;
            return View();
        }
    }
}
