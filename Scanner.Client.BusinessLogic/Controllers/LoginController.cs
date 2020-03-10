using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;
using Android.App;
using Scanner.Client.BusinessLogic.Helpers.Utils;
using Scanner.Client.BusinessLogic.Logics.Users;
using Scanner.Client.BusinessLogic.Managers;
using Scanner.Client.BusinessLogic.ViewModels;
using Scanner.Client.Model.Domains;
using Xamarin.Forms;

namespace Scanner.Client.BusinessLogic.Controllers {
    public class LoginController : BaseViewModel {
        private readonly IUserLogic _userLogic;

        public LoginController(IUserLogic userLogic) {
            _userLogic = userLogic;
            
            InitializeComponent();
        }

        #region ᶳ Properties ᶳ
        private LoginViewModel _loginViewModel;
        public LoginViewModel LoginViewModel {
            get { return _loginViewModel; }
            set {
                if (_loginViewModel == value)
                    return;
                _loginViewModel = value;
                RaisePropertyChanged(() => LoginViewModel);
            }
        }
        #endregion

        #region ᶳ Commands ᶳ

        public ICommand LoginCmd { get; private set; }
        #endregion

        #region ᶳ Private Methods ᶳ
        private void InitializeComponent() {
            LoginViewModel = new LoginViewModel {
                Logo = AppSettingManager.Current.Setting.Resource.Image.MainLogo,
                UserIcon = AppSettingManager.Current.Setting.Resource.Image.UserIcon
            };

            LoginCmd = new Command(async() => await Login());
        }
        #endregion

        #region ᶳ Methods ᶳ
        private async Task<User> Login() {
            if (_userLogic.IsAdmin(LoginViewModel.Username))
                return await Task.FromResult(new User());

            var dialog = new AlertDialog.Builder(Xamarin.Forms.Forms.Context);
            var result = await _userLogic.SignIn(LoginViewModel.Username, LoginViewModel.Password, CancellationToken.None);

            dialog.SetTitle("Information");
            dialog.SetMessage("HELLO");
            dialog.Show();

            return result;
        }

        public void Test() {

        }
        #endregion
    }
}