using JourneyJoy.DTO.ServiceResponseDtos;
using System.Linq.Expressions;
namespace JourneyJoy.BLL.Abstract
{
    public interface IGenericService<TCreateDto, TUpdateDto, TResultDto> where TCreateDto : class
    {
        Task<ApiResponseDto<string>> TAddAsync(TCreateDto entity);
        Task<ApiResponseDto<string>> TDeleteAsync(int id);
        ApiResponseDto<string> TUpdate(TUpdateDto entity);
        Task<ApiResponseDto<IEnumerable<TResultDto>>> TGetAllAsync();
        Task<ApiResponseDto<TResultDto>> TGetByIdAsync(int id);
        ApiResponseDto<TResultDto> TGetById(int id);
        Task<ApiResponseDto<IEnumerable<TResultDto>>> TGetAllAsync(Expression<Func<TResultDto, bool>> filter);
        Task<ApiResponseDto<TResultDto>> TGeyByFilterAsync(Expression<Func<TResultDto, bool>> filter);
    }
}
