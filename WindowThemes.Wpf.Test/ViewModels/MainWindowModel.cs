using WindowThemes.Wpf.Test.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using WindowThemes.Wpf.Controls;

namespace WindowThemesDemo.ViewModels
{
    public class MainWindowModel : ViewModelBase
    {
        public MainWindowModel()
        {
            DemoItems = new ObservableCollection<DemoItem>();
            foreach (var item in CreateDemoItems())
            {
                DemoItems.Add(item);
            }
        }
        public ObservableCollection<DemoItem> DemoItems { get; }
        public IEnumerable<DemoItem> CreateDemoItems()
        {
            yield return new DemoItem("Buttons", typeof(Buttons));
            yield return new DemoItem("TextBoxs", typeof(TextBoxs));
            yield return new DemoItem("PasswordBoxs", typeof(PasswordBox));
            yield return new DemoItem("Scrolls", typeof(Scrolls));
            yield return new DemoItem("TreeViews", typeof(TreeViews));
            yield return new DemoItem("RadioButtons", typeof(RadioButtons));
            yield return new DemoItem("CheckBoxs", typeof(CheckBoxs));
            yield return new DemoItem("Bubbles", typeof(Bubbles));
        }

        DemoItem _selectedItem;
        public DemoItem SelectedItem
        {
            get { return _selectedItem; }
            set
            {
                _selectedItem = value;
                OnRisePropertyChanged("SelectedItem");
            }
        }
        int _selectedIndex;
        public int SelectedIndex
        {
            get { return _selectedIndex; }
            set
            {
                _selectedIndex = value;
                OnRisePropertyChanged("SelectedIndex");
            }
        }
    }
}
