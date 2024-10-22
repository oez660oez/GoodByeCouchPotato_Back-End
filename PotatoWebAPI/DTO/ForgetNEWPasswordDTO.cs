namespace PotatoWebAPI.DTO
{
    public class GetForgetPasswordEmailDTO
    {
        public string forgetEmail { get; set; } = null!;
    }

    public class ForgetNEWPasswordDTO
    {
        public string? email { get; set; }
        public string? account { get; set; }
        public string? password { get; set; }
        public int? Verificationnumber { get; set; }
    }
}
