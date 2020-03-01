using Scanner.Client.BusinessLogic.Services;
using Scanner.Client.Model.Domains;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Scanner.Client.BusinessLogic.Logics {
    public class UserLogic : IUserLogic {
        private IUserService _userService;
        public UserLogic(IUserService userService) {
            _userService = userService;
        }
        public async Task<User> SignIn(string username, string password, CancellationToken cancellationToken) {
            var result = await _userService.SignIn(username, password, cancellationToken);

            return result;
        }
    }
}
