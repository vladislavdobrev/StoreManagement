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
        private static int storeId;

        static DataPersister()
        {
            httpClient = new MsClient();
        }

        // products

        public static ObservableCollection<ProductClientModel> GetAllProducts()
        {
            ObservableCollection<ProductClientModel> allProducts =
                httpClient.GetAllProducts(sessionKey);

            return allProducts;
        }

        public static ObservableCollection<ProductClientModel> AllNewProducts(string sessionKey)
        {
            ObservableCollection<ProductClientModel> allNewProducts =
               httpClient.AllNewProducts(sessionKey);

            return allNewProducts;
        }

        // user

        public static string Register(UserRegisterClientModel registerModel)
        {
            storeId = registerModel.StoreId;
            string result = httpClient.RegisterUser(registerModel);

            return result;
        }

        public static string Login(UserLoginClientModel loginModel)
        {
            UserLoggedClientModel result = httpClient.LoginUserGetSessionKey(loginModel);

            if (result.Username.Contains("!"))
            {
                return result.Username;
            }
            storeId = result.StoreId + 1;
            sessionKey = result.SessionKey;

            return null;
        }

        // storeproducts

        public static ObservableCollection<ProductClientModel> GetAllStoreProducts()
        {
            ObservableCollection<StoreProductClientFullDescModel> result =
                httpClient.GetAllStoreProducts(sessionKey, storeId);

            ObservableCollection<ProductClientModel> productsInStore = new ObservableCollection<ProductClientModel>();

            foreach (var node in result)
            {
                productsInStore.Add(node.Product);
            }

            return productsInStore;
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
