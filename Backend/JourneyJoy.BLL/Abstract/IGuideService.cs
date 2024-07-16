using JourneyJoy.DTO.GuideDtos;
using JourneyJoy.DTO.ServiceResponseDtos;

namespace JourneyJoy.BLL.Abstract
{
    public interface IGuideService : IGenericService<CreateGuideDto, UpdateGuideDto, ResultGuideDto>
    {
        Task<ApiResponseDto<string>> ChangeStatusByIdAsync(int id);
    }
}
