namespace PotatoWebAPI.DTO
{
    public class ForgetNEWPassword
    {
        public string email { get; set; } = null!;
        public string account { get; set; } = null!;
        public string password { get; set; } = null!;
        public int Verificationnumber { get; set; }
    }
}
