using JourneyJoy.UI.Core.Dtos.TestimonialDtos;
using JourneyJoy.UI.Core.Helper;
using JourneyJoy.UI.Core.Services.Abstract;

namespace JourneyJoy.UI.Core.Services.Concrete
{
    public class TestimonialService(HttpClientHelper httpClientHelper) : GenericService<CreateTestimonialDto, UpdateTestimonialDto, ResultTestimonialDto, int>(httpClientHelper), ITestimonialService
    {

    }
}
