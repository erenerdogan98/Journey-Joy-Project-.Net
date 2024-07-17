using JourneyJoy.UI.Core.Dtos.AccountDtos;
using JourneyJoy.UI.Core.Dtos.GetResponseDtos;

namespace JourneyJoy.UI.Core.Services.Abstract
{
    public interface IAccountService : IGenericService<CreateAccountDto, UpdateAccountDto, ResultAccountDto , int>
    {
        Task<GetApiResponseDto<string>> MultiUpdate(IEnumerable<UpdateAccountDto> updateAccountDto);
    }
}
