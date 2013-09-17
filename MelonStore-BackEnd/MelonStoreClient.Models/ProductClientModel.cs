using MelonStore.Client.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MelonStoreClient.Models
{
    public class ProductClientModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? Count { get; set; }
        public string Brand { get; set; }
        public decimal BasePrice { get; set; }
        public Category Category { get; set; }
        public Gender Gender { get; set; }
        public string ImagePath { get; set; }
    }
}
