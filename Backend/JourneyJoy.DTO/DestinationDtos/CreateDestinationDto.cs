﻿namespace JourneyJoy.DTO.DestinationDtos
{
    public class CreateDestinationDto
    {
        public string City { get; set; }
        public int Day { get; set; }
        public int Night { get; set; }
        public double Price { get; set; }
        public string Image { get; set; }
        public string Description { get; set; }
        public int Capacity { get; set; }
        public bool Status { get; set; } = false;
        public string CoverImage { get; set; }
        public string Details1 { get; set; }
        public string Details2 { get; set; }
        public string Image2 { get; set; }
        public DateTime Date { get; set; } = DateTime.Now;
        public int GuideID { get; set; }
    }
}
