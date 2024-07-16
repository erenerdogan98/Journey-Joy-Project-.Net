using JourneyJoy.DTO.DestinationDtos;
using JourneyJoy.DTO.ServiceResponseDtos;

namespace JourneyJoy.BLL.Abstract
{
    public interface IExcelService
    {
        byte[] StaticExcelList<T>(List<T> list) where T : class;
        ApiResponseDto<byte[]> CreateExcelReport(List<ResultDestinationDto> destination);
    }
}
