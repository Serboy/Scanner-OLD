using Android.App;
using Android.Runtime;
using Scanner.Client.BusinessLogic.Infrastructures;
using System;

namespace Scanner.Client {
    public class App : Application {
        public App(IntPtr handle, JniHandleOwnership transfer) : base (handle, transfer) {

        }

        public override void OnCreate() {
            Bootstrapper.Current.Build();
            base.OnCreate();
        }
    }
}