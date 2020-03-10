using Scanner.Client.Model.Domains;
using System.Threading;
using System.Threading.Tasks;

namespace Scanner.Client.BusinessLogic.Services.Users {
    public interface IUserService {
        Task<User> SignIn(string employeeId, CancellationToken cancellationToken);
        Task<User> SignInAdmin(string username, string password, CancellationToken cancellationToken);
    }
}
