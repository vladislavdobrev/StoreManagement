using MelonStore.Client;
using MelonStoreClient.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MelonStore.Persisters
{
    public static class DataPersister
    {
        private static MsClient httpClient;

        static DataPersister()
        {
            httpClient = new MsClient();
        }

        public static ICollection<ProductClientModel> GetAllProducts(string sessionKey)
        {


            return null;
        }
    }
}
