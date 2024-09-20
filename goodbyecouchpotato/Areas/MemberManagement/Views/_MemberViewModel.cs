using System.ComponentModel.DataAnnotations;

namespace goodbyecouchpotato.Areas.MemberManagement.Views
{
    public class _MemberViewModel
    {
        [Display(Name="用戶名稱")]
        public string Account { get; set; }

        [Display(Name = "信箱")]
        public string Email { get; set; }

        [Display(Name = "玩家狀態")]
        public string Playerstatus { get; set; }
        [Display(Name = "貨幣")]
        public string Coins { get; set; }
    }
}