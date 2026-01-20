using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Pelebox.API.Security {
    public interface IJwtAuthenticationManager {
        string Authenticate(string UserID, string Email, string FirstName, string LastName);
    }

    public class JwtAuthenticationManager : IJwtAuthenticationManager {
        private readonly string key;
        private readonly string issuer;
        private readonly string audience;
        private readonly int expireMinutes;

        public JwtAuthenticationManager(string key, string issuer, string audience, int expireMinutes) {
            this.key = key;
            this.issuer = issuer;
            this.audience = audience;
            this.expireMinutes = expireMinutes;
        }

        public string Authenticate(string UserID, string Email, string FirstName, string LastName) {
            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenKey = Encoding.ASCII.GetBytes(key);

            var tokenDescriptor = new SecurityTokenDescriptor {
                Subject = new ClaimsIdentity(new Claim[] {
                    new (ClaimTypes.Name, UserID),
                    new (ClaimTypes.Email, Email),
                    new ("FirstName", FirstName),
                    new ("LastName", LastName)
                }),
                Expires = DateTime.UtcNow.AddMinutes(expireMinutes),
                Issuer = issuer,
                Audience = audience,
                SigningCredentials =
                new SigningCredentials(
                    new SymmetricSecurityKey(tokenKey),
                    SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}