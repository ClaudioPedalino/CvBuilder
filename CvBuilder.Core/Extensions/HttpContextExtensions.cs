using Microsoft.AspNetCore.Http;
using System.IdentityModel.Tokens.Jwt;

namespace CvBuilder.Core.Extensions
{
    public static class HttpContextExtensions
    {
        public static string GetUserNameFromToken(this IHttpContextAccessor httpContextAccesor)
        {
            var jwtToken = httpContextAccesor.HttpContext.Request
                .Headers["Authorization"]
                .ToString()
                .Replace("Bearer ", string.Empty);

            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenValues = tokenHandler.ReadJwtToken(jwtToken);
            var userEmail = tokenValues.Subject;

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"The user requester is: {userEmail}");
            Console.ResetColor();

            return userEmail;
        }
    }
}
