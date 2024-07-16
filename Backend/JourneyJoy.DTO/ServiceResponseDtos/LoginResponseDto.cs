using JourneyJoy.DTO.AuthDtos;
namespace JourneyJoy.DTO.ServiceResponseDtos
{
    public class LoginResponseDto
    {
        // Use that with ApiResponseDto 
        public record class LoginResponse( string Token,  UserInfoDto UserInfo); 
    }
}
