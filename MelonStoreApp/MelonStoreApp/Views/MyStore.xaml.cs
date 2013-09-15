using System.Collections.Generic;
using System.Windows.Controls;

namespace MelonStoreApp.Views
{
    /// <summary>
    /// Interaction logic for MyStore.xaml
    /// </summary>
    public partial class MyStore : UserControl
    {
        public MyStore()
        {
            InitializeComponent();
            this.grid.ItemsSource = new List<Models.Product>()
            {
                new Models.Product { Id = 1, Name = "asd", Brand = "Nike", Category = "asd", Price = 123, Amount = 10 },
            };
        }
    }
}