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
            this.HighlightsVM = new HighlightsViewModel();


            this.Highlights = new Views.HighLights { DataContext = this.HighlightsVM };
            this.MyStore = new Views.MyStore() { DataContext = this.MyStoreVM};
            this.Warehouse = new Views.Warehouse();
            this.Cart = new Views.Cart();
        }

        public ViewModelBase HighlightsVM { get; set; }
        public ViewModelBase MyStoreVM { get; set; }
        public ViewModelBase WarehouseVM { get; set; }
        public ViewModelBase CartVM { get; set; }

        public UserControl Highlights { get; set; }
        public UserControl MyStore { get; set; }
        public UserControl Warehouse { get; set; }
        public UserControl Cart { get; set; }
    }
}
