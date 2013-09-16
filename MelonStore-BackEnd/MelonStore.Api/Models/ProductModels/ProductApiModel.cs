using MelonStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MelonStore.Api.Models.ProductStoreModels
{
    public class ProductApiModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Brand { get; set; }
        public Gender Gender { get; set; }
        public Category Category { get; set; }
        public decimal? Price { get; set; }
        public decimal BasePrice { get; set; }
        public string ImageUrl { get; set; }
    }
}