using Microsoft.AspNetCore.Authentication.Cookies;
using System.Security.Claims;

namespace WebTuyenDung.Constants
{
    public static class AuthenticationConstants
    {
        public const string AUTHENTICATION_SCHEME = CookieAuthenticationDefaults.AuthenticationScheme;

        public const string AVATAR_CLAIM_KEY = "Avatar";

        public const string USER_ID_KEY = ClaimTypes.NameIdentifier;

        public const string USER_FORMAL_NAME_KEY = ClaimTypes.Name;

        public const string RETURN_URL = "ReturnUrl";
    }
}
