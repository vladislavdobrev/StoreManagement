using MelonStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MelonStore.Repositories
{
    public interface IProductRepository<T>
        where T : class
    {
        IQueryable<T> All();
        IQueryable<T> Get(Gender gender, Category category);
    }
}
