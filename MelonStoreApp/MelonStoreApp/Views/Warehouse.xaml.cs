using System.Windows.Controls;

namespace MelonStoreApp.Views
{
    /// <summary>
    /// Interaction logic for Warehouse.xaml
    /// </summary>
    public partial class Warehouse : UserControl
    {
        public Warehouse()
        {
            InitializeComponent();
            this.warehousePannel.ItemsSource = new List<Models.Product>(){
                new Models.Product {Id = 1, Name = "asd", Brand = "Nike", Category = "asd", Price=123, Amount = 10}          
            };
        }
    }
}
