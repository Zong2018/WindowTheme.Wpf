using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Media;

namespace WindowThemes.Wpf.ControlAssist
{
    public static class ButtonAssist
    {
        /// <summary>
        /// 登录时的内容
        /// </summary>     
        public static string GetExContentText(DependencyObject obj)
        {
            return (string)obj.GetValue(ExContentTextProperty);
        }

        public static void SetExContentText(DependencyObject obj, string value)
        {
            obj.SetValue(ExContentTextProperty, value);
        }

        // Using a DependencyProperty as the backing store for BorderHeight.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ExContentTextProperty =
            DependencyProperty.RegisterAttached("ExContentText", typeof(string), typeof(ButtonAssist), new PropertyMetadata(""));

        /// <summary>
        /// 登录时的内容
        /// </summary>     
        public static bool GetIsShowExText(DependencyObject obj)
        {
            return (bool)obj.GetValue(IsShowExTextProperty);
        }

        public static void SetIsShowExText(DependencyObject obj, bool value)
        {
            obj.SetValue(IsShowExTextProperty, value);
        }

        // Using a DependencyProperty as the backing store for BorderHeight.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty IsShowExTextProperty =
            DependencyProperty.RegisterAttached("IsShowExText", typeof(bool), typeof(ButtonAssist), new PropertyMetadata(false));
    }
}
