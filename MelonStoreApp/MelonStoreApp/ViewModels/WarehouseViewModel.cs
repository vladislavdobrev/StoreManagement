using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using MelonStoreApp.Models;
using MelonStoreApp.Commands;
using MelonStore.Persisters;
using MelonStoreClient.Models;

namespace MelonStoreApp.ViewModels
{
    public class WarehouseViewModel : ViewModelBase
    {
        private Product currentProduct;

        public WarehouseViewModel()
        {
            var categories = Data.DataPersister.GetCategories();
            this.Categories = new ObservableCollection<Category>();

            foreach (var category in categories)
            {
                Categories.Add(new Category { Name = category, IsEnabled = true });
            }

            this.Products = DataPersister.GetAllStoreProducts();

            this.ShowAllProductsCommand = new RelayCommand(ShowAllProductsExecuteHandler);
        }

        public ObservableCollection<ProductClientModel> Products { get; set; }
        public ObservableCollection<Category> Categories { get; set; }
        public Commands.RelayCommand ShowAllProductsCommand { get; set; }
        public Commands.RelayCommand FilterProductsCommand { get; set; }

        public Product CurrentProduct
        {
            get
            {
                return this.currentProduct;
            }
            set
            {
                if (this.currentProduct != value)
                {
                    this.currentProduct = value;
                    OnPropertyChanged("CurrentProduct");
                }
            }
        }

        private void ShowAllProductsExecuteHandler(object obj)
        {
            foreach (var category in this.Categories)
            {
                category.IsEnabled = true;
            }
        }

        private void FilterProductsExecuteHanler(object obj)
        {

        }
    }
}
