using System.Windows.Controls;

namespace MelonStoreApp.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        private Models.User user;
        private UserControl currentView;

        public MainViewModel()
        {
            this.LoginVM = new ViewModels.LoginViewModel();
            this.RegisterVM = new ViewModels.RegisterViewModel();
            //this.HomeVM = new ViewModels.

            this.Login = new Views.Login { DataContext = this.LoginVM };
            this.Register = new Views.Register { DataContext = this.RegisterVM };
            this.Home = new Views.Home();

            this.LoginVM.PropertyChanged += LoginVM_PropertyChanged;


            this.CurrentView = Login;
        }

        void LoginVM_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            switch (e.PropertyName)
            {
                case "IsUserLogged": this.CurrentView = this.Home; return;
                case "IsRegistering": this.CurrentView = this.Register; return;
            }

        }

        public UserControl Login { get; set; }
        public UserControl Register { get; set; }
        public UserControl Home { get; set; }

        public ViewModelBase LoginVM { get; set; }
        public ViewModelBase RegisterVM { get; set; }
        public ViewModelBase HomeVM { get; set; }

        public UserControl CurrentView
        {
            get
            {
                return this.currentView;
            }
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