using System.ComponentModel.DataAnnotations;

namespace goodbyecouchpotato.Areas.ProductManagement.Views
{
    public class _AccessoriesViewModel
    {
        [Display(Name ="商品代號")]
        public int PCode { get; set; }
        [Display(Name = "商品類型")]
        public string PClass { get; set; } = null!;
        [Display(Name = "商品名稱")]
        [Required(ErrorMessage ="商品名稱必填")]
        public string PName { get; set; } = null!;
        [Display(Name = "商品價格")]
        [Required(ErrorMessage = "商品價格必填")]
        [Range(280, 10000, ErrorMessage = "必須以5的倍數，輸入大於280或小於10000的數字")]
        public int? PPrice { get; set; }
        [Display(Name = "商品等級")]
        [Required(ErrorMessage = "商品等級必填")]
        public int? PLevel { get; set; }
        [Display(Name = "商店圖片")]
        public string? PImageShop { get; set; }
        [Display(Name = "所有圖片")]
        public string? PImageAll { get; set; }
        [Display(Name = "商品有效性")]
        public bool PActive { get; set; }

        public string PActiveDisplay
        {
            get
            {
                if (PActive == true)
                    return "已啟用";
                else if (PActive == false)
                    return "未啟用";
                else
                    return "未知";
            }
        }

        [Display(Name = "複核狀態")]
        public string PReviewStatus { get; set; } = null!;
    }
}
