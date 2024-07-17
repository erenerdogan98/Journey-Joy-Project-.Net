using JourneyJoy.UI.Core.Dtos.DestinationDtos;
using JourneyJoy.UI.Core.Dtos.GetResponseDtos;

namespace JourneyJoy.UI.Core.Services.Abstract
{
    public interface IDestinationService : IGenericService<CreateDestinationDto, UpdateDestinationDto, ResultDestinationDto, int>
    {
        Task<GetApiResponseDto<IEnumerable<ResultDestinationDto>>> GetLastFourDestinationsAsync();
    }
}
