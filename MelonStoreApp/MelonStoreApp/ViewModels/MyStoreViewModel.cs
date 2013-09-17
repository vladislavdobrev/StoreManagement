using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using MelonStoreApp.Models;
using System.Collections.ObjectModel;
using System.Windows.Data;
using MelonStoreClient.Models;
using MelonStore.Persisters;
using MelonStoreApp.Commands;

namespace MelonStoreApp.ViewModels
{
    public class MyStoreViewModel : ViewModelBase
    {

        private Product lastCurrentProduct;
        private ProductClientModel currentProduct;
        private Visibility isInfoVisible;
        private bool isOrdering;

        private int orderAmount;

        private int orderPrice;

        public MyStoreViewModel()
        {
            //var categories = DataPersister.GetAllProducts();
            //this.Categories = new ObservableCollection<Category>();

            //foreach (var category in categories)
            //{
            //    Categories.Add(new Category { Name = category, IsEnabled = true });
            //}

            this.Products = DataPersister.GetAllStoreProducts();

            //this.ShowAllProductsCommand = new RelayCommand(ShowAllProductsExecuteHandler);
            this.HideInfoCommand = new RelayCommand(HideInfoExecuteHandler);
            this.ShowInfoCommand = new RelayCommand(ShowInfoExecuteHandler);
            //this.StartOrderingCommand = new RelayCommand(StartOrderingExecuteHandler);
            //this.AddToCartCommand = new RelayCommand(AddToCartExecuteHandler);
            
            this.IsInfoVisible = Visibility.Collapsed;
            this.IsOrdering = false;
        }
        
        public ObservableCollection<ProductClientModel> Products { get; set; }

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

        public Product LastCurrentProduct
        {
            get
            {
                return this.lastCurrentProduct;
            }
            set
            {
                if (this.lastCurrentProduct != value)
                {
                    this.lastCurrentProduct = value;
                }
            }
        }

        public ProductClientModel CurrentProduct
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
                    else
                    {
                        this.LastCurrentProduct = new Product()
                        {
                            Brand = value.Brand,
                            //Category = value.Category,
                            Count = value.Count,
                            Id = value.Id,
                            //Image = value.Image,
                            Name = value.Name,
                            Price = value.BasePrice
                        };
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
                    OnPropertyChanged("OrderPrice");
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
                Product newProduct = this.LastCurrentProduct;
                newProduct.Count = this.OrderAmount;
                newProduct.Price = this.OrderPrice;
                CartViewModel.AddProduct(newProduct);
            }

            IsOrdering = false;
        }
    }
}
