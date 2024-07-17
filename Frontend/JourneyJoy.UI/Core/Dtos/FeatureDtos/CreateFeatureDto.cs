namespace JourneyJoy.UI.Core.Dtos.FeatureDtos
{
    public class CreateFeatureDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string? Image { get; set; }
        public bool Status { get; set; } = false;
    }
}
