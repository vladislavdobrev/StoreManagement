using MelonStore.Api.EnumConverters;
using MelonStore.Api.Models.ProductModels;
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
        private DbProductStoreRepository storeProductRepo;
        private MelonStoreContext context;

        public ProductsController()
        {
            this.context = new MelonStoreContext();
            this.repo = new DbProductRepository(context);
        }

        [ActionName("all")]
        public HttpResponseMessage GetAll(string sessionKey)
        {
            //if (String.IsNullOrEmpty(sessionKey))
            //{
            //    throw new ArgumentException("Not allowed action for non - logged user!");
            //}
            IQueryable<Product> dbProducts = this.repo.All();
            ICollection<ProductApiModel> products =
                (from currProduct in dbProducts
                 select new ProductApiModel()
                 {
                     Id = currProduct.Id,
                     Name = currProduct.Name,
                     ImageUrl = currProduct.Image.Url,
                 }).ToList();
        
            return this.Request.CreateResponse(HttpStatusCode.OK, products);
        }

        [ActionName("postFiltered")]
        public HttpResponseMessage PostFiltered(FiltrationModel filter, string sessionKey)
        {
            if (String.IsNullOrEmpty(sessionKey))
            {
                throw new ArgumentException("Not allowed action for non - logged user!");
            }

            List<Gender> gen = Converter.GetGender(filter.Genders);
            List<Category> cat = Converter.GetCategory(filter.Categories);

            ICollection<Product> dbFiltered = this.repo.Get(gen, cat);

            ICollection<ProductApiModel> filtered =
                (from curr in dbFiltered
                 select new ProductApiModel()
                 {
                     Id = curr.Id,
                     Name = curr.Name,
                     BasePrice = curr.BasePrice,
                     Brand = curr.Brand,
                     Category = curr.Category,
                     Gender = curr.Gender,
                     ImageUrl = curr.Image.Url,
                 }).ToList();

            return this.Request.CreateResponse(HttpStatusCode.OK, filtered);
        }

        [ActionName("AllNewProducts")]
        public HttpResponseMessage GetAllNewProducts(string sessionKey)
        {
            this.storeProductRepo = new DbProductStoreRepository(context);

            // in store
            ICollection<ProductStore> productStoreNodes = this.storeProductRepo.All().ToList();
            ICollection<Product> productsInStore = (from curr in productStoreNodes
                                                    select curr.Product).ToList();

            // all possible
            IQueryable<Product> productsInWh = this.repo.All();

            ICollection<ProductApiModel> newProducts = new List<ProductApiModel>();

            foreach (var whProduct in productsInWh)
            {
                if (productsInStore.Contains(whProduct))
                {
                }
                else
                {
                    newProducts.Add(new ProductApiModel()
                    {
                        Id = whProduct.Id,
                        //ImageUrl = whProduct.Image.Url,
                        Gender = whProduct.Gender,
                        Category = whProduct.Category,
                        Brand = whProduct.Brand,
                        BasePrice = whProduct.BasePrice
                    });
                }
            }
            
            return this.Request.CreateResponse(HttpStatusCode.OK, newProducts);
        }
    }
}
