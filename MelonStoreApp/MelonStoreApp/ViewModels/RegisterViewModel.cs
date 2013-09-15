using System;
using System.Collections.Generic;
using System.Windows;

namespace MelonStoreApp.ViewModels
{
    public class RegisterViewModel : ViewModelBase
    {
        private const string EmptyFieldMessage = "!";
        private const string UsernameTakenMessage = "Username is already registered.";
        private const string PasswordsDoNotMatch = "Passwords do not match.";

        private List<string> stores;
        private string store;
        private string username;
        private string password;
        private string password2;

        private string errorMessage;
        private string storeMessage;
        private string usernameMessage;
        private string passwordMessage;
        private string password2Message;

        public RegisterViewModel()
        {
            this.Stores = Data.DataPersister.GetStores();
            this.RegisterCommand = new Commands.RelayCommand(this.RegisterExecuteHandler);
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

        public string Store
        {
            get
            {
                return store;
            }
            set
            {
                if (store != value)
                {
                    store = value;
                    OnPropertyChanged("Store");
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

        public string StoreMessage
        {
            get
            {
                return this.storeMessage;
            }
            set
            {
                if (this.storeMessage != value)
                {
                    this.storeMessage = value;
                    OnPropertyChanged("StoreMessage");
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

        public string Password2Message
        {
            get
            {
                return this.password2Message;
            }
            set
            {
                if (this.password2Message != value)
                {
                    this.password2Message = value;
                    OnPropertyChanged("Password2Message");
                }
            }
        }

        public Commands.RelayCommand RegisterCommand { get; set; }

        private void RegisterExecuteHandler(object parameter)
        {
            var isDataValid = true;
            if (this.Store == null)
            {
                this.StoreMessage = EmptyFieldMessage;
                isDataValid = false;
            }
            else
            {
                this.StoreMessage = string.Empty;
            }

            if (string.IsNullOrEmpty(this.Username))
            {
                this.UsernameMessage = EmptyFieldMessage;
                isDataValid = false;
            }
            else
            {
                this.UsernameMessage = string.Empty;
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

            if (string.IsNullOrEmpty(this.Password2))
            {
                this.Password2Message = EmptyFieldMessage;
                isDataValid = false;
            }
            else
            {
                this.Password2Message = string.Empty;
            }

            if (isDataValid)
            {
                var success = Data.DataPersister.RegisterUser("shop","pesho", "peshopwd");
                //TODO
            }
        }
    }
}