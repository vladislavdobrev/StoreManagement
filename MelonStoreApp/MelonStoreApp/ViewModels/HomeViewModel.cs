using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Controls;
using System.Windows;

namespace MelonStoreApp.ViewModels
{
    public class HomeViewModel : ViewModelBase
    {
        public HomeViewModel()
        {
            this.ViewModels = new ObservableCollection<ViewModelBase>();
            this.Views = new ObservableCollection<UserControl>();

            this.ViewModels.Add(new HighlightsViewModel());
            this.Views.Add(new Views.Highlights { DataContext = this.ViewModels.Last() });

            this.ViewModels.Add(new MyStoreViewModel());
            this.Views.Add(new Views.MyStore { DataContext = this.ViewModels.Last() });

            this.ViewModels.Add(new WarehouseViewModel());
            this.Views.Add(new Views.Warehouse { DataContext = this.ViewModels.Last() });

            this.ViewModels.Add(new CartViewModel());
            this.Views.Add(new Views.Cart { DataContext = this.ViewModels.Last() });
        }

        public ObservableCollection<UserControl> Views { get; set; }

        public ObservableCollection<ViewModelBase> ViewModels { get; set; }

    }
}
