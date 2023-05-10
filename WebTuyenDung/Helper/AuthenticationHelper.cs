using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using WebTuyenDung.Constants;
using WebTuyenDung.Enums;
using WebTuyenDung.Models;

namespace WebTuyenDung.Helper
{
    public static class AuthenticationHelper
    {
        public static string? GetAvatar(this ClaimsPrincipal identity)
        {
            return identity.FindFirstValue(AuthenticationConstants.AVATAR_CLAIM_KEY);
        }

        public static int GetUserId(this ClaimsPrincipal identity)
        {
            return int.Parse(identity.FindFirst(AuthenticationConstants.USER_ID_KEY)!.Value);
        }

        public static string GetName(this ClaimsPrincipal identity)
        {
            return identity.FindFirstValue(AuthenticationConstants.USER_FORMAL_NAME_KEY)!;
        }

        public static DateOnly? GetBirthDay(this ClaimsPrincipal identity)
        {
            var rawResult = identity.FindFirstValue(AuthenticationConstants.CANDIDATE_BIRTH_DAY_KEY);
            return rawResult == null ? null : DateOnly.ParseExact(rawResult, DateTimeFormatConstants.DATE_ONLY_FORMAT);
        }

        public static string? GetPhoneNumber(this ClaimsPrincipal identity)
        {
            return identity.FindFirstValue(AuthenticationConstants.CANDIDATE_PHONE_NUMBER_KEY);
        }

        public static string? GetAddress(this ClaimsPrincipal identity)
        {
            return identity.FindFirstValue(AuthenticationConstants.CANDIDATE_ADDRESS_KEY);
        }

        public static string? GetGender(this ClaimsPrincipal identity)
        {
            return identity.FindFirstValue(AuthenticationConstants.CANDIDATE_GENDER_KEY);
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

            if (user.Role == UserRole.Candidate)
            {
                var candidate = (user as Candidate)!;
                claims
                    .Add(ClaimTypes.DateOfBirth, candidate.BirthDay.GetApplicationTimeRepresentation())
                    .Add(ClaimTypes.MobilePhone, candidate.PhoneNumber)
                    .Add(ClaimTypes.StreetAddress, candidate.Address)
                    .Add(ClaimTypes.Gender, candidate.Gender.GetRepresentation());
            }

            var claimsIdentity = new ClaimsIdentity(claims, AuthenticationConstants.AUTHENTICATION_SCHEME);

            return new ClaimsPrincipal(claimsIdentity);
        }

        private static List<Claim> Add(this List<Claim> claims, string claimType, string claimValue)
        {
            claims.Add(new Claim(claimType, claimValue));
            return claims;
        }
    }
}
