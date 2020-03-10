using Android.Graphics.Drawables;
using Scanner.Client.APK.TextField;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(BorderlessEntry), typeof(BorderlessEntryRenderer))]
namespace Scanner.Client.APK.TextField {
    public class BorderlessEntryRenderer : EntryRenderer {
        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e) {
            base.OnElementChanged(e);
 
            if (Control != null)
                Control.Background = new ColorDrawable(Android.Graphics.Color.Transparent);
        }
    }
}