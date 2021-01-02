using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AceTech.Framework.Utility
{
    public class ViewModelBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string propName)
        {
            if(PropertyChanged!=null)
            {
                var handler = PropertyChanged;
                handler(this, new PropertyChangedEventArgs(propName));
            }
        }
    }
}
