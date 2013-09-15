using Forum.WebApi.Bridges;
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
    public class StoreProductsController : ApiController
    {
        private DbProductStoreRepository repo;
        private MelonStoreContext context;

        public StoreProductsController()
        {
            this.context = new MelonStoreContext();
            this.repo = new DbProductStoreRepository(context);
        }

        [ActionName("add")]
        public HttpResponseMessage PostAdd(ProductStoreApiFullDescModel futureProductStore)
        {
            ProductStore dbProductStore = new ProductStore()
            {
                Count = futureProductStore.Count,
                Price = futureProductStore.Price,
                Product_Id = futureProductStore.ProductId,
                Store_Id = futureProductStore.StoreId
            };
            this.repo.Add(dbProductStore);

            return this.Request.CreateResponse(HttpStatusCode.Created);
        }

        [ActionName("buy")]
        public HttpResponseMessage UpdateBuy(int productId, int storeId, ProductStoreApiSellBuyModel product)
        {
            ProductStore convertedProduct = Searilizator.Searilize<ProductStore, ProductStoreApiSellBuyModel>(product);
            this.repo.Update(productId, storeId, convertedProduct);

            return this.Request.CreateResponse(HttpStatusCode.OK, convertedProduct);
        }

        [ActionName("sell")]
        public HttpResponseMessage UpdateSell(int productId, int storeId, ProductStoreApiSellBuyModel productModel)
        {
            // sell -> 
            productModel.Price = -(productModel.Price);
            productModel.DateSold = DateTime.Now;
            ProductStore convertedProduct = Searilizator.Searilize<ProductStore, ProductStoreApiSellBuyModel>(productModel);
            this.repo.Update(productId, storeId, convertedProduct);

            return this.Request.CreateResponse(HttpStatusCode.OK, convertedProduct);
        }

        [ActionName("all")]
        public HttpResponseMessage GetAll()
        {
            ICollection<ProductStore> dbProducts = this.repo.All().ToList();
            ICollection<ProductStoreApiFullDescModel> convertedProducts =
                (from currDbProduct in dbProducts
                 select new ProductStoreApiFullDescModel()
                 {
                     Count = currDbProduct.Count,
                     LastDateSold = currDbProduct.LastDateSold,
                     Price = currDbProduct.Price,
                     Product = new ProductApiModel()
                     {
                         Name = currDbProduct.Product.Name,
                         ImagePath = currDbProduct.Product.Image.Url
                     }
                 }).ToList();

            return this.Request.CreateResponse(HttpStatusCode.OK, convertedProducts);
        }

        [ActionName("get")]
        public HttpResponseMessage Get(int productId, int storeId)
        {
            ProductStore dbProduct = this.repo.Get(productId, storeId);
            ProductStoreApiFullDescModel convertedProduct =
              new ProductStoreApiFullDescModel()
            {
                Count = dbProduct.Count,
                Price = dbProduct.Price,
                LastDateSold = dbProduct.LastDateSold,
                Product = new ProductApiModel()
                {
                    Name = dbProduct.Product.Name,
                    ImagePath = dbProduct.Product.Image.Url
                },
            };
            return this.Request.CreateResponse(HttpStatusCode.OK, convertedProduct);
        }
    }
}
