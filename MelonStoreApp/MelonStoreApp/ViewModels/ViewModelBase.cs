using System.ComponentModel;
using System.Windows;

namespace MelonStoreApp.ViewModels
{
    public abstract class ViewModelBase : DependencyObject, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string name)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }

        private string myVar;

        public string MyProperty
        {
            get { return myVar; }
            set
            {
                myVar = value;
                OnPropertyChanged("MyProperty");
            }
        }
    }
}
