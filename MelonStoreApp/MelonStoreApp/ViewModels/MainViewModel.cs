using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace MelonStoreApp.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        private Models.User user;
        private UserControl currentView;

        public MainViewModel()
        {
            this.VMs = new List<ViewModelBase>();
            this.Vs = new List<UserControl>();

            this.Vs.Add(Views.Login);
            this.Vs.Add(Views.Register);
            this.Vs.Add(Views.Home);

            this.currentView = Views.Login;
        }

        public IEnumerable<ViewModelBase> VMs { get; set; }
        public IEnumerable<UserControl> Vs { get; set; }
        public UserControl CurrentView
        {
            get { return this.currentView; }
            set
            {
                if (this.currentView != value)
                {
                    this.currentView = value;
                    OnPropertyChanged("CurrentView");
                }
            }
        }
    }
}
