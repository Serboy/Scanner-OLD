using Scanner.Client.BusinessLogic.Managers;
using Scanner.Client.BusinessLogic.Services;
using Scanner.Client.Model.Domains;
using System.Threading;
using System.Threading.Tasks;

namespace Scanner.Client.BusinessLogic.Logics {
    public class UserLogic : IUserLogic {
        private IUserService _userService;
        private readonly AppSetting _setting;

        public UserLogic(IUserService userService) {
            _userService = userService;
            _setting = AppSettingManager.Current.Setting;
        }

        public bool IsAdmin(string username) {
            return !string.IsNullOrEmpty(username)
                && username.StartsWith(_setting.UserService.UserPrefix);
        }

        public async Task<User> SignIn(string username, string password, CancellationToken cancellationToken) {
            var isUser = IsAdmin(username);
            var result = await _userService.SignIn(username, password, isUser, cancellationToken);

            return result;
        }
    }
}
