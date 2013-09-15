using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MelonStoreApp.ViewModels
{
    public class LoginViewModel : ViewModelBase
    {
        private Visibility errorMessageVisibility;
        private Visibility usernameEnteredVisibility;
        private Visibility passwordEnteredVisibility;

        public LoginViewModel()
        {
            this.LoginCommand = new Commands.RelayCommand(LoginExecuteHandler, CanLoginExecuteHandler);
            this.RegisterCommand = new Commands.RelayCommand(RegisterExecuteHandler);
            this.errorMessageVisibility = Visibility.Hidden;
            this.usernameEnteredVisibility = Visibility.Hidden;
            this.passwordEnteredVisibility = Visibility.Hidden;
        }

        private string username;

        public string Username
        {
            get { return username; }
            set
            {
                if (this.username != value)
                {
                    username = value;
                    OnPropertyChanged("Username");
                   
                }
            }
        }

        private string password;

        public string Password
        {
            get { return password; }
            set
            {
                if (this.password != value)
                {
                    password = value;
                    OnPropertyChanged("Password");
  
                }
            }
        }

        public Commands.RelayCommand LoginCommand { get; set; }

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
        public Visibility UsernameEnteredVisibility
        {
            get
            {
                return this.usernameEnteredVisibility;
            }
            set
            {
                if (this.usernameEnteredVisibility != value)
                {
                    this.usernameEnteredVisibility = value;
                    OnPropertyChanged("UsernameEnteredVisibility");
                }
            }
        }
        public Visibility PasswordEnteredVisibility
        {
            get
            {
                return this.passwordEnteredVisibility;
            }
            set
            {
                if (this.passwordEnteredVisibility != value)
                {
                    this.passwordEnteredVisibility = value;
                    OnPropertyChanged("PasswordEnteredVisibility");
                }
            }
        }

        public void LoginExecuteHandler(object param)
        {
            if (string.IsNullOrEmpty(this.Username))
            {
                this.UsernameEnteredVisibility = Visibility.Visible;
            }
            else
            {
                this.UsernameEnteredVisibility = Visibility.Hidden;
            }

            if (string.IsNullOrEmpty(this.Password))
            {
                this.PasswordEnteredVisibility = Visibility.Visible;
            }
            else
            {
                this.PasswordEnteredVisibility = Visibility.Hidden;
            }

            //if (string.IsNullOrEmpty(this.Username) || string.IsNullOrEmpty(this.Password))
            //{
            //    return false;
            //}

            var success = Data.DataPersister.LoginUser("pesho", "pesho");
            if (success == null)
            {
                this.UsernameEnteredVisibility = Visibility.Hidden;
                this.PasswordEnteredVisibility = Visibility.Hidden;
                this.ErrorMessageVisibility = Visibility.Visible;
            }

        //    return true;
        }

        public void RegisterExecuteHandler(object param)
        {
            throw new NotImplementedException();
        }

        public bool CanLoginExecuteHandler(object param)
        {
            return true;
            //if (string.IsNullOrEmpty(this.Username))
            //{
            //    this.UsernameEnteredVisibility = Visibility.Visible;
            //}
            //else
            //{
            //    this.UsernameEnteredVisibility = Visibility.Hidden;
            //}

            //if (string.IsNullOrEmpty(this.Password))
            //{
            //    this.PasswordEnteredVisibility = Visibility.Visible;
            //}
            //else
            //{
            //    this.PasswordEnteredVisibility = Visibility.Hidden;
            //}

            //if (string.IsNullOrEmpty(this.Username) || string.IsNullOrEmpty(this.Password))
            //{
            //    return false;
            //}

            //var success = Data.DataPersister.LoginUser("pesho", "pesho");
            //if (success == null)
            //{
            //    this.UsernameEnteredVisibility = Visibility.Hidden;
            //    this.PasswordEnteredVisibility = Visibility.Hidden;
            //    this.ErrorMessageVisibility = Visibility.Visible;
            //}

            //return true;
        }
    }
}
