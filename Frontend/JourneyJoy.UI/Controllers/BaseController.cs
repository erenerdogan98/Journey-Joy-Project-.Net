using JourneyJoy.UI.Core.Dtos.GetResponseDtos;
using Microsoft.AspNetCore.Mvc;

namespace JourneyJoy.UI.Controllers
{
    public class BaseController : Controller
    {
        // To manage error pages routes and also validation errors ..
        protected IActionResult HandleErrorResponse<T>(GetApiResponseDto<T> response, string viewName, object? model = null)
        {
            if (response.Errors is null)
            {
                if (response.statusCode >= 500 && response.statusCode < 600)
                    return RedirectToAction("Error500", "ErrorPage");

                if (response.statusCode >= 400 && response.statusCode < 500)
                    return RedirectToAction("Error404", "ErrorPage");

                return RedirectToAction("GeneralError", "ErrorPage");
            }
            foreach (var error in response.Errors)
            {
                foreach (var message in error.Value)
                {
                    ModelState.AddModelError(error.Key, message);
                }
            }
            return View(viewName, model);
        }
    }
}
