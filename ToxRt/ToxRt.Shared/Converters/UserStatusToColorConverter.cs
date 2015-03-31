using System;
using System.Collections.Generic;
using System.Text;
using Windows.UI;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Media;
using ToxRt.ViewModel;

namespace ToxRt.Converters
{
    public class UserStatusToColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            if (value == null) return null;

            switch ((Status)value)
            {
                case Status.Online:
                    return new SolidColorBrush(Colors.GreenYellow);
                    break;
                case Status.Offline:
                    return new SolidColorBrush(Colors.Red);
                    break;
                case Status.Away:
                    return new SolidColorBrush(Colors.Orange);
                    break;
                default:
                    return new SolidColorBrush(Colors.GreenYellow);

            }

        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
