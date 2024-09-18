using System.ComponentModel.DataAnnotations;

namespace goodbyecouchpotato.Areas.OpinionManagement.viewmodel
{
    public class Optionviewmodel
    {
        [Key]
        [Display(Name = "編號")]
        public int FeedbackNo { get; set; }
        [Display(Name = "信箱")]
        public string Email { get; set; } = null!;
        [Display(Name = "內容")]
        public string Content { get; set; } = null!;
        [Display(Name = "反映日期")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime Submitted { get; set; }
        [Display(Name = "處理狀態")]
        public bool ProActive { get; set; }
        [Display(Name = "回信日期")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? ProDate { get; set; }
        [Display(Name = "回信內容")]
        public string? Pro_Content { get; set; }

    }
}
