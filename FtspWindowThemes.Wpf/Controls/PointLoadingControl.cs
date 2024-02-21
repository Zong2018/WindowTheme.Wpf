using WindowThemes.Wpf.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace WindowThemes.Wpf.Controls
{
    [TemplatePart(Name = StackPanelPartName, Type = typeof(StackPanel))]
    public class PointLoadingControl : Control
    {
        public const string StackPanelPartName = "PART_StackPanel";

        static PointLoadingControl()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(PointLoadingControl), new FrameworkPropertyMetadata(typeof(PointLoadingControl)));
        }

        public PointLoadingControl()
        {
            AddHandler(LoadedEvent, new RoutedEventHandler(LoadedHandler), true);
        }

        Dictionary<string, Shape> Shapes = null;

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            var stackPanel = GetTemplateChild(StackPanelPartName) as StackPanel;
            StackPanelLoadShapes(stackPanel);

        }

        #region 依赖属性

        public int PointNum
        {
            get { return (int)GetValue(PointNumProperty); }
            set { SetValue(PointNumProperty, value); }
        }

        // Using a DependencyProperty as the backing store for PointNum.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty PointNumProperty =
            DependencyProperty.Register("PointNum", typeof(int), typeof(PointLoadingControl), new PropertyMetadata(3, new PropertyChangedCallback(PointNumChangeCallback)));

        static void PointNumChangeCallback(DependencyObject d, DependencyPropertyChangedEventArgs arg)
        {
            var control = d as PointLoadingControl;
            if (control == null) return;

            var _opacityAnimation = new DoubleAnimationUsingKeyFrames();
            var keyFrames = _opacityAnimation.KeyFrames;
            int count = (int)arg.NewValue;
            var stackPanel = control.GetTemplateChild(StackPanelPartName) as StackPanel;
            if (stackPanel == null) return;
            StackPanelLoadShapes(stackPanel);

        }

        public double Diam
        {
            get { return (double)GetValue(DiamProperty); }
            set { SetValue(DiamProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Diam.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty DiamProperty =
            DependencyProperty.Register("Diam", typeof(double), typeof(PointLoadingControl), new PropertyMetadata(2.0, new PropertyChangedCallback(DiamChangedCallback)));


        private static void DiamChangedCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var control = d as PointLoadingControl;
            if (control == null) return;

            if (control.Shapes == null) return;
            foreach (var item in control.Shapes)
            {
                item.Value.Width = control.Diam;
                item.Value.Height = control.Diam;
            }
        }

        public Thickness PointMargin
        {
            get { return (Thickness)GetValue(PointMarginProperty); }
            set { SetValue(PointMarginProperty, value); }
        }

        // Using a DependencyProperty as the backing store for PointMargin.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty PointMarginProperty =
            DependencyProperty.Register("PointMargin", typeof(Thickness), typeof(PointLoadingControl), new PropertyMetadata(new Thickness(1, 0, 0, 0), new PropertyChangedCallback(PointMarginCallback)));

        static void PointMarginCallback(DependencyObject d, DependencyPropertyChangedEventArgs arg)
        {
            var control = d as PointLoadingControl;
            if (control == null) return;

            if (control.Shapes == null) return;

            foreach (var item in control.Shapes)
            {
                item.Value.Margin = (Thickness)arg.NewValue;
            }
        }

        public Brush PointColor
        {
            get { return (Brush)GetValue(PointColorProperty); }
            set { SetValue(PointColorProperty, value); }
        }

        // Using a DependencyProperty as the backing store for PointColor.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty PointColorProperty =
            DependencyProperty.Register("PointColor", typeof(Brush), typeof(PointLoadingControl), new PropertyMetadata(new SolidColorBrush(Color.FromRgb(123, 123, 123)), new PropertyChangedCallback(PointColorCallback)));

        static void PointColorCallback(DependencyObject d, DependencyPropertyChangedEventArgs arg)
        {
            var control = d as PointLoadingControl;
            if (control == null) return;

            if (control.Shapes == null) return;

            foreach (var item in control.Shapes)
            {
                item.Value.Fill = (Brush)arg.NewValue;
            }
        }

        #endregion

        #region 事件处理
        private void LoadedHandler(object sender, RoutedEventArgs arg)
        {

        }

        private static void StackPanelLoadShapes(StackPanel stackPanel)
        {
            var parent = stackPanel.VisualTreeAncestory().OfType<PointLoadingControl>().FirstOrDefault();
            if (parent == null) return;

            parent.Shapes = new Dictionary<string, Shape>();
            stackPanel.Children.Clear();
            int count = parent.PointNum;
            Storyboard story = new Storyboard();
            story.Duration = TimeSpan.FromSeconds(count * parent.TimeInterval.TotalSeconds);
            story.RepeatBehavior = RepeatBehavior.Forever;
            for (int i = 1; i <= count; i++)
            {
                string name = $"e{i}";
                Ellipse ellipse = new Ellipse();
                ellipse.Width = parent.Diam;
                ellipse.Height = parent.Diam;
                ellipse.HorizontalAlignment = HorizontalAlignment.Center;
                ellipse.VerticalAlignment = VerticalAlignment.Center;
                if (i != 1)
                {
                    ellipse.Margin = parent.PointMargin;
                }
                ellipse.Fill = parent.PointColor;
                stackPanel.Children.Add(ellipse);
                parent.Shapes[name] = ellipse;
                DoubleAnimationUsingKeyFrames animation;
                animation = new DoubleAnimationUsingKeyFrames();
                var keyFrames = animation.KeyFrames;
                for (int j = 1; j <= count; j++)
                {
                    keyFrames.Add(new SplineDoubleKeyFrame(i == j ? 1 : 0, TimeSpan.FromSeconds(parent.TimeInterval.TotalSeconds * (j - 1))));
                }
                Storyboard.SetTarget(animation, parent.Shapes[name]);
                Storyboard.SetTargetProperty(animation, new PropertyPath("Opacity"));
                story.Children.Add(animation);
            };
            story.Begin();

        }
        #endregion

        public TimeSpan TimeInterval
        {
            get { return (TimeSpan)GetValue(TimeIntervalProperty); }
            set { SetValue(TimeIntervalProperty, value); }
        }

        // Using a DependencyProperty as the backing store for TimeInterval.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty TimeIntervalProperty =
            DependencyProperty.Register("TimeInterval", typeof(TimeSpan), typeof(PointLoadingControl), new PropertyMetadata(TimeSpan.FromSeconds(0.5), new PropertyChangedCallback(TimeIntervalCallback)));

        static void TimeIntervalCallback(DependencyObject d, DependencyPropertyChangedEventArgs arg)
        {
            var control = d as PointLoadingControl;
            if (control == null) return;
            var stackPanel = control.GetTemplateChild(StackPanelPartName) as StackPanel;
            if (stackPanel == null) return;
            StackPanelLoadShapes(stackPanel);
        }



        public string ExText
        {
            get { return (string)GetValue(ExTextProperty); }
            set { SetValue(ExTextProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ExText.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ExTextProperty =
            DependencyProperty.Register("ExText", typeof(string), typeof(PointLoadingControl), new PropertyMetadata(""));


    }
}
