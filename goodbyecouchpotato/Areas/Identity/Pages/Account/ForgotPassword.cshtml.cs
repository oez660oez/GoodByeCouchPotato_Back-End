using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;
using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography;
using System.Security.Policy;
using System.Text.Encodings.Web;
using System.Text;
using Microsoft.AspNetCore.Identity.UI.Services;

public class ForgotPasswordModel : PageModel
{
    private readonly UserManager<IdentityUser> _userManager;
    private readonly IEmailSender _emailSender;
    private readonly MailService _mailService;

    public ForgotPasswordModel(UserManager<IdentityUser> userManager, IEmailSender emailSender, MailService mailService)
    {
        _userManager = userManager;
        _emailSender = emailSender;
        _mailService = mailService;
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
                return RedirectToPage("./ForgotPasswordConfirmation");
            }

            var code = await _userManager.GeneratePasswordResetTokenAsync(user);
            code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));
            var token = EncodeToken(user.Email); // 使用 Base64 编码邮箱
            var callbackUrl = Url.Page(
                "/Account/ResetPassword",
                pageHandler: null,
                values: new { code, email = user.Email },
                protocol: Request.Scheme);

            string subject = "重設密碼通知";
            string message = $"<p>親愛的用戶：</p><p>您正在嘗試重設密碼。</p><p>請點擊以下連結進行重設：</p><p><a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>重設密碼</a></p>";

            await _mailService.SendEmailAsync(Input.Email, subject, message);

            TempData["SuccessMessage"] = "郵件已成功發送!";

            return RedirectToPage("./ForgotPasswordConfirmation");
        }

        return Page();
    }

    private string EncodeToken(string email)
    {
        return WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(email));
    }

}
