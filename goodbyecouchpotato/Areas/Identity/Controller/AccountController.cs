using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace goodbyecouchpotato.Areas.Identity.Controllers
{
    [Area("Identity")]
    public class AccountController : Controller
    {


        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;

        public AccountController(SignInManager<IdentityUser> signInManager, UserManager<IdentityUser> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }

        public static async Task InitializeRoles(IServiceProvider serviceProvider)
        {
            var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            var userManager = serviceProvider.GetRequiredService<UserManager<IdentityUser>>();

            // 檢查並創建 Admin 角色
            string[] roleNames = { "Admin", "User" };
            IdentityResult roleResult;

            foreach (var roleName in roleNames)
            {
                var roleExist = await roleManager.RoleExistsAsync(roleName);
                if (!roleExist)
                {
                    roleResult = await roleManager.CreateAsync(new IdentityRole(roleName));
                }
            }

            // 創建預設的管理員用戶（如需要）
            var adminEmail = "avemujika@gmail.com";
            var adminPassword = "@aA1234567890";
            var adminUser = await userManager.FindByEmailAsync(adminEmail);

            if (adminUser == null)
            {
                var newAdmin = new IdentityUser
                {
                    UserName = adminEmail,
                    Email = adminEmail,
                    EmailConfirmed = true
                };

                var createAdmin = await userManager.CreateAsync(newAdmin, adminPassword);
                if (createAdmin.Succeeded)
                {
                    await userManager.AddToRoleAsync(newAdmin, "Admin");  // 給用戶分配 Admin 角色
                }
            }
        }


        // GET: /Account/Login
        [HttpGet]
        public IActionResult Login(string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;
            return View();
        }

        // POST: /Account/Login
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                // 嘗試通過 Email 查找用戶
                var user = await _userManager.FindByEmailAsync(model.Email);
                if (user != null)
                {
                    // 給新用戶分配 "User" 角色（假設 "User" 角色已經存在）
                    if (!await _userManager.IsInRoleAsync(user, "User"))
                    {
                        await _userManager.AddToRoleAsync(user, "User");
                    }

                    var result = await _signInManager.PasswordSignInAsync(user, model.Password, model.RememberMe, lockoutOnFailure: false);

                    if (result.Succeeded)
                    {
                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, "登入失敗，請檢查您的用戶名和密碼。");
                    }
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "用戶不存在。");
                }

            }

            return View(model);
        }

		// POST: /Account/Logout
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Logout()
		{
			// 使用 SignInManager 進行登出操作
			await _signInManager.SignOutAsync();

			// 可選：禁止快取以確保登出後無法使用返回按鈕回到已登入狀態的頁面
			HttpContext.Response.Headers["Cache-Control"] = "no-cache, no-store, must-revalidate";
			HttpContext.Response.Headers["Pragma"] = "no-cache";
			HttpContext.Response.Headers["Expires"] = "-1";

			// 導向到登入頁面
			return RedirectToAction("Login", "Account");
		}
	}
}
