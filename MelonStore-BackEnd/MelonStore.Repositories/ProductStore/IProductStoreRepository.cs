using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MelonStore.Repositories
{
    public interface IProductStoreRepository<T>
        where T:class
    {
        IQueryable<T> All();

        T Get(int storeId, int productId);

        T Add(T item);


        void Update(int storeId, int productId, T item);
    }
}
