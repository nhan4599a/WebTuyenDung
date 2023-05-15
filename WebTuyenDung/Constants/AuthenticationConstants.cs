using Microsoft.AspNetCore.Authentication.Cookies;
using System.Security.Claims;

namespace WebTuyenDung.Constants
{
    public static class AuthenticationConstants
    {
        public const string AUTHENTICATION_SCHEME = CookieAuthenticationDefaults.AuthenticationScheme;

        public const string AVATAR_CLAIM_KEY = "Avatar";

        public const string USER_ID_KEY = ClaimTypes.NameIdentifier;

        public const string USERNAME_KEY = ClaimTypes.Name;

        public const string USER_FORMAL_NAME_KEY = ClaimTypes.GivenName;

        public const string CANDIDATE_BIRTH_DAY_KEY = ClaimTypes.DateOfBirth;

        public const string CANDIDATE_PHONE_NUMBER_KEY = ClaimTypes.MobilePhone;

        public const string CANDIDATE_ADDRESS_KEY = ClaimTypes.StreetAddress;

        public const string CANDIDATE_GENDER_KEY = ClaimTypes.Gender;

        public const string RETURN_URL = "ReturnUrl";
    }
}
