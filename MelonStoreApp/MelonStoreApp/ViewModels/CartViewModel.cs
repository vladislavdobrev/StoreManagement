using MelonStoreApp.Commands;
using MelonStoreApp.Models;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace MelonStoreApp.ViewModels
{
    public class CartViewModel : ViewModelBase
    {
        private Product currentProduct;
        private static ObservableCollection<Product> cartProducts;

        private ICommand removeItemCommand;

        public ICommand RemoveItem
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
                }
            }
        }

    }
}