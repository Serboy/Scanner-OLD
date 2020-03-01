using Scanner.API.Model.Domains;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Scanner.API.BusinessLogic.Services.Users {
    public interface IUserService {
        Task<User> SignIn(string username, string password);

        Task<IEnumerable<User>> GetUsers();
    }
}
