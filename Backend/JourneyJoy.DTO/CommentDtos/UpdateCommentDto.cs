﻿namespace JourneyJoy.DTO.CommentDtos
{
    public class UpdateCommentDto
    {
        public int Id { get; set; }
        public string User { get; set; }
        public DateTime Date { get; set; }
        public string Content { get; set; }
        public bool State { get; set; }
        public int DestinationId { get; set; }
        public int AppUserId { get; set; }
    }
}