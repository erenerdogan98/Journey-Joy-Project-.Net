using JourneyJoy.UI.Core.Dtos.AuthDtos;
using JourneyJoy.UI.Core.Dtos.GetResponseDtos;

namespace JourneyJoy.UI.Core.Services.Abstract
{
    public interface IAuthService
    {
        Task<GetApiResponseDto<LoginServiceResponseDto>> LoginAsync(LoginDto loginViewModel);
        public string GetUserId();
        Task<GetApiResponseDto<string>> Logout();
        Task<GetApiResponseDto<string>> RegisterAsync(RegisterDto registerDto);
        Task<GetApiResponseDto<string>> UpdateProfile(UserInfoResult updateProfileDto);
        Task<GetApiResponseDto<UserInfoResult>> GetUserById(int id);
        Task<GetApiResponseDto<int>> GetUserCount();
        Task<GetApiResponseDto<IEnumerable<UserInfoResult>>> GetAllMembers();
        Task<GetApiResponseDto<string>> DeleteMemberAsync(int id);
    }
}
