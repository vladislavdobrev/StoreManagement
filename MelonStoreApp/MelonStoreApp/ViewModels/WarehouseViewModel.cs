using System;
using System.Linq;
using System.Collections.ObjectModel;
using MelonStoreApp.Models;
using MelonStoreApp.Commands;
using System.Windows;

namespace MelonStoreApp.ViewModels
{
    public class WarehouseViewModel : ViewModelBase
    {
        private Product currentProduct;
        private Visibility isInfoVisible;
        private bool isOrdering;

        private int orderAmount;

        private int orderPrice;

        public WarehouseViewModel()
        {
            var categories = Data.DataPersister.GetCategories();
            this.Categories = new ObservableCollection<Category>();

            foreach (var category in categories)
            {
                Categories.Add(new Category { Name = category, IsEnabled = true });
            }

            this.Products = Data.DataPersister.GetStoreProducts();

            this.ShowAllProductsCommand = new RelayCommand(ShowAllProductsExecuteHandler);
            this.HideInfoCommand = new RelayCommand(HideInfoExecuteHandler);
            this.ShowInfoCommand = new RelayCommand(ShowInfoExecuteHandler);
            this.StartOrderingCommand = new RelayCommand(StartOrderingExecuteHandler);
            this.AddToCartCommand = new RelayCommand(AddToCartExecuteHandler);
            
            this.IsInfoVisible = Visibility.Collapsed;
            this.IsOrdering = false;
        }
        
        public ObservableCollection<Product> Products { get; set; }

        public ObservableCollection<Category> Categories { get; set; }

        public RelayCommand ShowAllProductsCommand { get; set; }

        public RelayCommand FilterProductsCommand { get; set; }

        public RelayCommand HideInfoCommand { get; set; }

        public RelayCommand ShowInfoCommand { get; set; }

        public RelayCommand StartOrderingCommand { get; set; }

        public RelayCommand AddToCartCommand { get; set; }

        public Visibility IsInfoVisible
        {
            get
            {
                return this.isInfoVisible;
            }
            set
            {
                if (this.isInfoVisible != value)
                {
                    this.isInfoVisible = value;
                    OnPropertyChanged("IsInfoVisible");
                }
            }
        }

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
                    if (value == null)
                    {
                        this.IsInfoVisible = Visibility.Collapsed;
                    }
                    OnPropertyChanged("CurrentProduct");
                }
            }
        }

        public bool IsOrdering
        {
            get
            {
                return isOrdering;
            }
            set
            {
                if (this.isOrdering != value)
                {
                    isOrdering = value;
                    OnPropertyChanged("IsOrdering");
                }
            }
        }

        public int OrderAmount
        {
            get
            {
                return this.orderAmount;
            }
            set
            {
                if (this.orderAmount != value)
                {
                    this.orderAmount = value;
                    OnPropertyChanged("OrderAmount");
                }
            }
        }

        public int OrderPrice
        {
            get
            {
                return this.orderPrice;
            }
            set
            {
                if (this.orderPrice != value)
                {
                    this.orderPrice = value;
                    OnPropertyChanged("PriceAmount");
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
            throw new NotImplementedException();
        }

        private void ShowInfoExecuteHandler(object obj)
        {
            this.IsInfoVisible = Visibility.Visible;
        }

        private void HideInfoExecuteHandler(object obj)
        {
            this.IsInfoVisible = Visibility.Collapsed;
        }

        private void StartOrderingExecuteHandler(object obj)
        {
            this.IsOrdering = true;
            this.OrderAmount = 0;
            this.OrderPrice = 0;
        }

        private void AddToCartExecuteHandler(object obj)
        {
            if (this.OrderAmount > 0 && this.OrderPrice > 0)
            {
                throw new NotImplementedException();
            }

            IsOrdering = false;
        }
    }
}