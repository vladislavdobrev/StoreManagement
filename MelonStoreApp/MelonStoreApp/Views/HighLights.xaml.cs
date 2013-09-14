using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MelonStoreApp.Views
{
    /// <summary>
    /// Interaction logic for HighLights.xaml
    /// </summary>
    public partial class HighLights : UserControl
    {
        public HighLights()
        {
            InitializeComponent();
            this.forDiscount.ItemsSource = new List<Models.Product>(){
                new Models.Product {Id = 1, Name = "asd", Brand = "Nike", Category = "asd", Price=123, Amount = 10},          
            };
            this.forOrder.ItemsSource = new List<Models.Product>(){
                new Models.Product {Id = 1, Name = "asd", Brand = "Nike", Category = "asd", Price=123, Amount = 10},
            };
        }
    }
}
