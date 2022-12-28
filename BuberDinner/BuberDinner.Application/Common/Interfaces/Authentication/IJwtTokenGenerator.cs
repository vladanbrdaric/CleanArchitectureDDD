using BuberDinner.BuberDinner.Domain.Entities;

namespace BuberDinner.Application.Common.Interfaces.Authentication;
public interface IJwtTokenGenerator
{
    string GenerateToken(User user);
}