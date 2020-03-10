using Android.Graphics.Drawables;
using Scanner.Client.BusinessLogic.Helpers.Elements;
using Scanner.Client.BusinessLogic.Helpers.Elements.Apk;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(BorderlessEntry), typeof(BorderlessEntryApkRenderer))]
namespace Scanner.Client.BusinessLogic.Helpers.Elements.Apk {
    public class BorderlessEntryApkRenderer : EntryRenderer {
        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e) {
            base.OnElementChanged(e);
 
            if (Control != null)
                Control.Background = new ColorDrawable(Android.Graphics.Color.Transparent);
        }
    }
}