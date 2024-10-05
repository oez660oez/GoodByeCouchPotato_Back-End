using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;
using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography;
using System.Text;
using System.Text.Encodings.Web;
using System;
using goodbyecouchpotato.Areas.Identity.Models;
using goodbyecouchpotato.Data;
using Microsoft.AspNetCore.Identity.UI.Services;

public class ForgotPasswordModel : PageModel
{
    private readonly UserManager<IdentityUser> _userManager;
    private readonly MailService _mailService; // 使用自訂的 MailService
    private readonly IEmailSender _emailSender;
    private readonly ApplicationDbContext _context; // 使用你的 DbContext

    public ForgotPasswordModel(UserManager<IdentityUser> userManager, MailService mailService, ApplicationDbContext context, IEmailSender emailSender)
    {
        _userManager = userManager;
        _emailSender = emailSender;
        _mailService = mailService;
        _context = context;
    }

    [BindProperty]
    public InputModel Input { get; set; }

    public class InputModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> OnPostAsync()
    {
        if (ModelState.IsValid)
        {
            var user = await _userManager.FindByEmailAsync(Input.Email);
            if (user == null || !(await _userManager.IsEmailConfirmedAsync(user)))
            {
                // 如果用戶不存在或未確認郵箱，直接顯示已發送郵件頁面
                return RedirectToPage("./ForgotPasswordConfirmation");
            }

            // 生成密碼重置 token 並進行編碼
            var token = await _userManager.GeneratePasswordResetTokenAsync(user);
            var encodedToken = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(token));

            // 建立 GUID 作為識別碼
            var resetId = Guid.NewGuid().ToString();

            // 儲存到 PasswordResetRequest 資料表中
            var resetRequest = new PasswordResetRequest
            {
                Id = resetId,
                Email = Input.Email,
                Token = encodedToken,
                CreatedAt = DateTime.UtcNow
            };

            _context.PasswordResetRequests.Add(resetRequest);
            await _context.SaveChangesAsync();

            // 生成密碼重置的 callback URL
            var callbackUrl = Url.Page(
                "/Account/ResetPassword",
                pageHandler: null,
                values: new { id = resetId }, // 傳遞的是 resetId
                protocol: Request.Scheme);

            // 郵件主旨與內容
            string subject = "重設密碼通知";
            string message = $"<p>親愛的用戶：</p><p>您正在嘗試重設密碼。</p><p>請點擊以下鏈接進行重設：</p><p><a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>重設密碼</a></p>";

            // 使用 MailService 發送郵件
            await _mailService.SendEmailAsync(Input.Email, subject, message);

            // 成功發送後重定向至確認頁面
            TempData["SuccessMessage"] = "郵件已成功發送!";
            return RedirectToPage("./ForgotPasswordConfirmation");
        }

        return Page();
    }
}
