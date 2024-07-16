namespace JourneyJoy.DTO.FeatureDtos
{
    public class CreateFeatureDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public bool Status { get; set; } = false;
    }
}
