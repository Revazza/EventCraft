using EventCraft.Domain.Users;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace EventCraft.Application.Authentication;

public interface IJwtTokenGenerator
{
    public string Generate(User user);
}


public class JwtTokenGenerator : IJwtTokenGenerator
{
    private readonly JwtSettings _settings;
    public JwtTokenGenerator(IOptions<JwtSettings> settings)
    {
        _settings = settings.Value;
    }

    public string Generate(User user)
    {
        var claims = new List<Claim>()
        {
            new Claim(JwtRegisteredClaimNames.Sub,user.Id.Value.ToString()),
            new Claim("userName",user.UserName!),
            new Claim(ClaimTypes.Role,"user")
        };

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_settings.SecretKey));
        var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
            issuer: _settings.Issuer,
            audience: _settings.Audience,
            claims: claims,
            expires: DateTime.UtcNow.AddMinutes(_settings.ExpirationMinutes),
            signingCredentials: credentials);

        var tokenGenerator = new JwtSecurityTokenHandler();
        var jwtString = tokenGenerator.WriteToken(token);
        return jwtString;
    }

}