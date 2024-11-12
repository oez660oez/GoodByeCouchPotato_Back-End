using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Linq;
using goodbyecouchpotato.Data;

public class ResetPasswordModel : PageModel
{
    private readonly UserManager<IdentityUser> _userManager;
    private readonly ApplicationDbContext _context; // 使用你的 DbContext

    public ResetPasswordModel(UserManager<IdentityUser> userManager, ApplicationDbContext context)
    {
        _userManager = userManager;
        _context = context;
    }

    [BindProperty]
    public InputModel Input { get; set; }

    public class InputModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "此欄位必須填寫。")]
        [StringLength(100, ErrorMessage = "密碼長度必須至少為 {2} 個字符，最多為 {1} 個字符。", MinimumLength = 6)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "此欄位必須填寫。")]
        [DataType(DataType.Password)]
        [Display(Name = "確認密碼")]
        [Compare("Password", ErrorMessage = "密碼和確認密碼不匹配。")]
        public string ConfirmPassword { get; set; }

        public string Code { get; set; }
    }

    public IActionResult OnGet(string id = null)
    {
        if (id == null)
        {
            return BadRequest("無法處理請求，缺少必要的重設 ID。");
        }

        // 從資料庫查詢 PasswordResetRequest
        var resetRequest = _context.PasswordResetRequests.FirstOrDefault(r => r.Id == id);
        if (resetRequest == null)
        {
            return BadRequest("無效的重設請求。");
        }

        Input = new InputModel
        {
            Email = resetRequest.Email,
            Code = resetRequest.Token
        };

        return Page();
    }

    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }

        var user = await _userManager.FindByEmailAsync(Input.Email);
        if (user == null)
        {
            return RedirectToPage("./ResetPasswordConfirmation");
        }

        var decodedToken = Encoding.UTF8.GetString(WebEncoders.Base64UrlDecode(Input.Code));
        var result = await _userManager.ResetPasswordAsync(user, decodedToken, Input.Password);
        if (result.Succeeded)
        {
            return RedirectToPage("./ResetPasswordConfirmation");
        }

        foreach (var error in result.Errors)
        {
            ModelState.AddModelError(string.Empty, error.Description);
        }

        return Page();
    }
}
