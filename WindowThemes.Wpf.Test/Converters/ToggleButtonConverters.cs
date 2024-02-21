using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Data;
using System.Windows.Media;

namespace WindowThemesDemo.Converters
{
    public class ToggleButtonSiteConverters : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null) return HorizontalAlignment.Left;
            if ((bool)value)
            {
                return HorizontalAlignment.Right;
            }
            return HorizontalAlignment.Left;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return Binding.DoNothing;
        }
    }

    public class ToggleButtonZIndexConverters : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null) return 11;
            if ((bool)value)
            {
                return 11;
            }
            return 11;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return Binding.DoNothing;
        }

    }
    public class ToggleButtonForegroundConverters : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null) return ColorConverter.ConvertFromString("#7A378B");
            if ((bool)value)
            {
                return ColorConverter.ConvertFromString("#7A378B");
            }
            return ColorConverter.ConvertFromString("#7A378B");
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return Binding.DoNothing;
        }
    }
}
