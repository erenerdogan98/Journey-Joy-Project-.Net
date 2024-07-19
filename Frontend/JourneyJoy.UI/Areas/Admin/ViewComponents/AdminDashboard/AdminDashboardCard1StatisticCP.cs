using JourneyJoy.UI.Areas.Admin.Models;
using JourneyJoy.UI.Core.Services.Abstract;
using JourneyJoy.UI.ViewComponents;
using Microsoft.AspNetCore.Mvc;

namespace JourneyJoy.UI.Areas.Admin.ViewComponents.AdminDashboard
{
    public class AdminDashboardCard1StatisticCP(IDestinationService destinationService, IAuthService authService) : BaseViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var (destinationCount, destinationStatusCode) = await GetDestinationCountAsync();
            if (destinationStatusCode != 200)
                return HandleError(destinationStatusCode);

            var (userCount, userStatusCode) = await GetUserCountAsync();
            if (userStatusCode != 200)
                return HandleError(userStatusCode);

            var model = new Cards1StatisticViewModel
            {
                DestinationCount = destinationCount,
                UserCount = userCount
            };

            return View(model);
        }

        private async Task<(int count, int statusCode)> GetDestinationCountAsync()
        {
            var response = await destinationService.GetAllAsync("destinations");
            int statusCode = response.statusCode;
            if (response.Success)
                return (response.Data.Count(), statusCode);
            return (-1, statusCode);
        }

        private async Task<(int count, int statusCode)> GetUserCountAsync()
        {
            var response = await authService.GetUserCount();
            int statusCode = response.statusCode;
            if (response.Success)
                return (response.Data, statusCode);
            return (-1,statusCode); 
        }
    }
}
