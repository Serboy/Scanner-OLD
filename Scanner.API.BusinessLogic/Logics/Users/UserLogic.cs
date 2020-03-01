using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Scanner.API.BusinessLogic.Repositories.Users;
using Scanner.API.Common.Extensions;
using Scanner.API.Model.Domains;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Scanner.API.BusinessLogic.Logics.Users {
    public class UserLogic : IUserLogic {
        private readonly IUserRepo _repo;
        private readonly AppSetting _appSetting;

        public UserLogic(IUserRepo repo, IOptions<AppSetting> appSetting) {
            _repo = repo;
            _appSetting = appSetting.Value;
        }

        public async Task<User> SignIn(User user) {
            if (IsAdmin(user, _appSetting))
                return GetToken(await _repo.SignInAdmin(user.Username, user.Password));

            if (string.IsNullOrEmpty(user.EmployeeId))
                return null;

            return GetToken(await _repo.SignIn(user.EmployeeId));
        }

        #region ᶳ Private Methods ᶳ
        private static bool IsAdmin(User user, AppSetting appSetting) {
            if (user.IsUser.ToBoolSafe())
                return false;

            var prefix = appSetting.UserAdminPrefix;

            return !user.IsUser.ToBoolSafe()
                && !string.IsNullOrEmpty(user.Username)
                && !string.IsNullOrEmpty(user.Password)
                && user.Username.StartsWith(prefix);
        }

        private User GetToken(User user) {
            if (user == null)
                return null;

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
        }
        #endregion
    }
}
