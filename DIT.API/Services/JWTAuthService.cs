using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using DIT.API.Options;
using DIT.Domain.Models;
using DIT.Domain.Models.AuthModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;


namespace DIT.API.Services
{
    public class JWTAuthService : IJWTAuthService
    {

        private readonly UserManager<User> _userManager;
        private readonly JWTOptions _jwtOptions;
        public JWTAuthService(UserManager<User> userManager, IOptions<JWTOptions> jwtOptions)
        {
            _userManager = userManager;
            _jwtOptions = jwtOptions.Value;
        }
        public async Task<JwtTokenResponse> Authenticate(string username, string password)
        {
            var user = await _userManager.FindByNameAsync(username);

            if (user != null && await _userManager.CheckPasswordAsync(user, password))
            {
                return BuildToken(username);
            }

            return new JwtTokenResponse();
        }

        private JwtTokenResponse BuildToken(string userName)
        {
            var (signingKey, audience, issuer, expirationTime, securityAlgorithm) = _jwtOptions;

            var authClaims = new[]
                {
                    new Claim(JwtRegisteredClaimNames.Sub, userName),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
                };

            var token = new JwtSecurityToken(
                issuer,
                audience,
                expires: DateTime.Now.AddHours(expirationTime),
                claims: authClaims,
                signingCredentials: GetSigningCredentials()
               );

            SigningCredentials GetSigningCredentials()
            {
                return new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(signingKey)), securityAlgorithm);
            }

            return new JwtTokenResponse
            {
                AccessToken = new JwtSecurityTokenHandler().WriteToken(token),
                Expiration = token.ValidTo
            };
        }
    }
}
