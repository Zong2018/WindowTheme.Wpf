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
using System.Windows.Forms;


namespace WindowThemes.Wpf.Controls
{
    /// <summary>
    /// ResultMsgWindow.xaml 的交互逻辑
    /// </summary>
    public partial class ResultMsgWindow : Window
    {
        /// <summary>
        /// documentation header
        /// </summary>
        private Timer myTimer = new Timer();
        private int time = 0;
        /// <summary>
        /// documentation header
        /// </summary>
        public ResultMsgWindow()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="msg">参数</param>
        /// <param name="ms">参数</param>
        public ResultMsgWindow(string msg, Window owner, int ms = 2000)
        {
            InitializeComponent();
            myTimer = new Timer();
            txtTip.Text = msg;
            this.Owner = owner;
            time = ms;
        }

        /// <summary>
        /// 系统异常提示及记录日志
        /// </summary>
        /// <param name="ex">documentation</param>
        public ResultMsgWindow(Exception ex, Window owner)
        {
            InitializeComponent();
            myTimer = new Timer();
            txtTip.Text = "系统遇到异常，该操作失败。";
            this.Owner = owner;
            this.ShowDialog();
        }
        /// <summary>
        /// 方法
        /// </summary>
        /// <param name="sender">参数1</param>
        /// <param name="e">参数2</param>
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            myTimer.Tick += new EventHandler(TimerEventProcessor);
            myTimer.Interval = time;
            myTimer.Start();
        }
        /// <summary>
        /// 方法
        /// </summary>
        /// <param name="myObject">参数1</param>
        /// <param name="myEventArgs">参数2</param>
        private void TimerEventProcessor(object myObject, EventArgs myEventArgs)
        {
            this.Close();
            myTimer.Stop();
        }
    }
}
