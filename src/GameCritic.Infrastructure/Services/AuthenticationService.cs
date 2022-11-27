using GameCritic.Application.Common.Interfaces.Services;
using GameCritic.Domain.Auth;
using GameCritic.Infrastructure.Options;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace GameCritic.Infrastructure.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly JwtOptions _jwtOptions;
        private readonly UserManager<User> _userManager;
        private User? _user;

        public AuthenticationService(UserManager<User> userManager, IOptions<JwtOptions> jwtOptions)
        {
            _userManager = userManager;
            _jwtOptions = jwtOptions.Value;
        }

        public async Task<int> ValidateUsernameAndEmail(string username, string email)
        {
            var user1 = await _userManager.FindByNameAsync(username);
            var user2 = await _userManager.FindByEmailAsync(email);

            if (user1 != null)
                return 1;
            if (user2 != null)
                return 2;

            return 0;
        }

        public async Task<bool> ValidateUser(string email, string password)
        {
            _user = await _userManager.FindByEmailAsync(email);
            var validPassword = await _userManager.CheckPasswordAsync(_user, password);
            return _user != null && validPassword;
        }

        public async Task<string> CreateToken()
        {
            var key = _jwtOptions.GetSymmetricSecurityKey();
            var signingCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var claims = await GetClaims();
            var token = GenerateTokenOptions(signingCredentials, claims);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        private async Task<List<Claim>> GetClaims()
        {
            var claims = new List<Claim>
            {
                new(ClaimTypes.Name, _user.UserName),
                new(ClaimTypes.NameIdentifier, _user.Id.ToString())
            };

            var roles = await _userManager.GetRolesAsync(_user);
            var role = roles[0];

            claims.Add(new Claim(ClaimTypes.Role, role));

            return claims;
        }

        public async Task<string> GetUserRole(string EmailID)
        {
            var user = await _userManager.FindByEmailAsync(EmailID);
            var rolename = await _userManager.GetRolesAsync(user);
            return rolename[0];
        }

        private JwtSecurityToken GenerateTokenOptions(SigningCredentials signingCredentials, List<Claim> claims)
        {
            var token = new JwtSecurityToken(
                _jwtOptions.Issuer,
                _jwtOptions.Audience,
                claims,
                expires: DateTime.Now.AddDays(_jwtOptions.TokenLifetime),
                signingCredentials: signingCredentials
            ); ;
            return token;
        }
    }
}
