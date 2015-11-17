using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace WpfTestApp
{
    class PeopleViewModelEntity : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public void NotifyPropertyChanged(string propName)
        {
            if(PropertyChanged != null)
            {
                Console.WriteLine($"Changed: {propName}");
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
            }
        }
    }
}
