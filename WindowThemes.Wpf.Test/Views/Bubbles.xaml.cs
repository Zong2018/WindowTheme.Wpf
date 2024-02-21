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

namespace WindowThemes.Wpf.Test.Views
{
    /// <summary>
    /// Bubbles.xaml 的交互逻辑
    /// </summary>
    public partial class Bubbles : UserControl
    {
        public Bubbles()
        {
            InitializeComponent();
            slider1.TipNum = "25%";
        }

        private void bubbleBtn_Click(object sender, RoutedEventArgs e)
        {
            bubble.Visibility = Visibility.Hidden;
        }

        private void bubble_MouseEnter(object sender, MouseEventArgs e)
        {
            if (bubble.Visibility == Visibility.Hidden)
            {
                bubble.Visibility = Visibility.Visible;
            }
        }

        private void slider1_ValueChanged(object sender, RoutedEventArgs e)
        {

        }
    }
}
