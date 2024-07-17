﻿namespace JourneyJoy.Core.Dtos.GetContactDtos
{
    public class CreateGetContactDto
    {
        public string Name { get; set; }
        public string Mail { get; set; }
        public string Phone { get; set; }
        public string Subject { get; set; }
        public string MessageBody { get; set; }
        public DateTime MessageDate { get; set; }
        public bool MessageStatus { get; set; }
    }
}
