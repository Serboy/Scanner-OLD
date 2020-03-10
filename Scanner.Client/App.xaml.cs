using Scanner.Client.BusinessLogic.Infrastructures;
using Scanner.Client.BusinessLogic.Managers;
using Scanner.Client.Pages;
using Xamarin.Forms;

namespace Scanner.Client {
    public partial class App : Application {
        public App() {
            InitializeComponent();

            HotReloader.Current.Run(this);
            AppSettingManager.Current.Initialize();
            Bootstrapper.Current.Build();

            //MainPage = new MainPage();
            MainPage = new Login();
        }

        protected override void OnStart() {
        }

        protected override void OnSleep() {
        }

        protected override void OnResume() {
        }
    }
}
