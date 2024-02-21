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
    /// MongolianLayerWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MongolianLayerWindow : Window
    {
        ///// <summary>
        ///// <summary>
        ///// 回调
        ///// </summary>
        //public event EventHandler<arg<string>> CallBackHandled;

        ///// <summary>
        ///// 显示显示蒙层上的窗体
        ///// </summary>
        //public event EventHandler<ServiceEventArgs<string>> ShowWindowHandled;

        /// <summary>
        /// 构造函数
        /// </summary>
        public MongolianLayerWindow()
        {
            InitializeComponent();

        }

        ///// <summary>
        ///// 窗口关闭
        ///// </summary>
        //public void CloseWindow()
        //{
        //    Close();

        //    CallBackHandled?.Invoke(this, new ServiceEventArgs<string>("刷新界面"));
        //}

        ///// <summary>
        ///// 显示蒙层上的窗体
        ///// </summary>
        //public void ShowWindow()
        //{
        //    ShowWindowHandled?.Invoke(this, new ServiceEventArgs<string>("显示窗体"));
        //}
    }

    public static class WindowCoverHelper
    {
        /// <summary>
        /// 蒙层窗口
        /// </summary>
        public static Dictionary<Window, Window> CoverWindowDic = new Dictionary<Window, Window>();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="upperWindow"></param>
        public static bool? ShowDialog(Window upperWindow)
        {
            if (!CoverWindowDic.ContainsKey(upperWindow))
            {
                var coverWin = new MongolianLayerWindow();
                if (upperWindow.Owner != null)
                {
                    coverWin.Width = upperWindow.Owner.ActualWidth;
                    coverWin.Height = upperWindow.Owner.ActualHeight;
                    var left = upperWindow.Owner.Left;
                    var top = upperWindow.Owner.Top;
                    if(upperWindow.Owner.WindowState == WindowState.Maximized)
                    {
                        coverWin.Top = 0;
                        coverWin.Left = 0;
                    }
                    else
                    {
                        coverWin.Top = top;
                        coverWin.Left = left;
                    }
              
                }
                else
                {
                    coverWin.Width = 1060;
                    coverWin.Height = 670;
                }
                upperWindow.Closing += (s, e) => { var win = s as Window; if (win != null) CloseDialog(win); };
                CoverWindowDic[upperWindow] = coverWin;
                coverWin.Owner = upperWindow.Owner;
                coverWin.Show();
                return upperWindow.ShowDialog();

            }
            return false;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="upperWindow"></param>
        public static void CloseDialog(Window upperWindow)
        {

            Window layerWindow = null;
            CoverWindowDic.TryGetValue(upperWindow, out layerWindow);

            if (layerWindow != null)
            {
                CoverWindowDic.Remove(upperWindow);
                // 关闭蒙层
                layerWindow.Close();

                // 激活主窗口,让主窗口显示在最前
                upperWindow.Owner?.Activate();
            }

        }

    }
}
