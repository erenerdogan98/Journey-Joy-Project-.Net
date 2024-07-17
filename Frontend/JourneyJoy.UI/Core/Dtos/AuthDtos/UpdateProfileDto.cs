﻿namespace JourneyJoy.UI.Core.Dtos.AuthDtos
{
    public class UpdateProfileDto
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        //public string Username { get; set; }
        //public string Mail { get; set; }
        public string ImageUrl { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        //public string Password { get; set; }
        //public string ConfirmPassword { get; set; }
    }
}
