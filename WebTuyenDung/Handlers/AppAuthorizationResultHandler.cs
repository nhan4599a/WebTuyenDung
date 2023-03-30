using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authorization.Policy;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.Extensions.DependencyInjection;
using System.Net;
using System.Threading.Tasks;
using WebTuyenDung.Constants;
using WebTuyenDung.Helper;

namespace WebTuyenDung.Handlers
{
    public class AppAuthorizationResultHandler : IAuthorizationMiddlewareResultHandler
    {
        private readonly AuthorizationMiddlewareResultHandler defaultHandler = new();

        public Task HandleAsync(
            RequestDelegate next,
            HttpContext context,
            AuthorizationPolicy policy,
            PolicyAuthorizationResult authorizeResult)
        {
            var isFiredByAuthenticationEndpoint =
                (bool?)context.GetTempData()[AuthorizationConstants.IS_FIRED_BY_AUTHENTICATION_ENDPOINT];
            if (authorizeResult.Forbidden)
            {
                if (!isFiredByAuthenticationEndpoint.HasValue)
                {
                    context.Response.Redirect($"/authentication/sign-in?ReturnUrl={WebUtility.UrlEncode(context.Request.Path)}");
                }
                else
                {
                    context.Response.StatusCode = StatusCodes.Status403Forbidden;
                }
                return Task.CompletedTask;
            }

            return defaultHandler.HandleAsync(next, context, policy, authorizeResult);
        }
    }
}
