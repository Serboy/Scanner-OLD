using Scanner.Client.Model.Domains;
using System.Threading;
using System.Threading.Tasks;

namespace Scanner.Client.BusinessLogic.Services {
    public interface IUserService {
        Task<User> SignIn(string username, string password, bool isUser, CancellationToken cancellationToken);
    }
}
