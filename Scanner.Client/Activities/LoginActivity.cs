using Android.App;
using Android.OS;
using Android.Widget;
using Autofac;
using Scanner.Client.BusinessLogic.Infrastructures;
using Scanner.Client.BusinessLogic.Logics;
using System.Threading;

namespace Scanner.Client.Activities {
    [Activity(Label = "LoginActivity")]
    public class LoginActivity : Activity {
        private IUserLogic _userLogic;

        public LoginActivity() {
            
        }

        protected override void OnCreate(Bundle savedInstanceState) {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.Login);
            InitializeComponent();
        }

        private void InitializeComponent() {
            var btnLogin = FindViewById<Button>(Resource.Id.btnLogin);

            _userLogic = Bootstrapper.Current.Container.Resolve<IUserLogic>();

            btnLogin.Click += OnBtnLoginClicked;
        }

        private async void OnBtnLoginClicked(object sender, System.EventArgs e) {
            var dialog = new AlertDialog.Builder(this);
            var alert = dialog.Create();

            var user = FindViewById<EditText>(Resource.Id.txtUname);
            var pass = FindViewById<EditText>(Resource.Id.txtPword);

            var result = await _userLogic.SignIn(user.Text, pass.Text, CancellationToken.None);

            alert.SetTitle("Information");
            alert.SetTitle($"First Name: {result.FirstName} Last Name: {result.LastName}");
            alert.SetMessage($"Token: {result.Token}");
            alert.Show();
        }
    }
}