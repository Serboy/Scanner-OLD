using Scanner.Client.Common;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Scanner.Client.BusinessLogic.Helpers {
    [ContentProperty(nameof(Source))]
    public class ImageSourceMarkup : IMarkupExtension {
        public string Source { get; set; }

        public object ProvideValue(IServiceProvider serviceProvider) {
            if (Source == null)
                return null;

            return ImageSource.FromResource(Source, AppConfig.GetAssembly("Scanner.Client"));
        }
    }
}
