using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MelonStoreApp.Models;
using System.Windows;

namespace MelonStoreApp.ViewModels
{
    public class ProductViewModel : ViewModelBase
    {


        public Product Product
        {
            get { return (Product)GetValue(ProductProperty); }
            set { SetValue(ProductProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Product.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ProductProperty =
            DependencyProperty.Register("Product", typeof(Product), typeof(ProductViewModel), new PropertyMetadata(null));



        public ProductViewModel()
        {
            //this.Product = prod;
        }
    }
}
