using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Media;
using WindowThemes.Wpf.Converters;

namespace WindowThemes.Wpf.Controls
{
    [TemplatePart(Name = ElementPasswordBox, Type = typeof(System.Windows.Controls.PasswordBox))]
    [TemplatePart(Name = ElementTextBox, Type = typeof(System.Windows.Controls.TextBox))]
    [TemplatePart(Name = ElementCopyButton, Type = typeof(System.Windows.Controls.TextBox))]
    public class CommonPasswordBox : Control
    {
        private const string ElementPasswordBox = "PART_PasswordBox";

        private const string ElementTextBox = "PART_TextBox";

        private const string ElementCopyButton = "PART_CopyButton";

        private System.Windows.Controls.TextBox _textBox;
        private Button _copyButton;
        /// <summary>
        ///     掩码字符
        /// </summary>
        public static readonly DependencyProperty PasswordCharProperty =
            System.Windows.Controls.PasswordBox.PasswordCharProperty.AddOwner(typeof(CommonPasswordBox),
                new FrameworkPropertyMetadata('●'));

        public char PasswordChar
        {
            get => (char)GetValue(PasswordCharProperty);
            set => SetValue(PasswordCharProperty, value);
        }

        /// <summary>
        ///     数据是否错误
        /// </summary>
        public static readonly DependencyProperty IsErrorProperty = DependencyProperty.Register(
            "IsError", typeof(bool), typeof(CommonPasswordBox), new PropertyMetadata(false));

        public bool IsError
        {
            get => (bool)GetValue(IsErrorProperty);
            set => SetValue(IsErrorProperty, value);
        }

        /// <summary>
        ///     错误提示
        /// </summary>
        public static readonly DependencyProperty ErrorStrProperty = DependencyProperty.Register(
            "ErrorStr", typeof(string), typeof(CommonPasswordBox), new PropertyMetadata(default(string)));

        public string ErrorStr
        {
            get => (string)GetValue(ErrorStrProperty);
            set => SetValue(ErrorStrProperty, value);
        }

        public static readonly DependencyProperty ShowEyeButtonProperty = DependencyProperty.Register(
            "ShowEyeButton", typeof(bool), typeof(CommonPasswordBox), new PropertyMetadata(false));

        public bool ShowEyeButton
        {
            get => (bool)GetValue(ShowEyeButtonProperty);
            set => SetValue(ShowEyeButtonProperty, value);
        }

        public static readonly DependencyProperty ShowPasswordProperty = DependencyProperty.Register(
            "ShowPassword", typeof(bool), typeof(CommonPasswordBox),
            new PropertyMetadata(false, OnShowPasswordChanged));

        public bool ShowPassword
        {
            get => (bool)GetValue(ShowPasswordProperty);
            set => SetValue(ShowPasswordProperty, value);
        }



