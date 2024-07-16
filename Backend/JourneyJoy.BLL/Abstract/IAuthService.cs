using JourneyJoy.DTO.AuthDtos;
using JourneyJoy.DTO.ServiceResponseDtos;
using static JourneyJoy.DTO.ServiceResponseDtos.LoginResponseDto;

namespace JourneyJoy.BLL.Abstract
{
    public interface IAuthService
    {
        Task<ApiResponseDto<string>> CreateAccount(RegisterDto registerDto);
        Task<ApiResponseDto<LoginResponse>> LoginAsync(LoginDto loginDto);
        Task<ApiResponseDto<string>> EditAccount(UserInfoDto userInfoDto, int userId);
        Task<ApiResponseDto<UserInfoDto>> TGetUserById(int id);
        Task<ApiResponseDto<UserInfoDto>> TGetUserByEmail(string email);
        Task<ApiResponseDto<int>> TGetUserCountAsync();
        Task<ApiResponseDto<IEnumerable<UserInfoDto>>> TGetAllMembersAsync();
        Task<ApiResponseDto<string>> TDeleteUserAsync(int id);

    }
}
