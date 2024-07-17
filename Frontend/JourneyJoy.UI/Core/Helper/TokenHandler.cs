﻿using System.Net.Http.Headers;

namespace JourneyJoy.UI.Core.Helper
{
	public class TokenHandler(IHttpContextAccessor httpContextAccessor) : DelegatingHandler
	{
		protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
		{
			var accessToken = httpContextAccessor.HttpContext.Session.GetString("AccessToken");
			if (!string.IsNullOrEmpty(accessToken))
			{
				request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
			}

			return await base.SendAsync(request, cancellationToken);
		}
	}
}
