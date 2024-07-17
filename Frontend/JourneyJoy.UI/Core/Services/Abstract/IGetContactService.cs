using JourneyJoy.Core.Dtos.GetContactDtos;
using JourneyJoy.UI.Core.Dtos.GetResponseDtos;

namespace JourneyJoy.UI.Core.Services.Abstract
{
    public interface IGetContactService : IGenericService<CreateGetContactDto, UpdateGetContactDto, ResultGetContactDto, int>
    {
        Task<GetApiResponseDto<IEnumerable<ResultGetContactDto>>> GetListGetContactsByStatusTrue();
    }
}
