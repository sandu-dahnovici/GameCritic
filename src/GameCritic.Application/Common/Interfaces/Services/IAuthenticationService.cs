using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace GameCritic.Application.Common.Interfaces.Services
{
    public interface IAuthenticationService
    {
        Task<bool> ValidateUser(string email, string password);
        Task<string> CreateToken();
        Task<int> ValidateUsernameAndEmail(string username, string email);
    }
}
