using JourneyJoy.UI.Core.Helper;
using Microsoft.AspNetCore.Mvc;

namespace JourneyJoy.UI.ViewComponents
{
    public abstract class BaseViewComponent : ViewComponent
    {
        protected IViewComponentResult HandleError(int statusCode)
        {
            return ErrorHelperCP.HandleError(statusCode);
        }
    }
}
