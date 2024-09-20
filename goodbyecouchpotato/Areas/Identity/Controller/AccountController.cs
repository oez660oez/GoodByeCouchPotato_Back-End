using Microsoft.AspNetCore.Mvc;

namespace YourNamespace.Areas.MemberManagement.Controllers
{
	[Area("Identity")]
	public class AccountController : Controller
	{
		// GET: /Account/Login
		[HttpGet]
		public IActionResult Login()
		{
			return View();
		}

		// POST: /Account/Login
		[HttpPost]
		public IActionResult Login(LoginViewModel model)
		{
			if (ModelState.IsValid)
			{
				// 驗證邏輯 (例如檢查用戶名和密碼)
				// 成功則登入用戶，失敗則回傳錯誤訊息
				return RedirectToAction("Index", "Home");
			}

			return View(model);
		}
	}
}
