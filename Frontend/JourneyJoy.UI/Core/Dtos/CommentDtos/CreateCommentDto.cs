namespace JourneyJoy.UI.Core.Dtos.CommentDtos
{
    public class CreateCommentDto
    {
        public string User { get; set; }
        public DateTime Date { get; set; } = DateTime.Now;
        public string Content { get; set; }
        public bool State { get; set; } = false;
        public int DestinationId { get; set; }
        public int AppUserId { get; set; }
    }
}
