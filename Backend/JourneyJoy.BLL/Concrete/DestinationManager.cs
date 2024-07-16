using AutoMapper;
using JourneyJoy.BLL.Abstract;
using JourneyJoy.DAL.Abstract;
using JourneyJoy.DTO.DestinationDtos;
using JourneyJoy.DTO.ServiceResponseDtos;
using JourneyJoy.Entities;

namespace JourneyJoy.BLL.Concrete
{
    public class DestinationManager(IDestinationDAL destinationDAL, IMapper mapper) : GenericManager<Destination, CreateDestinationDto, UpdateDestinationDto, ResultDestinationDto>(destinationDAL, mapper), IDestinationService
    {
        private readonly IMapper _mapper = mapper;
        public async Task<ApiResponseDto<IEnumerable<ResultDestinationDto>>> TGetLastFourDestinationsAsync()
        {
            var values = await destinationDAL.GetLastFourDestinationAsync();
            if (values != null)
            {
                var valuesDto = _mapper.Map<IEnumerable<ResultDestinationDto>>(values);
                return new ApiResponseDto<IEnumerable<ResultDestinationDto>>(valuesDto, true, 200, "Last Four Destinations fetched successfully");
            }
            return new ApiResponseDto<IEnumerable<ResultDestinationDto>>(null, false, 400, $"Last four destination values not found");
        }
    }
}
