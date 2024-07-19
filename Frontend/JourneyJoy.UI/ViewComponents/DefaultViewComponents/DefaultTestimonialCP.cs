using JourneyJoy.UI.Core.Services.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace JourneyJoy.UI.ViewComponents.DefaultViewComponents
{
    public class DefaultTestimonialCP(ITestimonialService testimonialService) : BaseViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var response = await testimonialService.GetAllAsync("testimonials");
            var values = response.Data;
            if (response.Success)
                return View(values);
            return HandleError(response.statusCode);
        }
    }
}
