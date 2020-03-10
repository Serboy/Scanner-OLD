using Scanner.Client.Common;
using Scanner.Client.Common.Extensions;
using System;
using System.Globalization;
using Xamarin.Forms;

namespace Scanner.Client.BusinessLogic.Helpers.Converters {
    public class ImageSourceConverter : IValueConverter {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture) {
            if (value == null || string.IsNullOrEmpty(value.ToStringSafe()))
                return string.Empty;

            return ImageSource.FromResource(value.ToStringSafe(), AppConfig.GetAssembly("Scanner.Client"));
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) {
            throw new NotImplementedException();
        }
    }
}
