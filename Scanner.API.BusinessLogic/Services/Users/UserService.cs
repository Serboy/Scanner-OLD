using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Scanner.API.Model.Domains;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Scanner.API.BusinessLogic.Services.Users {
    public class UserService : IUserService {
        private readonly AppSetting _appSetting;

        public UserService(IOptions<AppSetting> appSetting) {
            _appSetting = appSetting.Value;
        }

        public async Task<User> SignIn(string username, string password) {
            var task = Task.Factory.StartNew(() => {
                var user = new User {
                    Id = 1,
                    FirstName = "Serboy",
                    LastName = "Terbas",
                    Username = "serboy",
                    Password = "serboy"
                };
                var handler = new JwtSecurityTokenHandler();
                var secretKey = Encoding.ASCII.GetBytes(_appSetting.Secret);
                var descriptor = new SecurityTokenDescriptor {
                    Subject = new ClaimsIdentity(new Claim[] {
                        new Claim(ClaimTypes.Name, user.Id.ToString())
                    }),
                    Expires = DateTime.UtcNow.AddMinutes(60),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(secretKey),
                        SecurityAlgorithms.HmacSha256Signature)
                };
                var token = handler.CreateToken(descriptor);

                user.Token = handler.WriteToken(token);

                return user;
            });

            return await task;
        }

        public async Task<IEnumerable<User>> GetUsers() {
            var task = Task.Factory.StartNew(() => {
                var users = new List<User>();

                for (var x = 0; x < 10; x++)
                    users.Add(new User {
                        Id = x,
                        FirstName = $"First {x}",
                        LastName = $"Last {x}",
                        Username = $"User {x}"
                    });

                return users;
            });

            return await task;
        }
    }
}
