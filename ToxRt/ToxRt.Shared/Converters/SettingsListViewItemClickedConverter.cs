using System;
using System.Collections.Generic;
using System.Text;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Data;
using ToxRt.ViewModel;

namespace ToxRt.Converters
{
    public class SettingsListViewItemClickedConverter:IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            var args = value as ItemClickEventArgs;
            if (args != null)
            {
                var setting = (args.ClickedItem as SettingTypeItem).SettingsType ;
                return setting;
            }
            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
