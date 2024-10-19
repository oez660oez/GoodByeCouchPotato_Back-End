namespace PotatoWebAPI.DTO
{
    public class ChangePasswordDTO
    {
        public string? Account { get; set; }
        public string? OldPassword { get; set; }
        public string? NewPassword { get; set; }
    }
}
