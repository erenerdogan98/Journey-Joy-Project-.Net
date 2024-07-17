using JourneyJoy.UI.Core.Dtos.GetResponseDtos;

namespace JourneyJoy.UI.Core.Services.Abstract
{
    public interface IGenericService<TCreateDto, TUpdateDto, TResultDto, TKey>
    {
        Task<GetApiResponseDto<IEnumerable<TResultDto>>> GetAllAsync(string baseUrl);
        Task<GetApiResponseDto<TUpdateDto>> GetByIdAsync(TKey id, string baseUrl);
        Task<GetApiResponseDto<string>> CreateAsync(TCreateDto dto, string baseUrl);
        Task<GetApiResponseDto<string>> UpdateAsync(TUpdateDto dto, string baseUrl);
        Task<GetApiResponseDto<string>> DeleteAsync(TKey id, string baseUrl);
    }
}
