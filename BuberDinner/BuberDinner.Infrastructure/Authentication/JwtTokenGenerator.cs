using System.Security.Claims;
using BuberDinner.Application.Common.Interfaces.Authentication;
using Microsoft.IdentityModel.JsonWebTokens;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using BuberDinner.Application.Common.Interfaces.Services;
using Microsoft.Extensions.Options;

namespace BuberDinner.Infrastructure.Authentication;
public class JwtTokenGenerator : IJwtTokenGenerator
{
    private readonly IDateTimeProvider _dateTimeProvider;
    private readonly JwtSettings _jwtSettings;

    public JwtTokenGenerator(IDateTimeProvider dateTimeProvider, IOptions<JwtSettings> jwtOptions)
    {
        _dateTimeProvider = dateTimeProvider;
        _jwtSettings = jwtOptions.Value;
    }

    public string GenerateToken(Guid userId, string firstName, string lastName)
    {
        // Crete signingCredentials
        var signingCredentials = new SigningCredentials( 
            new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.Secret)),
            SecurityAlgorithms.HmacSha256
        );

        // Create clames
        var clames = new[]
        {
            new Claim(System.IdentityModel.Tokens.Jwt.JwtRegisteredClaimNames.Sub, userId.ToString()),
            new Claim(System.IdentityModel.Tokens.Jwt.JwtRegisteredClaimNames.GivenName, firstName),
            new Claim(System.IdentityModel.Tokens.Jwt.JwtRegisteredClaimNames.FamilyName, lastName),
            new Claim(System.IdentityModel.Tokens.Jwt.JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
        };

        // Create security token
        var securityToken = new JwtSecurityToken(
            issuer: _jwtSettings.Issuer,
            audience: _jwtSettings.Audience,
            expires: _dateTimeProvider.UtcNow.AddMinutes(_jwtSettings.ExpiryMinutes),
            claims: clames, 
            signingCredentials: signingCredentials
        );

        // return token
        return new JwtSecurityTokenHandler().WriteToken(securityToken);
    }
}