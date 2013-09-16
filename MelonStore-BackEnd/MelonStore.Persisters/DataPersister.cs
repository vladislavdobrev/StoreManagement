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

        public static ICollection<ProductClientModel> GetAllProducts(string sessionKey)
        {

            return null;
        }

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

        public static ObservableCollection<ProductClientModel> GetStoreProducts()
        {
            ObservableCollection<ProductClientModel> result =
                httpClient.GetAllProducts(sessionKey);

            return result;
        }
    }
}
