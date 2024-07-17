namespace JourneyJoy.UI.Core.Dtos.AuthDtos
{
    public class LoginResultDto
    {
        public bool IsSuccess { get; set; }
        public LoginServiceResponseDto LoginServiceResponse { get; set; } 
        public string ErrorMessage { get; set; } 
    }
}
