﻿using Microsoft.AspNetCore.Mvc;

namespace JourneyJoy.UI.Areas.Member.ViewComponents.MemberLayout
{
    public class MemberLayoutHeadCP : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
