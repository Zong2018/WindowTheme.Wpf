using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Data;
namespace WindowThemes.Wpf.Converters
{
    public class BorderCircularConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            double width, height;
            if (values.Length == 2 && values[0] is double && values[1] is double)
            {
                width = (double)values[0];
                height = (double)values[1];
                if (width < double.Epsilon || height < double.Epsilon)
                {
                    return new CornerRadius();
                }

                var min = Math.Min(width, height);
                return new CornerRadius(min / 2);
            }

            return DependencyProperty.UnsetValue;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }
}
