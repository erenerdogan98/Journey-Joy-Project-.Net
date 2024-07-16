namespace JourneyJoy.DTO.ContactDtos
{
    public class CreateContactDto
    {
        public string Description { get; set; }
        public string Mail { get; set; }
        public string Adress { get; set; }
        public string Phone { get; set; }
        public string MapLocation { get; set; }
        public bool Status { get; set; } = false;   
    }
}
