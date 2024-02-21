using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;

namespace WindowThemesDemo.ViewModels
{
    public class DemoItem : ViewModelBase
    {
        private readonly Type _contentType;
        private readonly object _dataContext;

        private object _content;

        public DemoItem(string name, Type contentType, object dataContext = null)
        {
            Name = name;
            _contentType = contentType;
            _dataContext = dataContext;
        }

        public string Name { get; }

        public object Content
        {
            get
            {
                return _content == null ? CreateContent() : _content;
            }
        }

        private object CreateContent()
        {
            var content = Activator.CreateInstance(_contentType);
            FrameworkElement element = null;
            if (_dataContext != null && content is FrameworkElement )
            {
                element = content as FrameworkElement;
                element.DataContext = _dataContext;
            }
            _content = content;
            return content;
        }
    }
}
