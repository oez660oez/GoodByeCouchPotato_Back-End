using System.ComponentModel.DataAnnotations;

namespace goodbyecouchpotato.Areas.ReviewManagement.viewmodel
{
    public class TASKReviewviewmodel
    {
        [Key]
        [Display(Name = "任務編號")]
        public int TaskID { get; set; }
        [Display(Name = "任務名稱")]
        public string TaskName { get; set; }
        [Display(Name = "獎勵")]
        public int Reward { get; set; }


        public bool TaskActive { get; set; }
        [Display(Name = "有效性")]
        public string ActiveStatus
        {
            get
            {
                return TaskActive ? "已啟用" : "未啟用";
            }
        }

    }
}
