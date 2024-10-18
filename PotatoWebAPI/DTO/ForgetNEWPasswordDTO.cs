namespace PotatoWebAPI.DTO
{
    public class ForgetNEWPasswordDTO
    {
        public string? email { get; set; }
        public string? account { get; set; }
        public string? password { get; set; }
        public int? Verificationnumber { get; set; }
    }
}
