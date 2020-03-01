using Scanner.API.Model.Domains;
using System.Threading.Tasks;

namespace Scanner.API.BusinessLogic.Logics.Users {
    public interface IUserLogic {
        Task<User> SignIn(User user);
    }
}
