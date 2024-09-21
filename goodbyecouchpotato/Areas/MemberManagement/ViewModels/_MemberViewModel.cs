using System.ComponentModel.DataAnnotations;

namespace goodbyecouchpotato.Areas.MemberManagement.ViewModels
{
    public class MemberViewModel
    {
        [Display(Name = "玩家帳號")]
        public string? Account { get; set; }

        [Display(Name = "信箱")]
        public string? Email { get; set; }

        [Display(Name = "開通狀態")]
        public bool? Playerstatus { get; set; }

        public string PlayerstatusDisplay
        {
            get
            {
                if (Playerstatus == true)
                    return "已開通";
                else if (Playerstatus == false)
                    return "未開通";
                else
                    return "未知";
            }
        }

        [Display(Name = "貨幣")]
        public int Coins { get; set; }
    }
}