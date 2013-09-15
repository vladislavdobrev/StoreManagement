using MelonStore.Api.Models.ProductStoreModels;
using MelonStore.Data;
using MelonStore.Models;
using MelonStore.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MelonStore.Api.Controllers
{
    public class ProductsController : ApiController
    {
        private DbProductRepository repo;
        private MelonStoreContext context;

        public ProductsController()
        {
            this.context = new MelonStoreContext();
            this.repo = new DbProductRepository(context);
        }

        [ActionName("all")]
        public HttpResponseMessage GetAll()
        {
            IQueryable<Product> dbProducts = this.repo.All();
            ICollection<ProductApiModel> products =
                (from currProduct in dbProducts
                 select new ProductApiModel()
                 {
                     Name = currProduct.Name,
                     ImagePath = currProduct.Image.Url,
                 }).ToList();

            return this.Request.CreateResponse(HttpStatusCode.OK, products);
        }

        [ActionName("get")]
        public HttpResponseMessage GetFiltered(string gender, string category)
        {
            IQueryable<Product> dbFiltered = this.repo.Get(Gender.Female, Category.Shirts);

            ICollection<ProductApiModel> products =
                (from currProduct in dbFiltered
                 select new ProductApiModel()
                 {
                     Name = currProduct.Name,
                     ImagePath = currProduct.Image.Url
                 }).ToList();

            return this.Request.CreateResponse(HttpStatusCode.OK, products);
        }
    }
}
