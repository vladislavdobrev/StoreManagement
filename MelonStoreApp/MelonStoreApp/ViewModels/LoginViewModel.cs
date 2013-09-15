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
        
        public LoginViewModel()
        {
            this.LoginCommand = new Commands.RelayCommand(LoginExecuteHandler, CanLoginExecuteHandler);
            this.RegisterCommand = new Commands.RelayCommand(RegisterExecuteHandler);
            this.ErrorMessageVisibility = Visibility.Hidden;
        }

        public Models.User User { get; set; }

        public Commands.RelayCommand LoginCommand { get; set; }

        public Commands.RelayCommand RegisterCommand { get; set; }
      
        public Visibility ErrorMessageVisibility
        {
            get
            {
                return this.ErrorMessageVisibility;
            }
            set
            {
                if (this.ErrorMessageVisibility != value)
                {
                    this.ErrorMessageVisibility = value;
                    OnPropertyChanged("ErrorMessageVisibility");
                }
            }
        }

        public void LoginExecuteHandler(object param)
        {
            var success = Data.DataPersister.LoginUser("pesho", "pesho");
            if (success != null)
            {

            }
            else
            {


            }
        }

        public void RegisterExecuteHandler(object param)
        {
            throw new NotImplementedException();
        }

        public bool CanLoginExecuteHandler(object param)
        {
            return this.User.Username != null && this.User.Password != null;
        }



    }
}
