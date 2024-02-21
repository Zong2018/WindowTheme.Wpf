using WindowThemes.Wpf.ControlAssist;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WindowThemes.Wpf.Controls
{
    /// <summary>
    /// SliderControl.xaml 的交互逻辑
    /// </summary>
    public partial class SliderControl : UserControl
    {
        public SliderControl()
        {
            InitializeComponent();
            this.Loaded += LoadedHandler;
            this.Unloaded += SliderControl_Unloaded;
        }

        private void SliderControl_Unloaded(object sender, RoutedEventArgs e)
        {
            TipVisibility = Visibility.Hidden;
        }

        void LoadedHandler(object sender, RoutedEventArgs e)
        {
            var control = sender as SliderControl;
            if (IsShowNum)
            {
                var sliderControl = sender as SliderControl;
                var numControl = sliderControl.numBottom;
                numControl.ColumnDefinitions.Clear();

                numControl.Height = 30;
                var slider = sliderControl.slider;

                double minNum = sliderControl.MinNum;
                double maxNum = sliderControl.MaxNum;
                double changeNum = sliderControl.LargeChange;

                var f = sliderControl.TickFrequerncy;
                var range = maxNum - minNum;
                var count = range / f;
                var allGs = range / sliderControl.SmallChange;
                var dw = allGs / count;
                for (int i = 0; i < count; i++)
                {
                    numControl.ColumnDefinitions.Add(new ColumnDefinition());
                    if (i == 0)
                    {
                        TextBlock textBlock1 = new TextBlock();
                        textBlock1.TextAlignment = TextAlignment.Center;
                        textBlock1.Text = ((i * dw) * 5 + 10).ToString() + "%";
                        textBlock1.Width = 34;
                        textBlock1.Margin = new Thickness(-17, 0, 0, 0);
                        textBlock1.Foreground = sliderControl.TickForeground;
                        textBlock1.HorizontalAlignment = HorizontalAlignment.Left;
                        Grid.SetColumn(textBlock1, i);
                        numControl.Children.Add(textBlock1);
                    }
                    else if (i + 1 >= count)
                    {
                        TextBlock textBlock1 = new TextBlock();
                        textBlock1.Text = ((i * dw) * 5).ToString() + "%";
                        textBlock1.TextAlignment = TextAlignment.Center;
                        textBlock1.Width = 34;
                        textBlock1.Foreground = TickForeground;
                        textBlock1.Margin = new Thickness(-17, 0, 0, 0);
                        textBlock1.HorizontalAlignment = HorizontalAlignment.Left;
                        Grid.SetColumn(textBlock1, i);
                        numControl.Children.Add(textBlock1);
                        TextBlock textBlock2 = new TextBlock();
                        textBlock2.Text = (((i + 1) * dw) * 5).ToString() + "%";
                        textBlock2.TextAlignment = TextAlignment.Center;
                        textBlock2.HorizontalAlignment = HorizontalAlignment.Right;
                        textBlock2.Width = 34;
                        textBlock2.Foreground = TickForeground;
                        textBlock2.Margin = new Thickness(0, 0, -17, 0);
                        Grid.SetColumn(textBlock2, i);
                        numControl.Children.Add(textBlock2);

                    }
                    else
                    {
                        TextBlock textBlock1 = new TextBlock();
                        textBlock1.TextAlignment = TextAlignment.Center;
                        textBlock1.Text = ((i * dw) * 5).ToString() + "%";
                        textBlock1.Width = 34;
                        textBlock1.Margin = new Thickness(-17, 0, 0, 0);
                        textBlock1.Foreground = TickForeground;
                        textBlock1.HorizontalAlignment = HorizontalAlignment.Left;
                        Grid.SetColumn(textBlock1, i);
                        numControl.Children.Add(textBlock1);
                    }
                   
                }
                string newValue = control.TipNum.ToString().Replace("%", "");
                var num = double.Parse(newValue);
                if (num>=10 && num<=50)
                {
                    control.slider.Value = (num -10) / 10 * 0.625;
                }
                else
                {
                    control.slider.Value = num / 5 * control.slider.SmallChange;
                }
                control.Loaded -= LoadedHandler;
            }
        }

        public double MaxNum
        {
            get { return (double)GetValue(MaxNumProperty); }
            set { SetValue(MaxNumProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MaxNum.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty MaxNumProperty =
            DependencyProperty.Register("MaxNum", typeof(double), typeof(SliderControl), new PropertyMetadata(10.0));

        public double MinNum
        {
            get { return (double)GetValue(MinNumProperty); }
            set { SetValue(MinNumProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MinNum.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty MinNumProperty =
            DependencyProperty.Register("MinNum", typeof(double), typeof(SliderControl), new PropertyMetadata(0.0));

        public double TickMaxNum
        {
            get { return (double)GetValue(TickMaxNumProperty); }
            set { SetValue(TickMaxNumProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MaxNum.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty TickMaxNumProperty =
            DependencyProperty.Register("TickMaxNum", typeof(double), typeof(SliderControl), new PropertyMetadata(10.0));

        public double TickMinNum
        {
            get { return (double)GetValue(TickMinNumProperty); }
            set { SetValue(TickMinNumProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MinNum.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty TickMinNumProperty =
            DependencyProperty.Register("TickMinNum", typeof(double), typeof(SliderControl), new PropertyMetadata(0.0));


        public double TickFrequerncy
        {
            get { return (double)GetValue(TickFrequerncyProperty); }
            set { SetValue(TickFrequerncyProperty, value); }
        }

        // Using a DependencyProperty as the backing store for TickFrequerncy.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty TickFrequerncyProperty =
            DependencyProperty.Register("TickFrequerncy", typeof(double), typeof(SliderControl), new PropertyMetadata(1.0));



        public Brush TickForeground
        {
            get { return (Brush)GetValue(TickForegroundProperty); }
            set { SetValue(TickForegroundProperty, value); }
        }

        // Using a DependencyProperty as the backing store for TickForeground.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty TickForegroundProperty =
            DependencyProperty.Register("TickForeground", typeof(Brush), typeof(SliderControl), new PropertyMetadata(new SolidColorBrush(Color.FromRgb(0, 0, 0))));



        public double LargeChange
        {
            get { return (double)GetValue(LargeChangeProperty); }
            set { SetValue(LargeChangeProperty, value); }
        }

        // Using a DependencyProperty as the backing store for LargeChange.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty LargeChangeProperty =
            DependencyProperty.Register("LargeChange", typeof(double), typeof(SliderControl), new PropertyMetadata(1.0));




        public double SmallChange
        {
            get { return (double)GetValue(SmallChangeProperty); }
            set { SetValue(SmallChangeProperty, value); }
        }

        // Using a DependencyProperty as the backing store for SmallChange.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty SmallChangeProperty =
            DependencyProperty.Register("SmallChange", typeof(double), typeof(SliderControl), new PropertyMetadata(0.1));

        public static readonly RoutedEvent ValueChangedRoutedEvent =
           EventManager.RegisterRoutedEvent("ValueChanged", RoutingStrategy.Bubble, typeof(EventHandler<RoutedEventArgs>), typeof(SliderControl));
        //CLR事件包装
        public event RoutedEventHandler ValueChanged
        {
            add { this.AddHandler(ValueChangedRoutedEvent, value); }
            remove { this.RemoveHandler(ValueChangedRoutedEvent, value); }
        }

        public bool IsShowNum
        {
            get { return (bool)GetValue(IsShowNumProperty); }
            set { SetValue(IsShowNumProperty, value); }
        }

        // Using a DependencyProperty as the backing store for IsShowNum.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty IsShowNumProperty =
            DependencyProperty.Register("IsShowNum", typeof(bool), typeof(SliderControl), new PropertyMetadata(default(bool), IsShowNumPropertyChangedCallback));

        static void IsShowNumPropertyChangedCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if((bool)e.NewValue && !e.NewValue.Equals(e.OldValue))
            {
                var sliderControl = d as SliderControl;
                if (sliderControl.IsLoaded == false) return;
                var numControl = sliderControl.numBottom;
                numControl.ColumnDefinitions.Clear();
                numControl.Height = 30;

                double minNum = sliderControl.MinNum;
                double maxNum = sliderControl.MaxNum;
                double changeNum = sliderControl.LargeChange;

                var f = sliderControl.TickFrequerncy;

                var range = maxNum - minNum;
                var c = range / f;
                var allGs = range / sliderControl.SmallChange;
                var dw = allGs / c;
                for (int i = 0; i < c; i++)
                {
                    numControl.ColumnDefinitions.Add(new ColumnDefinition());
                    if(i == 0)
                    {
                        TextBlock textBlock1 = new TextBlock();
                        textBlock1.TextAlignment = TextAlignment.Center;
                        textBlock1.Text = ((i * dw) * 5+10).ToString() + "%";
                        textBlock1.Width = 34;
                        textBlock1.Margin = new Thickness(-17, 0, 0, 0);
                        textBlock1.Foreground = sliderControl.TickForeground;
                        textBlock1.HorizontalAlignment = HorizontalAlignment.Left;
                        Grid.SetColumn(textBlock1, i);
                        numControl.Children.Add(textBlock1);
                    }
                    else if (i + 1 >= c)
                    {
                        TextBlock textBlock1 = new TextBlock();
                        textBlock1.Text = ((i * dw) * 5).ToString() + "%";
                        textBlock1.TextAlignment = TextAlignment.Center;
                        textBlock1.Width = 34;
                        textBlock1.Foreground = sliderControl.TickForeground;
                        textBlock1.Margin = new Thickness(-17, 0, 0, 0);
                        textBlock1.HorizontalAlignment = HorizontalAlignment.Left;
                        Grid.SetColumn(textBlock1, i);
                        numControl.Children.Add(textBlock1);
                        TextBlock textBlock2 = new TextBlock();
                        textBlock2.Text = (((i + 1) * dw) * 5).ToString() + "%";
                        textBlock2.TextAlignment = TextAlignment.Center;
                        textBlock2.HorizontalAlignment = HorizontalAlignment.Right;
                        textBlock2.Width = 34;
                        textBlock2.Foreground = sliderControl.TickForeground;
                        textBlock2.Margin = new Thickness(0, 0, -17, 0);
                        Grid.SetColumn(textBlock2, i);
                        numControl.Children.Add(textBlock2);

                    }
                    else
                    {
                        TextBlock textBlock1 = new TextBlock();
                        textBlock1.TextAlignment = TextAlignment.Center;
                        textBlock1.Text = ((i * dw) * 5).ToString() + "%";
                        textBlock1.Width = 34;
                        textBlock1.Margin = new Thickness(-17, 0, 0, 0);
                        textBlock1.Foreground = sliderControl.TickForeground;
                        textBlock1.HorizontalAlignment = HorizontalAlignment.Left;
                        Grid.SetColumn(textBlock1, i);
                        numControl.Children.Add(textBlock1);
                    }


                }

            }
        }

        public string TipNum
        {
            get { return (string)GetValue(TipNumProperty); }
            set { SetValue(TipNumProperty, value); }
        }

        // Using a DependencyProperty as the backing store for TipNum.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty TipNumProperty =
            DependencyProperty.Register("TipNum", typeof(string), typeof(SliderControl), new PropertyMetadata("0%",null, OnTipNumCoerceValueCallback));

        static object OnTipNumCoerceValueCallback(DependencyObject d, object baseValue)
        {
            string result = baseValue as string;
            if(string.IsNullOrWhiteSpace(result))
            {
                return "0%";
            }

            var num = double.Parse(result.Replace("%",""));
            if(num>=0 && num <=50)
            {
                num = (int)(num / 10) * 10;
            }
            else
            {
                num = (int)(num / 5) * 5;
            }
            result = num.ToString() + "%";
            return result;
        }

        //static void TipNumPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        //{
        //    if(!e.OldValue.Equals(e.NewValue))
        //    {
        //        var control = d as SliderControl;
        //        if (control == null || !control.IsLoaded) return;

        //        string newValue = e.NewValue.ToString().Replace("%","");
        //        control.slider.Value = double.Parse(newValue) / 5 * control.slider.SmallChange;
        //    }
        //}

        double oldValue = 0.0;

        private void slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            //if (slider.Value >= oldValue)
            //{
            //    var diff = slider.Value - oldValue;
            //    if (slider.Value >= 0 && slider.Value <= 2.5)
            //    {
            //        slider.Value = oldValue + (int)(diff / 0.625) * 0.625;
            //    }
            //    else
            //    {
            //        slider.Value = oldValue + (int)(diff / slider.SmallChange) * slider.SmallChange;

            //    }
            //    oldValue = slider.Value;
            //}
            //else
            //{
            //    var diff = oldValue - slider.Value;
            //    if (slider.Value >= 0 && slider.Value <= 2.5)
            //    {
            //        slider.Value = oldValue - (int)(diff / 0.625) * 0.625;

            //    }
            //    else
            //    {
            //        slider.Value = oldValue - (int)(diff / slider.SmallChange) * slider.SmallChange;

            //    }
            //    oldValue = slider.Value;
            //}

            if (slider.Value >= 0 && slider.Value <= 2.5)
            {
                slider.Value = (int)(slider.Value / 0.625) * 0.625;
            }
            else
            {
                slider.Value = (int)(slider.Value / slider.SmallChange) * slider.SmallChange;

            }

            var oldTipNum = TipNum;

            if(slider.Value >=0 && slider.Value <= 2.5)
            {
                TipNum = ((int)(slider.Value / 0.625) * 10+10).ToString() + "%";
            }
            else
            {
                TipNum = ((int)(slider.Value / slider.SmallChange) * 5).ToString() + "%";

            }

            if (TipNum != oldTipNum)
            {
                TipVisibility = Visibility.Visible;
                RoutedEventArgs args = new RoutedEventArgs(ValueChangedRoutedEvent, this);
                this.RaiseEvent(args);//UIElement及其派生类            
            }
        }

        private void btnDown_Click(object sender, RoutedEventArgs e)
        {
            if (slider.Value >= 0 && slider.Value <= 2.5)
            {
                slider.Value = slider.Value - 0.625;

            }
            else
            {
                slider.Value = slider.Value - slider.SmallChange;

            }
        }

        private void btnUp_Click(object sender, RoutedEventArgs e)
        {
            if (slider.Value >= 0 && slider.Value < 2.5)
            {
                slider.Value = slider.Value + 0.625;

            }
            else
            {
                slider.Value = slider.Value + slider.SmallChange;

            }
        }



        public Visibility TipVisibility
        {
            get { return (Visibility)GetValue(TipVisibilityProperty); }
            set { SetValue(TipVisibilityProperty, value); }
        }

        // Using a DependencyProperty as the backing store for TipVisibility.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty TipVisibilityProperty =
            DependencyProperty.Register("TipVisibility", typeof(Visibility), typeof(SliderControl), new PropertyMetadata(Visibility.Hidden));

        //public double CurrentValue
        //{
        //    get { return (double)GetValue(CurrentValueProperty); }
        //    set { SetValue(CurrentValueProperty, value); }
        //}

        //// Using a DependencyProperty as the backing store for CurrentValue.  This enables animation, styling, binding, etc...
        //public static readonly DependencyProperty CurrentValueProperty =
        //    DependencyProperty.Register("CurrentValue", typeof(double), typeof(SliderControl), new PropertyMetadata(0.0));


    }
}
