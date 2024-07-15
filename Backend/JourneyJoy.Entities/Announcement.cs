namespace JourneyJoy.Entities
{
    public class Announcement : IEntityBase
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime Date { get; set; }
    }
}
