namespace PotatoWebAPI.DTO
{
    public class CreateCharacterDTO
    {
        public string Name { get; set; }
        public decimal Height { get; set; }
        public decimal Weight { get; set; }
        public string ExerciseIntensity { get; set; }
        public string Account { get; set; }
    }
}
