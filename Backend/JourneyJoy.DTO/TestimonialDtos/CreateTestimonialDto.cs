namespace JourneyJoy.DTO.TestimonialDtos
{
    public class CreateTestimonialDto
    {
        public string Client { get; set; }
        public string Comment { get; set; }
        public string ClientImage { get; set; }
        public bool Status { get; set; } = false;
    }
}
