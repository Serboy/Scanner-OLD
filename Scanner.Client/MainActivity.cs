using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using System.Threading.Tasks;
using Android.Content;
using Scanner.Client.Activities;
using Scanner.Client.BusinessLogic.Infrastructures;
using Scanner.Client.BusinessLogic.Managers;

namespace Scanner.Client {
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : Activity {
        protected override void OnCreate(Bundle savedInstanceState) {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);

            AppSettingManager.Current.ReadAppSetting();
            Bootstrapper.Current.Build();

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults) {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }

        protected override void OnResume() {
            base.OnResume();
            Task task = new Task(() => { OpenLogin(); });
            task.Start();
        }

        private async void OpenLogin() {
            var intent = new Intent(this, typeof(LoginActivity));

            await Task.Delay(500);

            StartActivity(intent);
            OverridePendingTransition(Resource.Animation.slideToRight, Resource.Animation.slideToLeft);
            Finish();
        }
    }
}