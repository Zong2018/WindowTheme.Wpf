using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
namespace WindowThemesDemo.ViewModels
{
    public abstract class ViewModelBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public void OnRisePropertyChanged(string name = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
