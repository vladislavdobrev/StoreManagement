using MelonStore.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MelonStore.Repositories
{
    public class DbProductRepository : IProductRepository<Product>
    {
        public DbProductRepository(DbContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException("Invalid database context! It cannot be null!");
            }

            this.Context = context;
            this.DbSet = this.Context.Set<Product>();
        }

        protected DbContext Context { get; set; }

        protected DbSet<Product> DbSet { get; set; }


        public IQueryable<Product> All()
        {
            IQueryable<Product> all = this.DbSet;

            return all;
        }

        public IQueryable<Product> Get(Gender gender, Category category)
        {
            IQueryable<Product> all = this.All();

            IQueryable<Product> fitered =
                (from product in all
                 where product.Gender == gender &&
                 product.Category == category
                 select product
                     );

            return fitered;
        }
    }
}
