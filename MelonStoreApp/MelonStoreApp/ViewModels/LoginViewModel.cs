using System;
using System.Windows;

namespace MelonStoreApp.ViewModels
{
    public class LoginViewModel : ViewModelBase
    {
        private const string EmptyFieldMessage = "!";
        private const string InvalidDataMessage = "Invalid username or password.";

        private string errorMessage;
        private string usernameMessage;
        private string passwordMessage;
        private string username;
        private string password;
        private bool isUserLogged;
        private bool isRegistering;

        private Commands.RelayCommand loginCommand;

        public LoginViewModel()
        {
            this.LoginCommand = new Commands.RelayCommand(LoginExecuteHandler);
            this.RegisterCommand = new Commands.RelayCommand(RegisterExecuteHandler);
            this.ErrorMessage = string.Empty;
            this.UsernameMessage = string.Empty;
            this.PasswordMessage = string.Empty;
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

        public string ErrorMessage
        {
            get
            {
                return this.errorMessage;
            }
            set
            {
                if (this.errorMessage != value)
                {
                    this.errorMessage = value;
                    OnPropertyChanged("ErrorMessage");
                }
            }
        }

        public string UsernameMessage
        {
            get
            {
                return this.usernameMessage;
            }
            set
            {
                if (this.usernameMessage != value)
                {
                    this.usernameMessage = value;
                    OnPropertyChanged("UsernameMessage");
                }
            }
        }

        public string PasswordMessage
        {
            get
            {
                return this.passwordMessage;
            }
            set
            {
                if (this.passwordMessage != value)
                {
                    this.passwordMessage = value;
                    OnPropertyChanged("PasswordMessage");
                }
            }
        }

        public void LoginExecuteHandler(object parameter)
        {
            var isDataValid = true;
            this.ErrorMessage = string.Empty;

            if (string.IsNullOrEmpty(this.Username))
            {
                this.UsernameMessage = EmptyFieldMessage;
                isDataValid = false;
            }
            else
            {
                this.UsernameMessage = string.Empty;
                isDataValid = false;
            }

            if (string.IsNullOrEmpty(this.Password))
            {
                this.PasswordMessage = EmptyFieldMessage;
                isDataValid = false;
            }
            else
            {
                this.PasswordMessage = string.Empty;
            }

            if (isDataValid)
            {
                var success = Data.DataPersister.LoginUser("pesho", "pesho");

                if (success == null)
                {
                    this.UsernameMessage = string.Empty;
                    this.PasswordMessage = string.Empty;
                    this.ErrorMessage = InvalidDataMessage;
                }
                else
                {
                    this.IsUserLogged = true;
                }
            }
        }

        public void RegisterExecuteHandler(object parameter)
        {
            this.IsRegistering = true;
        }
    }
}