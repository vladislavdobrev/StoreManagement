using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MelonStore.Models
{
    public class StoreProduct
    {
        public virtual Product Product { get; set; }
        public virtual Store Store { get; set; }
        public decimal Price { get; set; }
        public int Count { get; set; }
    }
}
