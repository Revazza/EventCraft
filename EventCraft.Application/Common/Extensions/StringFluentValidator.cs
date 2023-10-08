using EventCraft.Domain.Users;
using FluentValidation;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text.RegularExpressions;

namespace EventCraft.Application.Common.Extensions;

public static class StringFluentValidator
{
    public static IRuleBuilderOptions<T, string> MustBeEnglish<T>(
        this IRuleBuilderOptions<T, string> ruleBuilder)
    {
        return ruleBuilder.Must(s => Regex.IsMatch(s.Replace(" ", ""), "^[a-zA-Z0-9]*$")).WithMessage("'{PropertyName}' must be English");
    }

    public static UserId GetCurrentUserId(this ClaimsPrincipal principal)
    {
        var identity = principal.Identity as ClaimsIdentity ?? throw new UnauthorizedAccessException();

        var userId = identity.Claims.FirstOrDefault(c => c.Properties.Any(p => p.Value == JwtRegisteredClaimNames.Sub))?.Value;

        if (!Guid.TryParse(userId, out Guid parsedUserId))
        {
            throw new ArgumentNullException("User Id can't be parsed");
        }

        return new UserId(parsedUserId);
    }


}
