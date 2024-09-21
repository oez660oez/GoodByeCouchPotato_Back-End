using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using goodbyecouchpotato.Models;
using Microsoft.AspNetCore.Identity;
using goodbyecouchpotato.Areas.AdministratorManagement.Views;

namespace goodbyecouchpotato.Areas.AdministratorManagement.Controllers
{
    [Area("AdministratorManagement")]
    public class AdministratorsController : Controller
    {
        //private readonly GoodbyepotatoContext _context;

        //public AdministratorsController(GoodbyepotatoContext context)
        //{
        //    _context = context;
        //}
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        // 合併構造函數
        public AdministratorsController(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager = null)
        {
            _userManager = userManager;
            _roleManager = roleManager;  // roleManager 可以是可選的
        }
        public async Task<IActionResult> Index()
        {
            // 查詢所有用戶
            var users = await _userManager.Users.ToListAsync(); // 使用異步查詢

            // 查詢所有角色
            var allRoles = await _roleManager.Roles.ToListAsync();

            // 創建 ViewModel 列表來保存結果
            List<AdminViewModel> adminViewModels = new List<AdminViewModel>();

            foreach (var user in users)
            {
                // 查詢該用戶的角色
                var roles = await _userManager.GetRolesAsync(user);

                var adminViewModel = new AdminViewModel
                {
                    UserId = user.Id,
                    UserName = user.UserName,
                    Email = user.Email,
                    Roles = roles.Select(role =>
                    {
                        var matchedRole = allRoles.FirstOrDefault(r => r.Name == role);
                        return new AdminViewModel.RoleInfo
                        {
                            RoleId = matchedRole?.Id, // 加上安全檢查
                            RoleName = role
                        };
                    }).ToList()
                };

                adminViewModels.Add(adminViewModel);
            }

            // 將 ViewModel 傳遞給視圖
            return View(adminViewModels);
        }
    }
}


        // GET: AdministratorManagement/Administrators
        //public async Task<IActionResult> Index()
        //{
        //    return View(await _context.Administrators.ToListAsync());
        //}

        // GET: AdministratorManagement/Administrators/Details/5
        //public async Task<IActionResult> Details(string id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var administrator = await _context.Administrators
        //        .FirstOrDefaultAsync(m => m.AAccount == id);
        //    if (administrator == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(administrator);
        //}

        // GET: AdministratorManagement/Administrators/Create
        //public IActionResult Create()
        //{
        //    return View();
        //}

        // POST: AdministratorManagement/Administrators/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create([Bind("AAccount,APassword,MDailyTask,MProduct,MAdministrator")] Administrator administrator)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _context.Add(administrator);
        //        await _context.SaveChangesAsync();
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(administrator);
        //}

        // GET: AdministratorManagement/Administrators/Edit/5
        //public async Task<IActionResult> Edit(string id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var administrator = await _context.Administrators.FindAsync(id);
        //    if (administrator == null)
        //    {
        //        return NotFound();
        //    }
        //    return View(administrator);
        //}

        // POST: AdministratorManagement/Administrators/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(string id, [Bind("AAccount,APassword,MDailyTask,MProduct,MAdministrator")] Administrator administrator)
        //{
        //    if (id != administrator.AAccount)
        //    {
        //        return NotFound();
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            _context.Update(administrator);
        //            await _context.SaveChangesAsync();
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!AdministratorExists(administrator.AAccount))
        //            {
        //                return NotFound();
        //            }
        //            else
        //            {
        //                throw;
        //            }
        //        }
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(administrator);
        //}

        // GET: AdministratorManagement/Administrators/Delete/5
        //public async Task<IActionResult> Delete(string id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var administrator = await _context.Administrators
        //        .FirstOrDefaultAsync(m => m.AAccount == id);
        //    if (administrator == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(administrator);
        //}

        // POST: AdministratorManagement/Administrators/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
    //    public async Task<IActionResult> DeleteConfirmed(string id)
    //    {
    //        var administrator = await _context.Administrators.FindAsync(id);
    //        if (administrator != null)
    //        {
    //            _context.Administrators.Remove(administrator);
    //        }

    //        await _context.SaveChangesAsync();
    //        return RedirectToAction(nameof(Index));
    //    }

    //    private bool AdministratorExists(string id)
    //    {
    //        return _context.Administrators.Any(e => e.AAccount == id);
    //    }
    //}
//}
