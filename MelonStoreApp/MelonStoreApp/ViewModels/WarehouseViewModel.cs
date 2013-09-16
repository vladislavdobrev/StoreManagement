using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using MelonStoreApp.Models;

namespace MelonStoreApp.ViewModels
{
    public class WarehouseViewModel : ViewModelBase
    {
        public WarehouseViewModel()
        {
            this.Categories = new ObservableCollection<string>{
                "asd1", "asd2", "asd3"
            };

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
        }


        public ObservableCollection<Product> Products { get; set; }
        public ObservableCollection<string> Categories { get; set; }
    }
}
