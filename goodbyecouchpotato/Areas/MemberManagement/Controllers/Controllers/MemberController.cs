using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using goodbyecouchpotato.Models;
using Microsoft.AspNetCore.Authorization;

namespace goodbyecouchpotato.Areas.MemberManagement.Controllers
{
    [Area("MemberManagement")]
    public class MemberController : Controller
    {
        private readonly GoodbyepotatoContext _context;

        public MemberController(GoodbyepotatoContext context)
        {
            _context = context;
        }

        // GET: Member/Index
        [Authorize(Roles = "Admin")]

        public IActionResult Index()
        {
            return View();
        }

        public JsonResult IndexJson()
        {
            var players = _context.Players.Select(p => new {
                account = p.account,
                email = p.email,
                playerstatus = p.playerstatus,
                coins = p.coins
            }).ToList();

            return Json(players);
        }
    }
}
