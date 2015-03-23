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
                    return Colors.GreenYellow;
                    break;
                case Status.Offline:
                    return Colors.Red;
                    break;
                case Status.DontInterrupt:
                    return Colors.Orange;
                    break;
                default:
                    return Colors.GreenYellow;

            }

        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
