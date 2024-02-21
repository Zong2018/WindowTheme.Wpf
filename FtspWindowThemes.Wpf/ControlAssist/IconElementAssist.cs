using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace WindowThemes.Wpf.ControlAssist
{
    public static class IconElementAssist
    {
        public static double GetHeight(DependencyObject obj)
        {
            return (double)obj.GetValue(HeightProperty);
        }

        public static void SetHeight(DependencyObject obj, double value)
        {
            obj.SetValue(HeightProperty, value);
        }

        // Using a DependencyProperty as the backing store for BorderHeight.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty HeightProperty =
            DependencyProperty.RegisterAttached("Height", typeof(double), typeof(IconElementAssist), new PropertyMetadata(12.0));



        public static double GetWidth(DependencyObject obj)
        {
            return (double)obj.GetValue(WidthProperty);
        }

        public static void SetWidth(DependencyObject obj, double value)
        {
            obj.SetValue(WidthProperty, value);
        }

        // Using a DependencyProperty as the backing store for BorderWidth.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty WidthProperty =
            DependencyProperty.RegisterAttached("Width", typeof(double), typeof(IconElementAssist), new PropertyMetadata(12.0));



        public static Geometry GetGeometry(DependencyObject obj)
        {
            return (Geometry)obj.GetValue(GeometryProperty);
        }

        public static void SetGeometry(DependencyObject obj, Geometry value)
        {
            obj.SetValue(GeometryProperty, value);
        }

        // Using a DependencyProperty as the backing store for Geometry.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty GeometryProperty =
            DependencyProperty.RegisterAttached("Geometry", typeof(Geometry), typeof(IconElementAssist), new PropertyMetadata(null));

        public static Brush GetFillColor(DependencyObject obj)
        {
            return (Brush)obj.GetValue(FillColorProperty);
        }

        public static void SetFillColor(DependencyObject obj, Brush value)
        {
            obj.SetValue(FillColorProperty, value);
        }

        // Using a DependencyProperty as the backing store for MyProperty.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty FillColorProperty =
            DependencyProperty.RegisterAttached("FillColor", typeof(Brush), typeof(IconElementAssist), new PropertyMetadata(new SolidColorBrush(Color.FromArgb(255, 255, 77, 79))));
        public static Brush GetIconDock(DependencyObject obj)
        {
            return (Brush)obj.GetValue(IconDockProperty);
        }

        public static void SetIconDock(DependencyObject obj, Dock value)
        {
            obj.SetValue(IconDockProperty, value);
        }

        // Using a DependencyProperty as the backing store for MyProperty.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty IconDockProperty =
            DependencyProperty.RegisterAttached("IconDock", typeof(Dock), typeof(IconElementAssist), new PropertyMetadata(Dock.Left));

        public static Thickness GetIconMargin(DependencyObject obj)
        {
            return (Thickness)obj.GetValue(IconMarginProperty);
        }

        public static void SetIconMargin(DependencyObject obj, Thickness value)
        {
            obj.SetValue(IconMarginProperty, value);
        }

        // Using a DependencyProperty as the backing store for MyProperty.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty IconMarginProperty =
            DependencyProperty.RegisterAttached("IconMargin", typeof(Thickness), typeof(IconElementAssist), new PropertyMetadata(new Thickness(0, 0, 0, 0)));

        public static Brush GetMouseHoverForeground(DependencyObject obj)
        {
            return (Brush)obj.GetValue(MouseHoverForegroundProperty);
        }

        public static void SetMouseHoverForeground(DependencyObject obj, Brush value)
        {
            obj.SetValue(MouseHoverForegroundProperty, value);
        }

        // Using a DependencyProperty as the backing store for MouseHoverBackground.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty MouseHoverForegroundProperty =
            DependencyProperty.RegisterAttached("MouseHoverForeground", typeof(Brush), typeof(IconElementAssist), new PropertyMetadata(new SolidColorBrush(Color.FromArgb(255, 255, 255, 255))));


        public static Brush GetMouseDownForeground(DependencyObject obj)
        {
            return (Brush)obj.GetValue(MouseDownForegroundProperty);
        }

        public static void SetMouseDownForeground(DependencyObject obj, Brush value)
        {
            obj.SetValue(MouseDownForegroundProperty, value);
        }

        // Using a DependencyProperty as the backing store for MouseDownBackground.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty MouseDownForegroundProperty =
            DependencyProperty.RegisterAttached("MouseDownForeground", typeof(Brush), typeof(IconElementAssist), new PropertyMetadata(new SolidColorBrush(Color.FromArgb(255, 255, 255, 255))));
    }
}
