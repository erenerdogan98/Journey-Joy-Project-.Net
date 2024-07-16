using AutoMapper;
using JourneyJoy.BLL.Abstract;
using JourneyJoy.DAL.Abstract;
using JourneyJoy.DTO.NewsLetterDtos;
using JourneyJoy.Entities;

namespace JourneyJoy.BLL.Concrete
{
    public class NewsLetterManager(INewsLetterDAL NewsLetterDAL, IMapper mapper) : GenericManager<NewsLetter, CreateNewsLetterDto, UpdateNewsLetterDto, ResultNewsLetterDto>(NewsLetterDAL, mapper), INewsLetterService
    {
    }
}
