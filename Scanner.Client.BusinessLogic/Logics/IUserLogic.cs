using Scanner.Client.Model.Domains;
using System.Threading;
using System.Threading.Tasks;

namespace Scanner.Client.BusinessLogic.Logics {
    public interface IUserLogic {
        Task<User> SignIn(string username, string password, CancellationToken cancellationToken);
    }
}
