using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Communicator_Backend.Models.JWT;
using Communicator_Backend.Repositories;
using Microsoft.IdentityModel.Tokens;

namespace Communicator_Backend.Services
{
    public class AuthService : IAuthService
    {
        private readonly IUserRepository userRepository;
        private readonly JWTConfiguration configuration;

        public AuthService(IUserRepository userRepository, JWTConfiguration configuration)
        {
            this.userRepository = userRepository;
            this.configuration = configuration;
        }

        public AccessToken GetToken(UserIdentity identity)
        {
            var user = this.userRepository.GetUser(identity.Login);
            if(user == null)
            {
                throw new KeyNotFoundException();
            }

            var toHash = $"{identity.Password}{user.Salt}";

            string md5Password = string.Empty;
            using (MD5 md5Hash = MD5.Create())
            {
                md5Password = GetMd5Hash(md5Hash, toHash);
            }

            if (user.Password.ToLower() == md5Password.ToLower())
            {
                var claims = new[]
                {
                    new Claim(ClaimTypes.Name, user.Login)
                };

                var key = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(configuration.SecretKey));
                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                var expiredOn = DateTime.Now.AddMinutes(configuration.TokenExpirationTime);
                var token = new JwtSecurityToken(configuration.ValidIssuer,
                      configuration.ValidAudience,
                      claims,
                      expires: expiredOn,
                      signingCredentials: creds);

                return new AccessToken
                {
                    ExpireOnDate = token.ValidTo,
                    Success = true,
                    ExpiryIn = configuration.TokenExpirationTime,
                    Token = new JwtSecurityTokenHandler().WriteToken(token)
                };
            }
            else
            {
                throw new UnauthorizedAccessException();
            }
        }

        public static string GetMd5Hash(MD5 md5Hash, string input)
        {
            byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));
            StringBuilder sBuilder = new StringBuilder();
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }
            return sBuilder.ToString();
        }
    }
}
