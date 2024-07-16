using AutoMapper;
using JourneyJoy.BLL.Abstract;
using JourneyJoy.DAL.Abstract;
using JourneyJoy.DTO.TestimonialDtos;
using JourneyJoy.Entities;

namespace JourneyJoy.BLL.Concrete
{
    public class TestimonialManager(ITestimonialDAL TestimonialDAL, IMapper mapper) : GenericManager<Testimonial, CreateTestimonialDto, UpdateTestimonialDto, ResultTestimonialDto>(TestimonialDAL, mapper), ITestimonialService
    {
    }
}
