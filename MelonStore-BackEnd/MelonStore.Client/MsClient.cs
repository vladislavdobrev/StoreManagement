using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using MelonStoreClient.Models;
using Newtonsoft.Json;
using MelonStore.Client.Models;
using System.Security.Cryptography;
using System.Collections.ObjectModel;

namespace MelonStore.Client
{
    public class MsClient
    {
        public const string PRODUCTS_GET_ALL_I = "/products/all?sessionKey=";
        public const string PRODUCTS_GET_ALL_II = "&storeId=";
        public const string PRODUCTS_POST_FILTERED = "/products/postFiltered?sessionKey=";
        public const string STOREPRODUCT_ADD_NEW = "/storeproducts?sessionKey=";
        public const string USER_REGISTER = "/users/register";
        public const string USER_LOGIN = "/users/login";
        public const string USER_LOGOUT = "/users/logout?sessionKey=";
        public const string STOREPRODUCT_UPDATE_I = "/storeproducts?productId=";
        public const string STOREPRODUCT_UPDATE_II = "&storeId=";
        public const string STOREPRODUCT_UPDATE_III = "&sessionKey=";
        public const string STOREPRODUCT_GET_ALL = "/storeproducts?sessionKey=";
        public const string STORE_GET_ALL = "/stores?sessionKey=";
        public const string PRODUCTS_GET_ALL_NEW = "/products/AllNewProducts?sessionKey=";

        public const string BASE = "http://localhost:1671/api";

        private HttpClient httpClient;

        public MsClient()
        {
            this.httpClient = new HttpClient();
            //this.httpClient.BaseAddress = new Uri(MsClient.BASE);
        }

        // products service consumming

        //get
        public ObservableCollection<ProductClientModel> GetAllProducts(string sessionKey)
        {
            var response =
                this.httpClient.GetAsync(MsClient.BASE + MsClient.PRODUCTS_GET_ALL_I + sessionKey).Result;

            var result = response.Content.ReadAsStringAsync().Result;

            ObservableCollection<ProductClientModel> products =
                JsonConvert.DeserializeObject<ObservableCollection<ProductClientModel>>(result);

            return products;
        }


        //get all new

        public ObservableCollection<ProductClientModel> AllNewProducts(string sessionKey)
        {
            var response =
               this.httpClient.GetAsync(MsClient.BASE + MsClient.PRODUCTS_GET_ALL_I + sessionKey).Result;

            var result = response.Content.ReadAsStringAsync().Result;

            ObservableCollection<ProductClientModel> allNew =
               JsonConvert.DeserializeObject<ObservableCollection<ProductClientModel>>(result);

            return allNew;
        }

        // post
        public ObservableCollection<ProductClientModel> GetAllByFilters(FiltrationModel filtration, string sessionKey)
        {
            HttpContent postContent = new StringContent(JsonConvert.SerializeObject(filtration));
            postContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");

            var response =
                this.httpClient.PostAsync(MsClient.BASE + MsClient.PRODUCTS_POST_FILTERED + sessionKey, postContent).Result;

            var result = response.Content.ReadAsStringAsync().Result;

            ObservableCollection<ProductClientModel> products =
                JsonConvert.DeserializeObject<ObservableCollection<ProductClientModel>>(result);

            return products;
        }

        // storeproducts service consumming

        // add new
        public void PostStoreProductNode(StoreProductClientFullDescModel node, string sessionKey)
        {
            //node = new StoreProductClientFullDescModel()
            //{
            //    ProductId = 2,
            //    StoreId = 1,
            //    Count = 100,
            //    Price = 12,
            //};

            HttpContent postContent = new StringContent(JsonConvert.SerializeObject(node));
            postContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");

            var response =
                this.httpClient.PostAsync(MsClient.BASE + MsClient.STOREPRODUCT_ADD_NEW + sessionKey, postContent).Result;

            var result = response.Content.ReadAsStringAsync().Result;
        }

