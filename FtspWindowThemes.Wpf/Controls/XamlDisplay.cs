using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Xml;

namespace WindowThemes.Wpf.Controls
{
    [TemplatePart(Name = PART_ButtonPartName, Type = typeof(XamlDisplay))]
    [TemplatePart(Name = PART_PopupPartName, Type = typeof(XamlDisplay))]
    public class XamlDisplay : ContentControl
    {
        public const string PART_ButtonPartName = "PART_Button";
        public const string PART_PopupPartName = "PART_Popup";
        static XamlDisplay()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(XamlDisplay), new FrameworkPropertyMetadata(typeof(XamlDisplay)));

        }
        public XamlDisplay()
        {
            CommandBindings.Add(new CommandBinding(CopyCommand, CopyHandler));
        }

        private void CopyHandler(object sender, ExecutedRoutedEventArgs e)
        {
            try
            {
                //改成SetDataObject，兼容性
                Clipboard.SetDataObject(XamlText);
            }
            catch (Exception)
            {

            }
        }

        static void ContentPropertyChangedCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {

        }

        Button button;
        Popup popup;
        FrameworkElement contentPresenter;
        public static RoutedCommand CopyCommand = new RoutedUICommand("Copy", "Copy", typeof(XamlDisplay));

        public object XamlContent
        {
            get { return (object)GetValue(XamlContentProperty); }
            set { SetValue(XamlContentProperty, value); }
        }

        // Using a DependencyProperty as the backing store for XamlContent.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty XamlContentProperty =
            DependencyProperty.Register("XamlContent", typeof(object), typeof(XamlDisplay), new PropertyMetadata(null, new PropertyChangedCallback(ContentPropertyChangedCallback)));



        public string Xaml { get; set; }



        public string XamlText
        {
            get { return (string)GetValue(XamlTextProperty); }
            set { SetValue(XamlTextProperty, value); }
        }

        // Using a DependencyProperty as the backing store for XamlText.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty XamlTextProperty =
            DependencyProperty.Register("XamlText", typeof(string), typeof(XamlDisplay), new PropertyMetadata(null));



        public bool IsDropDownOpen
        {
            get { return (bool)GetValue(IsDropDownOpenProperty); }
            set { SetValue(IsDropDownOpenProperty, value); }
        }

        // Using a DependencyProperty as the backing store for IsDropDownOpen.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty IsDropDownOpenProperty =
            DependencyProperty.Register("IsDropDownOpen", typeof(bool), typeof(XamlDisplay), new PropertyMetadata(false, new PropertyChangedCallback(IsDropDownOpenPropertyChangedCallback)));

        static void IsDropDownOpenPropertyChangedCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var xamlDisplay = d as XamlDisplay;
            if (xamlDisplay == null) return;
            var btn = xamlDisplay.button;
            if (btn == null) return;

            if (IsClickOpen)
            {
                IsClickOpen = false;
            }
            else
            {
                IsClickOpen = true;
            }
            var mouseP = Mouse.GetPosition(btn);
            if (!IsClickOpen && mouseP.X <= 30 && mouseP.X >= 0 && mouseP.Y <= 30 && mouseP.Y >= 0)
            {
                IsClickOpen = true;
            }
        }

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();


            //实例化绑定对象
            Binding binding = new Binding();
            //设置要绑定源控件
            binding.Source = this;
            //设置要绑定属性
            binding.Path = new PropertyPath("Content");
            // 设置绑定到要绑定的控件
            this.SetBinding(XamlContentProperty, binding);
            contentPresenter = this.Content as FrameworkElement;

            button = this.GetTemplateChild(PART_ButtonPartName) as Button;
            popup = this.GetTemplateChild(PART_PopupPartName) as Popup;

            button.Click -= ButtonClickHandler;
            button.Click += ButtonClickHandler;

        }
        static bool IsClickOpen = false;

        void ButtonClickHandler(object sender, RoutedEventArgs e)
        {
            if (popup == null) return;
            if (IsClickOpen) { IsClickOpen = false; return; }
            if (!IsClickOpen)
            {
                IsDropDownOpen = true;
                if (contentPresenter == null)
                {
                    XamlText = "XamlDisplay";
                }
                else
                {
                    string xamlText = XamlWriter.Save(contentPresenter);
                    xamlText = System.Text.RegularExpressions.Regex.Replace(xamlText, @"((xmlns|xml):?[^=]*=[""][^""]*[""])", "");
                    xamlText = System.Text.RegularExpressions.Regex.Replace(xamlText, @"<([\S]*).Style>([\s\S]*)</([\S]*).Style>", "");
                    XamlText = xamlText.Replace("assembly", "wpf");
                }
               

            }
        }

       
    }
}