        public bool ShowCopyButton
        {
            get { return (bool)GetValue(ShowCopyButtonProperty); }
            set { SetValue(ShowCopyButtonProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ShowCopyButton.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ShowCopyButtonProperty =
            DependencyProperty.Register("ShowCopyButton", typeof(bool), typeof(CommonPasswordBox), new PropertyMetadata(true));



        public static readonly DependencyProperty MaxLengthProperty =
            System.Windows.Controls.TextBox.MaxLengthProperty.AddOwner(typeof(CommonPasswordBox));

        public int MaxLength
        {
            get => (int)GetValue(MaxLengthProperty);
            set => SetValue(MaxLengthProperty, value);
        }

        public static readonly DependencyProperty SelectionBrushProperty =
            TextBoxBase.SelectionBrushProperty.AddOwner(typeof(CommonPasswordBox));

        public Brush SelectionBrush
        {
            get => (Brush)GetValue(SelectionBrushProperty);
            set => SetValue(SelectionBrushProperty, value);
        }

        public static readonly DependencyProperty SelectionOpacityProperty =
            TextBoxBase.SelectionOpacityProperty.AddOwner(typeof(CommonPasswordBox));

        public double SelectionOpacity
        {
            get => (double)GetValue(SelectionOpacityProperty);
            set => SetValue(SelectionOpacityProperty, value);
        }

        public static readonly DependencyProperty CaretBrushProperty =
            TextBoxBase.CaretBrushProperty.AddOwner(typeof(CommonPasswordBox));

        public Brush CaretBrush
        {
            get => (Brush)GetValue(CaretBrushProperty);
            set => SetValue(CaretBrushProperty, value);
        }


        // Using a DependencyProperty as the backing store for IsReadOnly.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty IsReadOnlyProperty =
            DependencyProperty.Register("IsReadOnly", typeof(bool), typeof(CommonPasswordBox), new PropertyMetadata(false));
        public bool IsReadOnly
        {
            get { return (bool)GetValue(IsReadOnlyProperty); }
            set { SetValue(IsReadOnlyProperty, value); }
        }



        public CommonPasswordBox()
        {

            //CommandBindings.Add(new CommandBinding(ApplicationCommands.Delete, (s, e) => Clear()));
            //CommandBindings.Add(new CommandBinding(ApplicationCommands.Paste, (s, e) => Paste()));

        }

        public System.Windows.Controls.PasswordBox ActualPasswordBox { get; set; }

        public Func<string, bool> VerifyFunc { get; set; }

        public virtual bool VerifyData()
        {
            bool result;

            if (VerifyFunc != null)
            {
                result = VerifyFunc.Invoke(ShowEyeButton && ShowPassword
                    ? _textBox.Text
                    : ActualPasswordBox.Password);
            }
            else
            {
                if (!string.IsNullOrEmpty(ShowEyeButton && ShowPassword
                    ? _textBox.Text
                    : ActualPasswordBox.Password))
                    result = true;
                else
                    result = true;
            }

            var isError = !result;
            if (isError)
            {
                SetCurrentValue(IsErrorProperty, true);
                SetCurrentValue(ErrorStrProperty, "密码为空");
            }
            else
            {
                isError = Validation.GetHasError(this);
                if (isError)
                {
                    SetCurrentValue(ErrorStrProperty, Validation.GetErrors(this)[0].ErrorContent);
                }
                else
                {
                    SetCurrentValue(IsErrorProperty, false);
                    SetCurrentValue(ErrorStrProperty, default(string));
                }
            }
            return !isError;
        }

        private static void OnShowPasswordChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var ctl = (CommonPasswordBox)d;
            if (!ctl.ShowEyeButton) return;
            if ((bool)e.NewValue && ctl._textBox != null)
            {
                ctl._textBox.Text = ctl.ActualPasswordBox.Password;
                ctl._textBox.Select(string.IsNullOrEmpty(ctl._textBox.Text) ? 0 : ctl._textBox.Text.Length, 0);
            }
            else if (ctl.ActualPasswordBox != null)
            {
                ctl.ActualPasswordBox.Password = ctl._textBox.Text;
            }
        }

        public override void OnApplyTemplate()
        {
            if (ActualPasswordBox != null)
                ActualPasswordBox.PasswordChanged -= PasswordBox_PasswordChanged;

            if (_textBox != null)
                _textBox.TextChanged -= TextBox_TextChanged;
            if (_copyButton != null)
                _copyButton.Click -= CopyButton_Click;

            base.OnApplyTemplate();

            ActualPasswordBox = GetTemplateChild(ElementPasswordBox) as System.Windows.Controls.PasswordBox;
            _textBox = GetTemplateChild(ElementTextBox) as System.Windows.Controls.TextBox;
            _copyButton = GetTemplateChild(ElementCopyButton) as Button;
            if (_copyButton != null && _textBox != null)
            {
                _copyButton.Click += CopyButton_Click;
            }
            if (ActualPasswordBox != null)
            {
                ActualPasswordBox.PasswordChanged += PasswordBox_PasswordChanged;
                ActualPasswordBox.SetBinding(System.Windows.Controls.PasswordBox.MaxLengthProperty, new Binding(MaxLengthProperty.Name) { Source = this });
                ActualPasswordBox.SetBinding(System.Windows.Controls.PasswordBox.SelectionBrushProperty, new Binding(SelectionBrushProperty.Name) { Source = this });

                ActualPasswordBox.SetBinding(System.Windows.Controls.PasswordBox.SelectionOpacityProperty, new Binding(SelectionOpacityProperty.Name) { Source = this });
                ActualPasswordBox.SetBinding(System.Windows.Controls.PasswordBox.CaretBrushProperty, new Binding(CaretBrushProperty.Name) { Source = this });

                ActualPasswordBox.SetBinding(System.Windows.Controls.PasswordBox.IsEnabledProperty, new Binding(IsReadOnlyProperty.Name) { Source = this, Converter = new IsReadOnlyConverter(), Mode = BindingMode.OneWay });
            }

            if (_textBox != null)
            {
                _textBox.TextChanged += TextBox_TextChanged;
            }

            if (_textBox != null && ActualPasswordBox != null)
            {
                if (ShowPassword)
                {
                    _textBox.Text = PasswordText;

                }
                else
                {
                    ActualPasswordBox.Password = PasswordText;
                }
            }
        }

        private void CopyButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string text = "";
                if (ShowPassword)
                {
                    text = _textBox?.Text ?? "";
                }
                else
                {
                    text = ActualPasswordBox?.Password ?? "";
                }
                if (string.IsNullOrWhiteSpace(text)) return;
                Clipboard.SetText(text);
            }
            catch (Exception ex)
            {

            }

        }

        public void Paste()
        {
            ActualPasswordBox.Paste();
            if (ShowEyeButton && ShowPassword)
            {
                _textBox.Text = ActualPasswordBox.Password;
            }
        }

        //public void SelectAll()
        //{
        //    ActualPasswordBox.SelectAll();
        //    if (ShowEyeButton && ShowPassword)
        //    {
        //        _textBox.SelectAll();
        //    }
        //}

        public void Clear()
        {
            ActualPasswordBox.Clear();
            _textBox.Clear();
        }

        private void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (VerifyData())
            {
                if (ShowPassword)
                {
                    _textBox.Text = ActualPasswordBox.Password;
                }
                SetCurrentValue(PasswordTextProperty, ActualPasswordBox.Password);
            }
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            VerifyData();
            SetCurrentValue(PasswordTextProperty, _textBox.Text);
        }



        public string PasswordText
        {
            get { return (string)GetValue(PasswordTextProperty); }
            set { SetValue(PasswordTextProperty, value); }
        }

        // Using a DependencyProperty as the backing store for PasswordText.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty PasswordTextProperty =
            DependencyProperty.Register("PasswordText", typeof(string), typeof(CommonPasswordBox), new PropertyMetadata("", new PropertyChangedCallback(OnPasswordTextPropertyChanged)));

        static void OnPasswordTextPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            CommonPasswordBox pb = d as CommonPasswordBox;
            if (pb != null && pb._textBox != null && pb.ActualPasswordBox != null && e.NewValue != null)
            {
                if (pb.ShowPassword)
                {
                    if (pb._textBox.Text != e.NewValue.ToString())
                        pb._textBox.Text = e.NewValue.ToString();
                }
                else
                {
                    if (pb.ActualPasswordBox.Password != e.NewValue.ToString())
                        pb.ActualPasswordBox.Password = e.NewValue.ToString();
                }
            }
        }
    }







    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
    //Lj3HeBVEb8VWuZMnictqxw==
}
