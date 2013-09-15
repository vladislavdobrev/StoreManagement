using System;
using System.Windows;

namespace MelonStoreApp.ViewModels
{
    public class LoginViewModel : ViewModelBase
    {
        private Visibility errorMessageVisibility;
        private Visibility invalidUsernameVisibility;
        private Visibility invalidPasswordVisibility;
        private string username;
        private string password;
        private bool isUserLogged;
        private bool isRegistering;

        private Commands.RelayCommand loginCommand;

        public LoginViewModel()
        {
            this.LoginCommand = new Commands.RelayCommand(LoginExecuteHandler, CanLoginExecuteHandler);
            this.RegisterCommand = new Commands.RelayCommand(RegisterExecuteHandler);
            this.ErrorMessageVisibility = Visibility.Hidden;
            this.InvalidUsernameVisibility = Visibility.Hidden;
            this.InvalidPasswordVisibility = Visibility.Hidden;
            this.IsUserLogged = false;
            this.IsRegistering = false;
        }

        public bool IsRegistering
        {
            get
            {
                return this.isRegistering;
            }
            set
            {
                if (this.isRegistering != value)
                {
                    this.isRegistering = value;
                    OnPropertyChanged("IsRegistering");
                }
            }
        }

        public string Username
        {
            get
            {
                return username;
            }
            set
            {
                if (this.username != value)
                {
                    username = value;
                    OnPropertyChanged("Username");
                   // OnPropertyChanged("LoginCommand");
                }
            }
        }

        public string Password
        {
            get
            {
                return password;
            }
            set
            {
                if (this.password != value)
                {
                    password = value;
                  //  OnPropertyChanged("Password");

                }
            }
        }

        public bool IsUserLogged
        {
            get
            {
                return this.isUserLogged;
            }
            set
            {
                if (this.isUserLogged != value)
                {
                    this.isUserLogged = value;
                    OnPropertyChanged("IsUserLogged");
                }
            }
        }

        public Commands.RelayCommand LoginCommand
        {
            get
            {
                return this.loginCommand;
            }
            set
            {
                if (loginCommand != value)
                {
                    this.loginCommand = value;
                    OnPropertyChanged("LoginCommand");
                }
            }
        }

        public Commands.RelayCommand RegisterCommand { get; set; }

        public Visibility ErrorMessageVisibility
        {
            get
            {
                return this.errorMessageVisibility;
            }
            set
            {
                if (this.errorMessageVisibility != value)
                {
                    this.errorMessageVisibility = value;
                    OnPropertyChanged("ErrorMessageVisibility");
                }
            }
        }

        public Visibility InvalidUsernameVisibility
        {
            get
            {
                return this.invalidUsernameVisibility;
            }
            set
            {
                if (this.invalidUsernameVisibility != value)
                {
                    this.invalidUsernameVisibility = value;
                    OnPropertyChanged("InvalidUsernameVisibility");
                }
            }
        }

        public Visibility InvalidPasswordVisibility
        {
            get
            {
                return this.invalidPasswordVisibility;
            }
            set
            {
                if (this.invalidPasswordVisibility != value)
                {
                    this.invalidPasswordVisibility = value;
                    OnPropertyChanged("InvalidPasswordVisibility");
                }
            }
        }

        public void LoginExecuteHandler(object parameter)
        {
            if (string.IsNullOrEmpty(this.Username))
            {
                this.InvalidUsernameVisibility = Visibility.Visible;
            }
            else
            {
                this.InvalidUsernameVisibility = Visibility.Hidden;
            }

            if (string.IsNullOrEmpty(this.Password))
            {
                this.InvalidPasswordVisibility = Visibility.Visible;
            }
            else
            {
                this.InvalidPasswordVisibility = Visibility.Hidden;
            }

            if (!string.IsNullOrEmpty(this.username) && !string.IsNullOrEmpty(this.password))
            {
                var success = Data.DataPersister.LoginUser("pesho", "pesho");

                if (success == null)
                {
                    this.InvalidUsernameVisibility = Visibility.Hidden;
                    this.InvalidPasswordVisibility = Visibility.Hidden;
                    this.ErrorMessageVisibility = Visibility.Visible;
                }
                else
                {
                    this.IsUserLogged = true;
                }
            }
        }

        public bool CanLoginExecuteHandler(object parameter)
        {
            //if (string.IsNullOrEmpty(this.Username))
            //{
            //    this.InvalidUsernameVisibility = Visibility.Visible;
            //}
            //else
            //{
            //    this.InvalidUsernameVisibility = Visibility.Hidden;
            //}

            //if (string.IsNullOrEmpty(this.Password))
            //{
            //    this.InvalidPasswordVisibility = Visibility.Visible;
            //}
            //else
            //{
            //    this.InvalidPasswordVisibility = Visibility.Hidden;
            //}

            //if (!string.IsNullOrEmpty(this.username) && !string.IsNullOrEmpty(this.password))
            //{
                return true;
            //}

            //return false;
        }

        public void RegisterExecuteHandler(object parameter)
        {
            this.IsRegistering = true;
        }
    }
}