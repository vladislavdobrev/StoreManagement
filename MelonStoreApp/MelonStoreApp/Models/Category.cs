using System;
using System.Linq;
using System.Collections.Generic;

namespace MelonStoreApp.Models
{
    public class Category : ModelPropertyChangedNotifier
    {
        private bool isEnabled;

        public string Name { get; set; }
        public bool IsEnabled
        {
            get
            {
                return this.isEnabled;
            }
            set
            {
                if (this.isEnabled != value)
                {
                    this.isEnabled = value;
                    OnPropertyChanged("IsEnabled");
                }
            }
        }
    }
}
