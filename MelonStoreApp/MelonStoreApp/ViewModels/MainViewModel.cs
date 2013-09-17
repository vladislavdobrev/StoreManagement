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


            this.Login = new Views.Login { DataContext = this.LoginVM };
            this.Register = new Views.Register { DataContext = this.RegisterVM };


            this.LoginVM.PropertyChanged += LoginVM_PropertyChanged;
            this.RegisterVM.PropertyChanged += RegisterVM_PropertyChanged;
            this.CurrentView = Login;
        }

        void RegisterVM_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "RegisterSuccessful")
            {
                if ((this.RegisterVM as RegisterViewModel).RegisterSuccessful == true)
                {
                    this.HomeVM = new ViewModels.HomeViewModel();
                    this.Home = new Views.Home() { DataContext = this.HomeVM };
                    this.CurrentView = this.Home;
                }

                return;
            }
        }

        void LoginVM_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            switch (e.PropertyName)
            {
                case "IsUserLogged":
                    if ((this.LoginVM as LoginViewModel).IsUserLogged == true)
                    {
                        this.HomeVM = new ViewModels.HomeViewModel();
                        this.Home = new Views.Home() { DataContext = this.HomeVM };
                        this.CurrentView = this.Home;
                    }
                    return;
                case "IsRegistering":
                    if ((this.LoginVM as LoginViewModel).IsRegistering == true)
                    {
                        this.CurrentView = this.Register;
                    }
                    return;
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