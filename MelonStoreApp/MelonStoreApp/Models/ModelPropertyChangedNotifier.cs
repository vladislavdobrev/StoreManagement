using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;

namespace MelonStoreApp.Models
{
    public class ModelPropertyChangedNotifier : INotifyPropertyChanged
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
