using Microsoft.CodeAnalysis.CSharp.Syntax;
using Newtonsoft.Json.Serialization;
using System.ComponentModel.DataAnnotations;

namespace goodbyecouchpotato.Areas.TaskManagement.Views
{
    public class _SearchViewModel
    {
        public int TaskId { get; set; }

        [Display(Name ="任務名稱")]
        [Required(ErrorMessage ="任務名稱必填")]
        public string? TaskName { get; set; } = null!;

        [Display(Name = "任務獎勵")]
        [Range(5,30, ErrorMessage = "必須以5的倍數，輸入5到30之間的數字")]
        [Required(ErrorMessage = "任務獎勵必填")]
        public int? Reward { get; set; }

        [Display(Name = "任務有效性")]
        public bool? TaskActive { get; set; }

        public string TaskActiveDisplay
        {
            get
            {
                if (TaskActive == true)
                    return "已啟用";
                else if (TaskActive == false)
                    return "未啟用";
                else
                    return "未知";
            }
        }
    
    [Display(Name = "複核狀態")]
        public string? TReviewStatus { get; set; } = null!;
    }
}
