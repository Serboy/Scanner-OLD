using Newtonsoft.Json.Linq;
using Scanner.Client.BusinessLogic.Managers;
using Scanner.Client.Model.Domains;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Scanner.Client.BusinessLogic.Services.Users {
    public class UserService : BaseService, IUserService {
        private readonly AppSetting _setting;

        public UserService() {
            _setting = AppSettingManager.Current.Setting;
        }

        public async Task<User> SignIn(string employeeId, CancellationToken cancellationToken) {
            try {
                var jObj = JObject.FromObject(new {
                    employeeId,
                    isUser = true
                });
                var result = await PostAsync(_setting.BaseService,
                    $"{_setting.UserService.Url}{_setting.UserService.SignIn}",
                    jObj, cancellationToken);

                return result.ToObject<User>();
            } catch {
                return null;
            }
        }

        public async Task<User> SignInAdmin(string username, string password, CancellationToken cancellationToken) {
            try {
                var jObj = JObject.FromObject(new {
                    username,
                    password,
                    isUser = false
                });

                var result = await PostAsync(_setting.BaseService,
                    $"{_setting.UserService.Url}{_setting.UserService.SignIn}",
                    jObj, cancellationToken);

                return result.ToObject<User>();
            } catch {
                return null;
            }
        }
    }
}
