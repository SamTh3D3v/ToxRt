using System;
using System.Collections.Generic;
using System.Text;
using Windows.UI.Xaml.Data;
using ToxRt.ViewModel;

namespace ToxRt.Converters
{
    public class OnlineToIsCheckedConverter:IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            return ((Status)value == Status.Online);
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            if ((bool)value)
            {
                return Status.Online;
            }
            return Status.Offline;
        }
    }
    public class OfflineToIsCheckedConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            return ((Status)value == Status.Offline);
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            if ((bool)value)
            {
                return Status.Offline;
            }
            return Status.Away;
        }
    }
    public class AwayToIsCheckedConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            return ((Status)value == Status.Away);
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            if ((bool)value)
            {
                return Status.Away;
            }
            return Status.Online;
        }
    }
}
