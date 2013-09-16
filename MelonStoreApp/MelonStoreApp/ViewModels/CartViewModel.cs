using MelonStoreApp.Commands;
using MelonStoreApp.Models;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;

namespace MelonStoreApp.ViewModels
{
    public class CartViewModel : ViewModelBase
    {
        private Product currentProduct;
        private static ObservableCollection<Product> cartProducts;

        private RelayCommand removeItemCommand;

        public RelayCommand RemoveItemCommand
        {
            get
            {
                if (this.removeItemCommand == null)
                {
                    this.removeItemCommand = new RelayCommand(this.HandleRemoveItemComand);
                }
                return this.removeItemCommand;
            }
        }

        public static IList<Product> CartProducts
        {
            get
            {
                if (cartProducts == null)
                {
                    CartProducts = new ObservableCollection<Product>();
                }

                return cartProducts;
            }
            set
            {
                if (cartProducts == null)
                {
                    cartProducts = new ObservableCollection<Product>();
                }

                cartProducts.Clear();
                foreach (var item in value)
                {
                    cartProducts.Add(item);
                }
            }
        }

        public static void AddProduct(Product product)
        {
            var p = cartProducts.FirstOrDefault(x => x.Id == product.Id);
            if (p != null)
            {
                CartProducts.Remove(p);
                cartProducts.Add(product);
            }
            else
            {
                CartProducts.Add(product);
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
                    OnPropertyChanged("CurrentProduct");
                }
            }
        }

        private void HandleRemoveItemComand(object obj)
        {
            foreach (var item in CartProducts)
            {
                if (item == this.CurrentProduct)
                {
                    cartProducts.Remove(item);
                    break;
                }
            }
        }
    }
}