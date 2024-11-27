using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STEM.Tech.CS.Framework
{
    public class ViewModelBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string propName)
        {
            var handler = PropertyChanged;
            if(handler!=null)
            {
                handler?.Invoke(this, new PropertyChangedEventArgs(propName));
            }
        }
    }
}
