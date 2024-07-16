using JourneyJoy.DTO.DestinationDtos;
using JourneyJoy.DTO.ServiceResponseDtos;

namespace JourneyJoy.BLL.Abstract
{
    public interface IDestinationService : IGenericService<CreateDestinationDto, UpdateDestinationDto, ResultDestinationDto>
    {
        Task<ApiResponseDto<IEnumerable<ResultDestinationDto>>> TGetLastFourDestinationsAsync();
    }
}
