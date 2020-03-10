using Scanner.Client.BusinessLogic.Managers;
using Scanner.Client.BusinessLogic.Services.Users;
using Scanner.Client.Model.Domains;
using System.Threading;
using System.Threading.Tasks;

namespace Scanner.Client.BusinessLogic.Logics.Users {
    public class UserLogic : IUserLogic {
        private readonly IUserService _userService;
        private readonly AppSetting _appSetting;

        public UserLogic(IUserService userService) {
            _userService = userService;
            _appSetting = AppSettingManager.Current.Setting;
        }

        public bool IsAdmin(string username) {
            return !string.IsNullOrEmpty(username)
                && username.StartsWith(_appSetting.UserService.UserPrefix);
        }

        public async Task<User> SignIn(string username, string password, CancellationToken cancellationToken) {
            var isAdmin = IsAdmin(username);

            if (isAdmin)
                return await _userService.SignInAdmin(username, password, cancellationToken);

            return await _userService.SignIn(username, cancellationToken);
        }
    }
}
