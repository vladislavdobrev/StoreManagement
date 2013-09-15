namespace MelonStoreApp.Models
{
    public class Product
    {
        public int Id { get; set; }

        public string Name { get; set; }
        
        public int? Count { get; set; }

        public string Brand { get; set; }

        public decimal Price { get; set; }

        public string Category { get; set; }

        public int Amount { get; set; }

        public virtual Image Image { get; set; }
    }
}