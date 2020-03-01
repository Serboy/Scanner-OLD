using AutoMapper;
using Microsoft.Extensions.Options;
using Newtonsoft.Json.Linq;
using Scanner.API.Common;
using Scanner.API.Common.Helpers;
using Scanner.API.Model.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Scanner.API.BusinessLogic.Repositories.Users {
    public class UserRepo : IUserRepo {
        private readonly IMapper _mapper;
        private readonly AppSetting _appSetting;

        public UserRepo(IMapper mapper, IOptions<AppSetting> appSetting) {
            _mapper = mapper;
            _appSetting = appSetting.Value;
        }

        /// <summary>
        /// Return's list of users from users.json
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<User>> GetUsers() {
            try {
                var path = AppConfig.GetPath(_appSetting.UserPath);

                return await ReadUsers(path);
            } catch {
                return new List<User>();
            }
        }

        /// <summary>
        /// Return's list of admin users from users-admin.json
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<User>> GetAdminUsers() {
            try {
                var path = AppConfig.GetPath(_appSetting.UserAdminPath);

                return await ReadUsers(path);
            } catch {
                return new List<User>();
            }
        }

        /// <summary>
        /// Sign in user admin
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="passWord"></param>
        /// <returns>User Admin Info</returns>
        public async Task<User> SignInAdmin(string username, string password) {
            var users = await GetAdminUsers();
            var user = users.FirstOrDefault(s => string.Equals(s.Username, username, StringComparison.InvariantCultureIgnoreCase));

            if (user == null)
                return null;

            if (string.Equals(user.Password, password, StringComparison.InvariantCulture))
                return user;

            return null;
        }

        /// <summary>
        /// Sign in user (employee)
        /// </summary>
        /// <param name="employeeId"></param>
        /// <returns>User (Employee) Info</returns>
        public async Task<User> SignIn(string employeeId) {
            var users = await GetUsers();

            return users.FirstOrDefault(s => string.Equals(s.EmployeeId, employeeId, StringComparison.InvariantCultureIgnoreCase));
        }

        #region ᶳ Private Methods ᶳ
        private async Task<IEnumerable<User>> ReadUsers(string path) {
            var strJson = await FileHelper.ReadFileAsync(path);

            if (string.IsNullOrEmpty(strJson))
                return new List<User>();

            var users = _mapper.Map<List<User>>(JArray.Parse(strJson));

            return users ?? new List<User>();
        }
        #endregion
    }
}
