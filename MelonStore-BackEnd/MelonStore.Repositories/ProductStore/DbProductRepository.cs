using MelonStore.Models;
using System;
using System.Data.Entity;
using System.Linq;

namespace MelonStore.Repositories
{
    public class DbProductStoreRepository : IProductStoreRepository<ProductStore>
    {
        public DbProductStoreRepository(DbContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException("Invalid database context! It cannot be null!");
            }

            this.Context = context;
            this.DbSet = this.Context.Set<ProductStore>();
        }

        protected DbContext Context { get; set; }

        protected DbSet<ProductStore> DbSet { get; set; }

        public IQueryable<ProductStore> All()
        {
            var allProducts = this.DbSet;

            return allProducts;
        }

        public ProductStore Get(int productId, int storeId)
        {
            IQueryable<ProductStore> all = this.All();

            IQueryable productStore = from current in all
                                      where current.Product_Id == productId &&
                                      current.Store_Id == storeId
                                      select current;

            return productStore as ProductStore;

        }

        public ProductStore Add(ProductStore item)
        {
            this.DbSet.Add(item);
            this.Context.SaveChanges();

            return null;
        }

        public void Update(int productId, int storeId, ProductStore item)
        {
            ProductStore fromDb = this.Get(productId, storeId);
            fromDb.Price = item.Price;
            fromDb.Count = fromDb.Count + item.Count;

            this.Context.SaveChanges();
        }
    }
}