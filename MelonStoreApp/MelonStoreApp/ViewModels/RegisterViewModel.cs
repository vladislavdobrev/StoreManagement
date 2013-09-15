using System;
using System.Collections.Generic;
using System.Windows;

namespace MelonStoreApp.ViewModels
{
    public class RegisterViewModel : ViewModelBase
    {
        private List<string> stores;
        private string username;
        private string password;
        private string password2;

        private Visibility invalidStoreVisibility;
        private Visibility invalidUsernameVisibility;
        private Visibility invalidPasswordVisibility;
        private Visibility invalidPassword2Visibility;

        private Commands.RelayCommand registerCommand;

        public RegisterViewModel()
        {
            this.Stores = Data.DataPersister.GetStores();
            this.RegisterCommand = new Commands.RelayCommand(this.RegisterExecuteHandler, this.CanRegisterExecuteHandler);
        }

        public List<string> Stores
        {
            get
            {
                return stores;
            }
            set
            {
                stores = value;
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
                if (username != value)
                {
                    username = value;
                    OnPropertyChanged("Username");
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
                if (password != value)
                {
                    password = value;
                    OnPropertyChanged("Password");
                }
            }
        }

        public string Password2
        {
            get
            {
                return password2;
            }
            set
            {
                if (password2 != value)
                {
                    password2 = value;
                    OnPropertyChanged("Password2");
                }
            }
        }

        public Visibility InvalidStoreVisibility
        {
            get
            {
                return this.invalidStoreVisibility;
            }
            set
            {
                if (this.invalidStoreVisibility != value)
                {
                    this.invalidStoreVisibility = value;
                    OnPropertyChanged("InvalidStoreVisibility");
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

        public Visibility InvalidPassword2Visibility
        {
            get
            {
                return this.invalidPassword2Visibility;
            }
            set
            {
                if (this.invalidPassword2Visibility != value)
                {
                    this.invalidPassword2Visibility = value;
                    OnPropertyChanged("InvalidPassword2Visibility");
                }
            }
        }

        public Commands.RelayCommand RegisterCommand
        {
            get
            {
                return this.registerCommand;
            }
            set
            {
                if (this.registerCommand != value)
                {
                    this.registerCommand = value;
                    OnPropertyChanged("RegisterCommand");
                }
            }
        }

        private void RegisterExecuteHandler(object parameter)
        {
            throw new NotImplementedException();
        }

        private bool CanRegisterExecuteHandler(object parameter)
        {
            throw new NotImplementedException();
        }
    }
}