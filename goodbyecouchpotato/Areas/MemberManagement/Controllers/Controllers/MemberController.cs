using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using goodbyecouchpotato.Models;

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
        public IActionResult Index()
        {
            return View();
        }

        public JsonResult IndexJson()
        {
            return Json(_context.Players);
        }
    }
}
