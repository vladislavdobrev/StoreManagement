using MelonStore.Client;
using MelonStoreClient.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MelonStore.Persisters
{
    public static class DataPersister
    {
        private static MsClient httpClient;
        private static string sessionKey;

        static DataPersister()
        {
            httpClient = new MsClient();
        }

        // products

        public static ObservableCollection<ProductClientModel> GetAllProducts(string sessionKey)
        {
            ObservableCollection<ProductClientModel> allProducts =
                httpClient.GetAllProducts(sessionKey);

            return allProducts;
        }

        // user

        public static string Register(UserRegisterClientModel registerModel)
        {
            string result = httpClient.RegisterUser(registerModel);

            return result;
        }

        public static string Login(UserLoginClientModel loginModel)
        {
            string result = httpClient.LoginUserGetSessionKey(loginModel);
            if (result.Contains("!"))
            {
                return result;
            }
            sessionKey = result;

            return null;
        }

        // storeproducts

        public static ObservableCollection<ProductClientModel> GetAllStoreProducts()
        {
            ObservableCollection<ProductClientModel> result =
                httpClient.GetAllProducts(sessionKey);

            return result;
        }

        public static void AddNewProductToStore(StoreProductClientFullDescModel newNode)
        {
            httpClient.PostStoreProductNode(newNode, sessionKey);
        }

        public static void UpdateProductFromStore(StoreProductClientModel nodeToUpdate)
        {
            httpClient.PutStoreProductNode(nodeToUpdate, sessionKey);
        }

        public static ObservableCollection<StoreClientModel> GetAllStores()
        {
            ObservableCollection<StoreClientModel> result =
                httpClient.GetAllStores(sessionKey);

            return result;
        }
    }
}
