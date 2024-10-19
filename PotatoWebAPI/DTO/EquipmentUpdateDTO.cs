namespace PotatoWebAPI.DTO
{
    public class EquipmentUpdateDTO
    {
        public string Account { get; set; }
        public EquipmentSlotDTO Accessory { get; set; }
        public EquipmentSlotDTO Hairstyle { get; set; }
        public EquipmentSlotDTO Outfit { get; set; }
    }

    public class EquipmentSlotDTO
    {
        public string ImageName { get; set; }
        public string Type { get; set; }
    }
}
