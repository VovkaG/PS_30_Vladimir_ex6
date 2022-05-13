using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Collections.ObjectModel;
using System.Windows.Input;
using System.ComponentModel;

namespace EasyMVVM
{
    public class MainWindowVM : DependencyObject, INotifyPropertyChanged
    {
        private ObservableCollection<string> _BackingProperty;
        public ObservableCollection<string> BoundProperty
        {
            get { return _BackingProperty; }
            set { _BackingProperty = value; PropChanged("BoundProperty"); }
        }
        //This event will be fired to notify any listeners of a change in a property value.
        public event PropertyChangedEventHandler PropertyChanged;
        //Tell WPF Binding that this property value has changed
        public void PropChanged(String propertyName)
        {
            //Did WPF registerd to listen to this event
            if (PropertyChanged != null)
            {
                //Tell WPF that this property changed
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        public MainWindowVM()
        {
            Model m = new Model();
            BoundProperty = m.GetData();
        }

    }
}
