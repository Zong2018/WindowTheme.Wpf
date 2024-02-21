﻿using WindowThemes.Wpf.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media;

namespace WindowThemes.Wpf.ControlAssist
{
    public static class BorderElementAssist
    {
        public static readonly DependencyProperty CornerRadiusProperty = DependencyProperty.RegisterAttached(
    "CornerRadius", typeof(CornerRadius), typeof(BorderElementAssist), new FrameworkPropertyMetadata(default(CornerRadius), FrameworkPropertyMetadataOptions.Inherits));

        public static void SetCornerRadius(DependencyObject element, CornerRadius value) => element.SetValue(CornerRadiusProperty, value);

        public static CornerRadius GetCornerRadius(DependencyObject element) => (CornerRadius)element.GetValue(CornerRadiusProperty);

        public static readonly DependencyProperty CircularProperty = DependencyProperty.RegisterAttached(
            "Circular", typeof(bool), typeof(BorderElementAssist), new PropertyMetadata(false, OnCircularChanged));

        private static void OnCircularChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is Border)
            {
                Border border = d as Border;
                if ((bool)e.NewValue)
                {
                    var binding = new MultiBinding
                    {
                        Converter = new BorderCircularConverter()
                    };
                    binding.Bindings.Add(new Binding(FrameworkElement.ActualWidthProperty.Name) { Source = border });
                    binding.Bindings.Add(new Binding(FrameworkElement.ActualHeightProperty.Name) { Source = border });
                    border.SetBinding(Border.CornerRadiusProperty, binding);
                }
                else
                {
                    BindingOperations.ClearBinding(border, FrameworkElement.ActualWidthProperty);
                    BindingOperations.ClearBinding(border, FrameworkElement.ActualHeightProperty);
                    BindingOperations.ClearBinding(border, Border.CornerRadiusProperty);
                }
            }
        }

        public static void SetCircular(DependencyObject element, bool value)
            => element.SetValue(CircularProperty, value);

        public static bool GetCircular(DependencyObject element)
            => (bool)element.GetValue(CircularProperty);

        public static double GetBorderHeight(DependencyObject obj)
        {
            return (double)obj.GetValue(BorderHeightProperty);
        }

        public static void SetBorderHeight(DependencyObject obj, double value)
        {
            obj.SetValue(BorderHeightProperty, value);
        }

        // Using a DependencyProperty as the backing store for BorderHeight.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty BorderHeightProperty =
            DependencyProperty.RegisterAttached("BorderHeight", typeof(double), typeof(BorderElementAssist), new PropertyMetadata(12.0));



        public static double GetBorderWidth(DependencyObject obj)
        {
            return (double)obj.GetValue(BorderWidthProperty);
        }

        public static void SetBorderWidth(DependencyObject obj, double value)
        {
            obj.SetValue(BorderWidthProperty, value);
        }

        // Using a DependencyProperty as the backing store for BorderWidth.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty BorderWidthProperty =
            DependencyProperty.RegisterAttached("BorderWidth", typeof(double), typeof(BorderElementAssist), new PropertyMetadata(12.0));



        public static string GetText(DependencyObject obj)
        {
            return (string)obj.GetValue(TextProperty);
        }

        public static void SetText(DependencyObject obj, string value)
        {
            obj.SetValue(TextProperty, value);
        }

        // Using a DependencyProperty as the backing store for Text.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty TextProperty =
            DependencyProperty.RegisterAttached("Text", typeof(string), typeof(BorderElementAssist), new PropertyMetadata(""));

        public static Brush GetBorderColor(DependencyObject obj)
        {
            return (Brush)obj.GetValue(BorderColorProperty);
        }

        public static void SetBorderColor(DependencyObject obj, Brush value)
        {
            obj.SetValue(BorderColorProperty, value);
        }

        // Using a DependencyProperty as the backing store for MouseDownBackground.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty BorderColorProperty =
            DependencyProperty.RegisterAttached("BorderColor", typeof(Brush), typeof(BorderElementAssist), new PropertyMetadata(new SolidColorBrush(Color.FromArgb(0, 0, 0, 0))));

    }
}
