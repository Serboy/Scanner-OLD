using Scanner.API.Model.Domains;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Scanner.API.BusinessLogic.Repositories.Users {
    public interface IUserRepo {
        Task<IEnumerable<User>> GetUsers();
        Task<IEnumerable<User>> GetAdminUsers();
        Task<User> SignInAdmin(string username, string password);
        Task<User> SignIn(string employeeId);
    }
}
