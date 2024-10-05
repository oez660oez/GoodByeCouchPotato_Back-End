using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using goodbyecouchpotato.Models;
using goodbyecouchpotato.Areas.MemberManagement.ViewModels;
using Microsoft.AspNetCore.Authorization;

namespace goodbyecouchpotato.Areas.MemberManagement.Controllers
{
    [Area("MemberManagement")]
    [Authorize]
    public class MemberController : Controller
    {
        private readonly GoodbyepotatoContext _context;

        public MemberController(GoodbyepotatoContext context)
        {
            _context = context;
        }

        // GET: Member/Index
        public IActionResult Index()
        {
            return View();
        }

        public JsonResult IndexJson()
        {
            var players = _context.Players.Select(p => new {
                Account = p.Account,
                Email = p.Email,
                Playerstatus = p.Playerstatus ? "已開通" : p.Playerstatus == false ? "未開通" : "未知",
            }).ToList();

            return Json(players);
        }
    }
}