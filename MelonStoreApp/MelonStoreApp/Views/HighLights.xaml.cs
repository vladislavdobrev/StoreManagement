using System.Collections.Generic;
using System.Windows.Controls;

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
            this.forDiscount.ItemsSource = new List<Models.Product>()
            {
                new Models.Product { Id = 1, Name = "asd", Brand = "Nike", Category = "asd", Price = 123, Amount = 10 },
            };
            this.forOrder.ItemsSource = new List<Models.Product>()
            {
                new Models.Product { Id = 1, Name = "asd", Brand = "Nike", Category = "asd", Price = 123, Amount = 10 },
            };
        }
    }
}