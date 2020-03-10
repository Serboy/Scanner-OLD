using Autofac;
using Scanner.Client.BusinessLogic.Controllers;
using Scanner.Client.BusinessLogic.Infrastructures;

namespace Scanner.Client.BusinessLogic {
    public class MainViewModel {
        public LoginController LoginController {
            get {
                return Bootstrapper.Current.Container.Resolve<LoginController>();
            }
        }
    }
}
