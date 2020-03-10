using Scanner.Client.BusinessLogic.Helpers.Utils;
using Scanner.Client.Model.Domains;

namespace Scanner.Client.BusinessLogic.ViewModels {
    public class LoginViewModel : BaseViewModel {
        #region ᶳ Properties ᶳ
        public string Logo { get; set; }
        public string UserIcon { get; set; }
        #endregion

        #region ᶳ Presentation Properties ᶳ
        private string _username;
        public string Username {
            get { return _username; }
            set {
                if (_username == value)
                    return;
                _username = value;
                RaisePropertyChanged(() => Username);
            }
        }

        private string _password;
        public string Password {
            get { return _password; }
            set {
                if (_password == value)
                    return;
                _password = value;
                RaisePropertyChanged(() => Password);
            }
        }
        
        public User User { get; set; }
        #endregion
    }
}
