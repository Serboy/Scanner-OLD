using Scanner.Client.Model.Domains;
using System.Threading;
using System.Threading.Tasks;

namespace Scanner.Client.BusinessLogic.Logics.Users {
    public interface IUserLogic {
        bool IsAdmin(string username);
        Task<User> SignIn(string username, string password, CancellationToken cancellationToken);
    }
}
