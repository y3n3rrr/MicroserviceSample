using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace IdentityService.Services
{
    public class IdentityService : IIdentityService
    {
        public Task<LoginResponseModel> SignInAsync(LoginRequestModel requestModel)
        {
            var claims = new Claim[]
{
                new Claim(ClaimTypes.NameIdentifier, requestModel.Username),
                new Claim(ClaimTypes.Name, "Floward Admin"),
};

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("ThisIsCoolFlowardSecretKeyShouldBeSafe"));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var expiry = DateTime.Now.AddDays(10);

            var token = new JwtSecurityToken(claims: claims, expires: expiry, signingCredentials: creds, notBefore: DateTime.Now);

            var encodedJwt = new JwtSecurityTokenHandler().WriteToken(token);

            LoginResponseModel response = new()
            {
                Token = encodedJwt,
            };

            return Task.FromResult(response);
        }
    }
}