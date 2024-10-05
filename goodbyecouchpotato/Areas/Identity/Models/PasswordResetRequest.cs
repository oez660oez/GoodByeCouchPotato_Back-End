namespace goodbyecouchpotato.Areas.Identity.Models
{
    public class PasswordResetRequest
    {
        public string Id { get; set; } // GUID 作為唯一識別碼
        public string Email { get; set; } // 用戶的 Email
        public string Token { get; set; } // 密碼重置的 Token
        public DateTime CreatedAt { get; set; } // 請求的建立時間
    }
}