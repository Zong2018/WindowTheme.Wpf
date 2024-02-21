using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using System.Windows.Interop;


namespace WindowThemes.Wpf.Controls
{
    internal class NotTopMostPopup : Popup
    {
        private Window _window;
        protected override void OnOpened(EventArgs e)
        {
            var hwnd = ((HwndSource)PresentationSource.FromVisual(this.Child)).Handle;
            RECT rect;

            if (GetWindowRect(hwnd, out rect))
            {
                SetWindowPos(hwnd, -2, rect.Left, rect.Top, (int)this.Width, (int)this.Height, 0);
            }

            _window = Window.GetWindow(this);
            _window.PreviewMouseDown -= Window_PreviewMouseDown;
            _window.PreviewMouseDown += Window_PreviewMouseDown;
            _window.LocationChanged -= HostWindow_SizeOrLocationChanged;
            _window.LocationChanged += HostWindow_SizeOrLocationChanged;
            _window.SizeChanged -= HostWindow_SizeOrLocationChanged;
            _window.SizeChanged += HostWindow_SizeOrLocationChanged;

        }

        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);
            _window.PreviewMouseDown -= Window_PreviewMouseDown;
            _window.LocationChanged -= HostWindow_SizeOrLocationChanged;
            _window.SizeChanged -= HostWindow_SizeOrLocationChanged;
        }

        private void HostWindow_SizeOrLocationChanged(object sender, EventArgs e)
        {
            RefreshPosition();
        }

        void RefreshPosition()
        {
            var offset = HorizontalOffset;
            SetCurrentValue(HorizontalOffsetProperty, offset + 1);
            SetCurrentValue(HorizontalOffsetProperty, offset);
        }

        private void Window_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            var element = Tag as FrameworkElement;
            if (!IsMouseOver && !element.IsMouseOver)
                IsOpen = false;
        }

        #region P/Invoke imports & definitions

        [StructLayout(LayoutKind.Sequential)]
        public struct RECT
        {
            public int Left;
            public int Top;
            public int Right;
            public int Bottom;
        }

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool GetWindowRect(IntPtr hWnd, out RECT lpRect);

        [DllImport("user32", EntryPoint = "SetWindowPos")]
        private static extern int SetWindowPos(IntPtr hWnd, int hwndInsertAfter, int x, int y, int cx, int cy, int wFlags);

        #endregion
    }
}