        // update existing
        public void PutStoreProductNode(StoreProductClientModel modelToUpdate, string sessionKey)
        {

            //modelToUpdate = new StoreProductClientModel()
            //{
            //    ProductId = 2,
            //    StoreId = 1,
            //    Count = 150,
            //    Price = 40
            //};

            HttpContent postContent = new StringContent(JsonConvert.SerializeObject(modelToUpdate));
            postContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");

            var response =
                this.httpClient.PutAsync(MsClient.BASE + MsClient.STOREPRODUCT_UPDATE_I + modelToUpdate.ProductId
                + MsClient.STOREPRODUCT_UPDATE_II + modelToUpdate.StoreId + MsClient.STOREPRODUCT_UPDATE_III + sessionKey, postContent).Result;

            var result = response.Content.ReadAsStringAsync().Result;
        }

        public ObservableCollection<StoreProductClientFullDescModel> GetAllStoreProducts(string sessionKey, int storeId)
        {
            var response =
                this.httpClient.GetAsync(MsClient.BASE + MsClient.STOREPRODUCT_GET_ALL +
                sessionKey + MsClient.PRODUCTS_GET_ALL_II + storeId).Result;

            var result = response.Content.ReadAsStringAsync().Result;

            ObservableCollection<StoreProductClientFullDescModel> all =
                JsonConvert.DeserializeObject<ObservableCollection<StoreProductClientFullDescModel>>(result);

            return all;
        }


        // users service consumming

        public string RegisterUser(UserRegisterClientModel registerModel)
        {
            // hashing pass
            SHA1 sha1 = new SHA1Cng();
            byte[] passAsBytes = new byte[registerModel.Password.Length * sizeof(char)];
            Buffer.BlockCopy(registerModel.Password.ToCharArray(), 0, passAsBytes, 0, passAsBytes.Length);

            byte[] sha1PassAsByte = sha1.ComputeHash(passAsBytes);

            registerModel.Password = BitConverter.ToString(sha1PassAsByte).Replace("-", "");

            HttpContent postContent = new StringContent(JsonConvert.SerializeObject(registerModel));
            postContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");

            var response =
                this.httpClient.PostAsync(MsClient.BASE + MsClient.USER_REGISTER, postContent).Result;

            var result = response.Content.ReadAsStringAsync().Result;

            // UserRegisterClientModel regModel = JsonConvert.DeserializeObject<UserRegisterClientModel>(result);

            return result;
        }

        public UserLoggedClientModel LoginUserGetSessionKey(UserLoginClientModel loginUser)
        {

            SHA1 sha1 = new SHA1Cng();
            byte[] passAsBytes = new byte[loginUser.Password.Length * sizeof(char)];
            Buffer.BlockCopy(loginUser.Password.ToCharArray(), 0, passAsBytes, 0, passAsBytes.Length);

            byte[] sha1PassAsByte = sha1.ComputeHash(passAsBytes);

            loginUser.Password = BitConverter.ToString(sha1PassAsByte).Replace("-", "");

            HttpContent postContent = new StringContent(JsonConvert.SerializeObject(loginUser));
            postContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");

            var response =
                this.httpClient.PostAsync(MsClient.BASE + MsClient.USER_LOGIN, postContent).Result;

            var result = response.Content.ReadAsStringAsync().Result;

            try
            {
                UserLoggedClientModel loggedUser =
                     JsonConvert.DeserializeObject<UserLoggedClientModel>(result);
                return loggedUser;
            }
            catch (Exception ex)
            {
                return new UserLoggedClientModel() { Username = result };
            }
            return null;
        }

        public void Loggout(string sessionKey)
        {
            var response =
                this.httpClient.PutAsync(MsClient.BASE + MsClient.USER_LOGOUT + sessionKey, null).Result;
        }

        // store service consumming

        public ObservableCollection<StoreClientModel> GetAllStores(string sessionKey)
        {
            var response =
                this.httpClient.GetAsync(MsClient.BASE + MsClient.STORE_GET_ALL + sessionKey).Result;

            var result = response.Content.ReadAsStringAsync().Result;

            ObservableCollection<StoreClientModel> all =
                JsonConvert.DeserializeObject<ObservableCollection<StoreClientModel>>(result);

            return all;
        }
    }
}
