using System.ComponentModel.DataAnnotations;

namespace goodbyecouchpotato.Areas.ReviewManagement.viewmodel
{
    public class ProductReviewviewmodel
    {
        [Key]
        [Display(Name = "商品編號")]
        public int PCode { get; set; }
        [Display(Name = "商品類別")]
        public string PClass { get; set; } = null!;
        [Display(Name = "商品名稱")]
        public string PName { get; set; } = null!;
        [Display(Name = "價格")]
        public int? PPrice { get; set; }
        [Display(Name = "開放等級")]
        public int? PLevel { get; set; }
        [Display(Name = "商店照片")]
        public string? PImageShop { get; set; }
        [Display(Name = "全視圖照片")]
        public string? PImageAll { get; set; }
        [Display(Name = "有效性")]
        public bool PActive { get; set; }

        [Display(Name = "有效性")]
        public string ActiveStatus
        {
            get
            {
                return PActive ? "已啟用" : "未啟用";
            }
        }

    }
}
