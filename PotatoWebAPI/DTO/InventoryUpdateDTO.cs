namespace PotatoWebAPI.DTO
{
    public class InventoryUpdateDTO
    {
        public string Account { get; set; }
        public List<InventoryItemDTO> Items { get; set; }
    }

    public class InventoryItemDTO
    {
        public string ImageName { get; set; }
    }
}