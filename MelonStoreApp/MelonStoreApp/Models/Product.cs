namespace MelonStoreApp.Models
{
    public class Product
    {
        public int Id { get; set; }

        public string Name { get; set; }
        
        public int? Count { get; set; }

        public string Brand { get; set; }

        public decimal Price { get; set; }

        public Category Category { get; set; }

        public virtual string ImageUrl { get; set; }
    }
}