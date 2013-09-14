using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MelonStoreApp.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        private Models.User user;

        public MainViewModel()
        {
          //  this.ViewModels
        }

        public bool IsUserLogged
        {
            get { return this.user != null; }
        }

        public ObservableCollection<ViewModelBase> ViewModels { get; set; }


    }
}
