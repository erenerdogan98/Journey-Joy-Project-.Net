using JourneyJoy.UI.Core.Dtos.GetResponseDtos;
using JourneyJoy.UI.Core.Dtos.GuideDtos;

namespace JourneyJoy.UI.Core.Services.Abstract
{
    public interface IGuideService : IGenericService<CreateGuideDto, UpdateGuideDto, ResultGuideDto,int>
    {
        Task<GetApiResponseDto<string>> ChangeStatusByIdAsync(int id);
        Task<GetApiResponseDto<IEnumerable<ResultGuideDto>>> GetGuidesByStatuesTrue();
    }
}
