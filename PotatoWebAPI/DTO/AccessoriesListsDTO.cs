namespace PotatoWebAPI.DTO
{
    public class AccessoriesListsDTO
    {
        public int PCode { get; set; }

        public string? PClass { get; set; }

        public string? PName { get; set; }

        public int? PPrice { get; set; }

        public int? PLevel { get; set; }

        public string? PImageShop { get; set; }
        public string? PImageAll { get; set; }

        public bool ishaveitem { get; set; }

    }
    public class PageRequestDTO
    {
        public int Page { get; set; }
        public string? Account { get; set; }
    }

    public class PurchaseDTO
    {
        public string? Account { get; set; }
        public int? CId { get; set; }
        public int? Coins { get; set; }
        public int? PCode { get; set; }
        public int? PPrice { get; set; }
        public int? PLevel { get; set; }
    }

    public class bodyaccessoryDTO
    {
    public int? head { get; set; }
    public int? body { get; set; }
    public int? accessory { get; set; }
    }

}
