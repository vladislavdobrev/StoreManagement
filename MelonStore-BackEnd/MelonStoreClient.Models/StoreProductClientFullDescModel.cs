using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MelonStoreClient.Models
{
    public class StoreProductClientFullDescModel
    {
        public decimal Price { get; set; }
        public int Count { get; set; }
        public int ProductId { get; set; }
        public ProductClientModel Product { get; set; }
        public DateTime? LastDateSold { get; set; }
        public int StoreId { get; set; }
    }
}
