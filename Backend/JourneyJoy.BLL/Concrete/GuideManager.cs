using AutoMapper;
using JourneyJoy.BLL.Abstract;
using JourneyJoy.DAL.Abstract;
using JourneyJoy.DTO.GuideDtos;
using JourneyJoy.DTO.ServiceResponseDtos;
using JourneyJoy.Entities;

namespace JourneyJoy.BLL.Concrete
{
    public class GuideManager(IGuideDAL guideDAL, IMapper mapper) : GenericManager<Guide, CreateGuideDto, UpdateGuideDto, ResultGuideDto>(guideDAL, mapper), IGuideService
    {
        public async Task<ApiResponseDto<string>> ChangeStatusByIdAsync(int id)
        {
            var guide = await guideDAL.GetByIdAsync(id);
            if (guide is null)
                return new ApiResponseDto<string>("Fetching Guide by Id", false, 404, "Guide not found by Id");
            await guideDAL.ChangeStatus(guide);
            return new ApiResponseDto<string>("Change Status", true, 200, "Guide status has changed successfully.");
        }
    }
}
