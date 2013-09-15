using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using MelonStoreApp.Models;
using System.Collections.ObjectModel;

namespace MelonStoreApp.ViewModels
{
    public class MyStoreViewModel : ViewModelBase
    {

        public ObservableCollection<Product> Products { get; set; }
        public Product currentProduct;
        public ProductViewModel productVM;

        public MyStoreViewModel()
        {
            this.Products = new ObservableCollection<Product>()
            {
                new Product{
                Id = 1,
                Name = "Black Shoes",
                Count = 23,
                Brand = "Bershka",
                Price = 119,
                Category = "Shoes",
                Amount = 23
                },
                new Product{
                Id = 1,
                Name = "Black Shoes",
                Count = 23,
                Brand = "Bershka",
                Price = 119,
                Category = "Shoes",
                Amount = 23
                },
            };
            //this.CurrentProduct = new Product
            //{
            //    Id = 1,
            //    Name = "Black Shoes",
            //    Count = 23,
            //    Brand = "Bershka",
            //    Price = 119,
            //    Category = "Shoes",
            //    Amount = 23
            //};
            this.productVM = new ProductViewModel(CurrentProduct);
        }

        public Visibility ProductInfoVisibility { get; set; }

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

        public ProductViewModel ProductVM
        {
            get
            {
                return this.productVM;
            }
            set
            {
                if (this.productVM != value)
                {
                    this.productVM = value;
                    OnPropertyChanged("ProductVM");
                }
            }
        }

    }
}
