namespace PotatoWebAPI.DTO
{
    public class LoginPlayDTO
    {
        public string Account { get; set; }
        public string password { get; set; }
    }
    public partial class RegisterDTO
    {
        public string? Account { get; set; }

        public string? Email { get; set; }

        public string? Password { get; set; }
        public string? CheckPassword { get; set; }

        public bool Playerstatus { get; set; }

        public string? Token { get; set; }

    }
}
