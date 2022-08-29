using Application.DTOs;
using EfDataAccess;
using Implementation.Password;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Api.Core
{
    public class JwtManager
    {
        private readonly LibraryContext libraryContext;

        public JwtManager(LibraryContext libraryContext)
        {
            this.libraryContext = libraryContext;
        }

        public string MakeToken(LoginRequestDTO loginParams)
        {
            var user = libraryContext.Users.Include(u => u.UseCases)
                .FirstOrDefault(x => x.UserName == loginParams.Username);

            if (user == null)
            {
                return null;
            }
            if(!PasswordHandler.compareHasedPasswords(loginParams.Password, user.Password))
            {
                return null;
            }
            var actor = new JwtActor
            {
                Id = user.Id,
                AllowedUseCases = user.UseCases.Select(x => x.UseCaseId),
                Identity = user.UserName
            };

            var issuer = "asp_api";
            var secretKey = "ThisIsMyVerySecretKey";
            var claims = new List<Claim> 
            {
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString(), ClaimValueTypes.String, issuer),
                new Claim(JwtRegisteredClaimNames.Iss, "asp_api", ClaimValueTypes.String, issuer),
                new Claim(JwtRegisteredClaimNames.Iat, DateTimeOffset.UtcNow.ToUnixTimeSeconds().ToString(), ClaimValueTypes.Integer64, issuer),
                new Claim("UserId", actor.Id.ToString(), ClaimValueTypes.String, issuer),
                new Claim("ActorData", JsonConvert.SerializeObject(actor), ClaimValueTypes.String, issuer)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));

            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var now = DateTime.UtcNow;
            var token = new JwtSecurityToken(
                issuer: issuer,
                audience: "Any",
                claims: claims,
                notBefore: now,
                expires: now.AddHours(24),
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
