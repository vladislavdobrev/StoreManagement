using MelonStore.Models;
using System.Data.Entity;

namespace MelonStore.Data
{
    public class MelonStoreContext : DbContext
    {
        public MelonStoreContext() : base("MelonStoreDb")
        {
        }

        public DbSet<User> Users { get; set; }

        public DbSet<StoreProduct> StoreProducts { get; set; }

        public DbSet<Store> Stores { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<Image> Images { get; set; }
    }
}