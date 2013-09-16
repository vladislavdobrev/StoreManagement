using MelonStore.Client;
using MelonStore.Data;
using MelonStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TempClient
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            MsClient client = new MsClient();

            // var resultget =  client.GetAllProducts("xaxa");
            // var result = client.GetAllByFilters(null,"xaxa");
            // client.PostStoreProductNode(null,"xaxa");
            client.RegisterUser(null);

        }
    }
}
