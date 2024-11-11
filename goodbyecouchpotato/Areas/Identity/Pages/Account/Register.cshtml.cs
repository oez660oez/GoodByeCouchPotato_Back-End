// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
#nullable disable

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages;

namespace goodbyecouchpotato.Areas.Identity.Pages.Account
{
    [Authorize(Roles = "Admin")]
    [Area("Identity")]
    public class RegisterModel : PageModel
    {
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IUserStore<IdentityUser> _userStore;
        private readonly IUserEmailStore<IdentityUser> _emailStore;
        private readonly ILogger<RegisterModel> _logger;
        private readonly IEmailSender _emailSender;
        private readonly RoleManager<IdentityRole> _roleManager;  //加入role di

        public RegisterModel(
            UserManager<IdentityUser> userManager,
            RoleManager<IdentityRole> roleManager,  //加入role di
            IUserStore<IdentityUser> userStore,
            SignInManager<IdentityUser> signInManager,
            ILogger<RegisterModel> logger,
            IEmailSender emailSender)
        {
            _roleManager = roleManager;  //取得role
            _userManager = userManager;
            _userStore = userStore;
            _emailStore = GetEmailStore();
            _signInManager = signInManager;
            _logger = logger;
            _emailSender = emailSender;
        }



        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        [BindProperty]
        public InputModel Input { get; set; }

        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        public string ReturnUrl { get; set; }

        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        public IList<AuthenticationScheme> ExternalLogins { get; set; }

        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        public class InputModel
        {
            /// <summary>
            ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
            ///     directly from your code. This API may change or be removed in future releases.
            /// </summary>
            [Required(ErrorMessage = "信箱必須填寫")]
            [EmailAddress(ErrorMessage = "請填寫正確的電子信箱")]
            [Display(Name = "電子信箱")]
            public string Email { get; set; }

            /// <summary>
            ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
            ///     directly from your code. This API may change or be removed in future releases.
            /// </summary>
            [Required(ErrorMessage ="密碼必須填寫")]
            [StringLength(100, ErrorMessage = "{0}要至少為{2}到{1}個字", MinimumLength = 8)]
            [DataType(DataType.Password)]
            [Display(Name = "密碼")]
            public string Password { get; set; }

            /// <summary>
            ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
            ///     directly from your code. This API may change or be removed in future releases.
            /// </summary>
            [DataType(DataType.Password)]
            [Display(Name = "確認密碼")]
            [Compare("Password", ErrorMessage = "確認密碼與密碼不一致！")]
            public string ConfirmPassword { get; set; }

            [Required(ErrorMessage = "請設定該帳號的權限")]
            [Display(Name = "設定權限")]
            public string Role { get; set; } // 添加角色字段

        }
        public List<SelectListItem> RoleList { get; set; }

        public async Task OnGetAsync(string returnUrl = null)
        {
            ReturnUrl = returnUrl;
            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList(); //取得外部認證(外部帳號)

            var roles = await _roleManager.Roles.Where(s=>s.Name!="admin").ToListAsync();  //篩選所有角色的內容
            RoleList = new List<SelectListItem> 
        {
        new SelectListItem { Value = string.Empty, Text = "", Selected = true } //加上空白字段，令使用者必須選擇
         };
            RoleList.AddRange(roles.Select(r => new SelectListItem { Value = r.Name, Text = r.Name }));
        }

        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            returnUrl ??= Url.Content("/AdministratorManagement/Administrators/Index");  //設定創建成功之後重指向的位置
            //ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();  //取得外部認證(外部帳號)
            if (ModelState.IsValid)  //檢查提交的表單數據是否有效
            {
                var user = CreateUser();  //調用方法來創建使用者，會將資料封裝在裡面，如果錯誤會整包退回不會建一半
                                //將用戶信箱設置為用戶名字
                await _userStore.SetUserNameAsync(user, Input.Email, CancellationToken.None);
                                //將用戶信箱設置為信箱
                await _emailStore.SetEmailAsync(user, Input.Email, CancellationToken.None);

                user.EmailConfirmed = true;  //直接確認用戶的電子信箱通過，不必驗證
                //----------取得角色---------------
                //----------取得角色---------------
                var result = await _userManager.CreateAsync(user, Input.Password);  //創建用戶




                //---------電子信箱驗證----------------
                //if (result.Succeeded)
                //{
                //    _logger.LogInformation("User created a new account with password.");  //紀錄日記

                //    var userId = await _userManager.GetUserIdAsync(user);  //取得新用戶的id
                //    var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);  //生成電子信箱驗證令牌
                //    code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));  //編譯令牌
                //    var callbackUrl = Url.Page(  //建構電子信箱驗證的url
                //        "/Account/ConfirmEmail",
                //        pageHandler: null,
                //        values: new { area = "Identity", userId = userId, code = code, returnUrl = returnUrl },
                //        protocol: Request.Scheme);

                //await _emailSender.SendEmailAsync(Input.Email, "Confirm your email",
                //    $"Please confirm your account by <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>clicking here</a>.");

                //if (_userManager.Options.SignIn.RequireConfirmedAccount)
                //{
                //    return RedirectToPage("RegisterConfirmation", new { email = Input.Email, returnUrl = returnUrl });
                //}
                //else
                //{
                //    return RedirectToPage("RegisterConfirmation", new { email = Input.Email, returnUrl = returnUrl });
                //}
                //}
                //---------電子信箱驗證end----------------
                if (result.Succeeded) {
                    if (!string.IsNullOrEmpty(Input.Role))
                    {
                        await _userManager.AddToRoleAsync(user, Input.Role);  //直接執行角色的分配
                    }
                    TempData["Register"] = "success";
                    return LocalRedirect(returnUrl);  //重新定向位置
                }
                else
                {
                foreach (var error in result.Errors)  //返回錯誤訊息
                {
                        TempData["Register"] = "error";
                        ModelState.AddModelError(string.Empty, error.Description);
                        await OnGetAsync(returnUrl);
                        return Page();//返回頁面
                    }
                }

            }

            // If we got this far, something failed, redisplay form
            return Page();
        }


        private IdentityUser CreateUser()
        {
            try
            {
                return Activator.CreateInstance<IdentityUser>();
            }
            catch
            {
                throw new InvalidOperationException($"Can't create an instance of '{nameof(IdentityUser)}'. " +
                    $"Ensure that '{nameof(IdentityUser)}' is not an abstract class and has a parameterless constructor, or alternatively " +
                    $"override the register page in /Areas/Identity/Pages/Account/Register.cshtml");
            }
        }

        private IUserEmailStore<IdentityUser> GetEmailStore()
        {
            if (!_userManager.SupportsUserEmail)
            {
                throw new NotSupportedException("The default UI requires a user store with email support.");
            }
            return (IUserEmailStore<IdentityUser>)_userStore;
        }
    }
}
