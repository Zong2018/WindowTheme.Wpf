using WindowThemes.Wpf.Common;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Data;
using System.Windows.Media;

namespace WindowThemes.Wpf.Converters
{
    internal class ScaleConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            //0是InnerWidth，1是InnerHeight
            var minvalue = (double)values[0] < (double)values[1] ? (double)values[0] : (double)values[1];
            return minvalue / 22;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            return new object[] { DependencyProperty.UnsetValue, DependencyProperty.UnsetValue };
        }
    }

    internal class ToggleTranslateXConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            //0是InnerWidth，1是InnerHeight
            return ((double)values[0] - (double)values[1] + 1) * -1;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            return new object[] { DependencyProperty.UnsetValue, DependencyProperty.UnsetValue };
        }
    }

    internal class ToHalfConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return (double)value / 2;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return DependencyProperty.UnsetValue;
        }
    }

    internal class ToggleHeightConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return (double)value - 2;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return DependencyProperty.UnsetValue;
        }
    }

    internal class BubbleConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            var location = (AnglePositions)values[0];
            var radius = (CornerRadius)values[1];
            var width = (double)values[2];
            var height = (double)values[3];
            var path = "";
            switch (location)
            {
                case AnglePositions.Left:
                    if (radius == new CornerRadius(0))
                        path = "M0," + height / 2 + "L5," + (height / 2 + 4) +
                            "V" + height + "H" + width + "V 0 H 5 V" + (height / 2 - 4) + "Z";
                    else
                        path = "M0," + height / 2 + "L5," + (height / 2 + 4) +
                            "V" + (height - radius.BottomLeft) + "A" + radius.BottomLeft + "," + radius.BottomLeft + " 0 0 0 " + (5 + radius.BottomLeft) + "," + height +
                            "H" + (width - radius.BottomRight) + "A" + radius.BottomRight + "," + radius.BottomRight + " 0 0 0 " + width + "," + (height - radius.BottomRight) +
                            "V" + radius.TopRight + "A" + radius.TopRight + "," + radius.TopRight + " 0 0 0 " + (width - radius.TopRight) + "," + 0 +
                            "H" + (5 + radius.TopLeft) + "A" + radius.TopLeft + "," + radius.TopLeft + " 0 0 0 " + 5 + "," + radius.TopLeft +
                            "V" + (height / 2 - 4) + "Z";
                    break;
                case AnglePositions.BottomLeft:
                    if (radius == new CornerRadius(0))
                        path = "M0," + height + "L4," + (height - 5) +
                        "H " + width + "V 0 H 0 Z";
                    else
                        path = "M0," + height + "L4," + (height - 5) +
                            "H" + (width - radius.BottomRight) + "A" + radius.BottomRight + "," + radius.BottomRight + " 0 0 0 " + width + "," + (height - radius.BottomRight - 5) +
                            "V" + radius.TopRight + "A" + radius.TopRight + "," + radius.TopRight + " 0 0 0 " + (width - radius.TopRight) + "," + 0 +
                            "H" + radius.TopLeft + "A" + radius.TopLeft + "," + radius.TopLeft + " 0 0 0 " + 0 + "," + radius.TopLeft +
                            "Z";

                    break;
                case AnglePositions.BottomCenter:
                    if (radius == new CornerRadius(0))
                        path = "M" + width / 2 + "," + height + "L" + (width / 2 + 5) + "," + (height - 4) +
                            "H" + width + "V 0 H 0 V" + (height - 4) + "H" + (width / 2 - 5) + "Z";
                    else
                        path = "M" + width / 2 + "," + height + "L" + (width / 2 + 5) + "," + (height - 4) +
                            "H" + (width - radius.BottomRight) + "A" + radius.BottomRight + "," + radius.BottomRight + " 0 0 0 " + width + "," + (height - radius.BottomRight - 5) +
                            "V" + radius.TopRight + "A" + radius.TopRight + "," + radius.TopRight + " 0 0 0 " + (width - radius.TopRight) + "," + 0 +
                            "H" + radius.TopLeft + "A" + radius.TopLeft + "," + radius.TopLeft + " 0 0 0 " + 0 + "," + radius.TopLeft +
                            "V" + (height - radius.BottomRight - 5) + "A" + radius.BottomRight + "," + radius.BottomRight + " 0 0 0 " + radius.BottomRight + "," + (height - 5) +
                            "H" + (width / 2 - 5) + "Z";

                    break;
                case AnglePositions.BottomRightNotEnd:
                    if (radius == new CornerRadius(0))
                        path = "M" +(width - 20) + "," + height + "L" + ((width - 20) + 5) + "," + (height - 4) +
                            "H" + width + "V 0 H 0 V" + (height - 4) + "H" + ((width - 20) - 5) + "Z";
                    else
                        path = "M" + (width - 20) + "," + height + "L" + ((width - 20) + 5) + "," + (height - 4) +
                            "H" + (width - radius.BottomRight) + "A" + radius.BottomRight + "," + radius.BottomRight + " 0 0 0 " + (width-2) + "," + (height - radius.BottomRight -2) +
                            "V" + radius.TopRight + "A" + radius.TopRight + "," + radius.TopRight + " 0 0 0 " + (width - radius.TopRight-1) + "," + 1 +
                            "H" + radius.TopLeft + "A" + radius.TopLeft + "," + radius.TopLeft + " 0 0 0 " + 1 + "," + radius.TopLeft +
                            "V" + (height - radius.BottomRight - 5) + "A" + radius.BottomRight + "," + radius.BottomRight + " 0 0 0 " + radius.BottomRight + "," + (height - 5) +
                            "H" + ((width - 20) - 5) + "Z";

                    break;
                case AnglePositions.BottomRight:
                    if (radius == new CornerRadius(0))
                        path = "M" + width + "," + height + "V 0 H 0 V " + (height - 4) + "H" + (width - 5) + "Z";
                    else
                        path = "M" + width + "," + height + "V" + radius.TopRight + "A" + radius.TopRight + "," + radius.TopRight + " 0 0 0 " + (width - radius.TopRight) + "," + 0 +
                            "H" + radius.TopLeft + "A" + radius.TopLeft + "," + radius.TopLeft + " 0 0 0 " + 0 + "," + radius.TopLeft +
                            "V" + (height - radius.BottomRight - 5) + "A" + radius.BottomRight + "," + radius.BottomRight + " 0 0 0 " + radius.BottomRight + "," + (height - 5) +
                            "H" + (width - 5) + "Z";
                    break;
                case AnglePositions.Right:
                    if (radius == new CornerRadius(0))
                        path = "M" + width + "," + height / 2 + "L" + (width - 5) + "," + (height / 2 - 4) + "V 0 H 0 V" +
                        height + "H " + (width - 5) + "V" + (height / 2 + 4) + "Z";
                    else
                        path = "M" + width + "," + height / 2 + "L" + (width - 5) + "," + (height / 2 - 4) + "V" + radius.TopRight + "A" + radius.TopRight + "," + radius.TopRight + " 0 0 0 " + (width - radius.TopRight - 5) + "," + 0 +
                            "H" + radius.TopLeft + "A" + radius.TopLeft + "," + radius.TopLeft + " 0 0 0 " + 0 + "," + radius.TopLeft +
                            "V" + (height - radius.BottomLeft) + "A" + radius.BottomLeft + "," + radius.BottomLeft + " 0 0 0 " + radius.BottomLeft + "," + height +
                            "H" + (width - radius.BottomRight - 5) + "A" + radius.BottomRight + "," + radius.BottomRight + " 0 0 0 " + (width - 5) + "," + (height - radius.BottomRight) +
                            "V" + (height / 2 + 4) + "Z";
                    break;
            }
            return Geometry.Parse(path);
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            return new object[] { DependencyProperty.UnsetValue, DependencyProperty.UnsetValue };
        }
    }

    internal class DropDownBorderPathConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            var width = values[0] as double? ?? 0;
            var height = values[1] as double? ?? 0;

            var contentWidth = values[2] as double? ?? 0;
            var contentHeight = values[3] as double? ?? 0;

            var placement = values[4] as DropDownPlacement? ?? DropDownPlacement.LeftBottom;
            var radius = values[5] as double? ?? 0;

            var path = "";
            switch (placement)
            {
                case DropDownPlacement.LeftBottom:
                    path = $"M 1,{radius + 7} A{radius},{radius} 0 0 1 {radius + 1}, 7 H {width - contentWidth / 2 - 5} L {width - contentWidth / 2},1 L {width - contentWidth / 2 + 5},7   H {width - radius - 1} A{radius},{radius} 0 0 1 {width - 1}, {radius + 7}" +
                        $"V {height - radius - 1} A{radius},{radius} 0 0 1 {width - radius - 1}, {height - 1} H {radius + 1} A{radius},{radius} 0 0 1 1, {height - radius - 1} Z";
                    break;
            }

            return Geometry.Parse(path);
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            return new object[] { DependencyProperty.UnsetValue, DependencyProperty.UnsetValue };
        }
    }
}
