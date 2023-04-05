using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using WebTuyenDung.Constants;
using WebTuyenDung.Models;

namespace WebTuyenDung.Helper
{
    public static class AuthenticationHelper
    {
        public static string? GetAvatar(this ClaimsPrincipal identity)
        {
            return identity.FindFirst(AuthenticationConstants.AVATAR_CLAIM_KEY)?.Value;
        }

        public static int GetUserId(this ClaimsPrincipal identity)
        {
            return int.Parse(identity.FindFirst(AuthenticationConstants.USER_ID_KEY)!.Value);
        }

        public static string GetName(this ClaimsPrincipal identity)
        {
            return identity.FindFirst(AuthenticationConstants.USER_FORMAL_NAME_KEY)!.Value;
        }

        public static Task SignInAsync(this HttpContext httpContext, User user)
        {
            var claimsPrinciple = user.GetClaimsPrinciple();

            return httpContext
                        .SignInAsync(
                            AuthenticationConstants.AUTHENTICATION_SCHEME,
                            claimsPrinciple
                        );
        }

        private static ClaimsPrincipal GetClaimsPrinciple(this User user)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.Name),
                new Claim(ClaimTypes.Role, user.Role.ToString())
            };

            if (user.Avatar != null)
            {
                claims.Add(new Claim(AuthenticationConstants.AVATAR_CLAIM_KEY, user.Avatar));
            }

            var claimsIdentity = new ClaimsIdentity(claims, AuthenticationConstants.AUTHENTICATION_SCHEME);

            return new ClaimsPrincipal(claimsIdentity);
        }
    }
}
