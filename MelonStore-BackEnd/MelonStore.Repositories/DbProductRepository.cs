using MelonStore.Models;
using System;
using System.Data.Entity;
using System.Linq;

namespace MelonStore.Repositories
{
    public class DbProductRepository : IRepository<Product>
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
            var allProducts = this.DbSet;

            return allProducts;
        }

        public Product Get(int id)
        {
            if (id < 0)
            {
                throw new ArgumentOutOfRangeException("Id must be positive integer number!");
            }

            var product = this.DbSet.Where(x => x.Id == id).FirstOrDefault();

            return product;
        }

        public Product Get(string value)
        {
            throw new System.NotImplementedException();
        }

        public Product Add(Product item)
        {
            throw new System.NotImplementedException();
            //if (item == null)
            //{
            //    throw new ArgumentNullException("Invalid user! It cannot be null!");
            //}

            //item.Name = item.Name.ToLower();

            //if (this.Get(item.Name) != null)
            //{
            //    throw new InvalidOperationException(string.Format("User with nickname {0} already exists!", user.Username));
            //}

            //this.DbSet.Add(item);
            //this.Context.SaveChanges();

            //return item;
        }

        public void Delete(int id)
        {
            throw new System.NotImplementedException();
        }

        public void Update(int id, Product item)
        {
            throw new System.NotImplementedException();
        }
    }
}