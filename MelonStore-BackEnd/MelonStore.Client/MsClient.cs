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

namespace MelonStore.Client
{
    public class MsClient
    {
        public const string PRODUCTS_GET_ALL = "/products?sessionKey=";
        public const string PRODUCTS_POST_FILTERED = "/products?sessionKey=";
        public const string STOREPRODUCT_ADD_NEW = "/storeproducts?sessionKey=";
        public const string USER_REGISTER = "/users/register";

        public const string BASE = "http://localhost:1671/api";

        private HttpClient httpClient;

        public MsClient()
        {
            this.httpClient = new HttpClient();
            //this.httpClient.BaseAddress = new Uri(MsClient.BASE);
        }

        // products service consumming

        //get
        public ICollection<ProductClientModel> GetAllProducts(string sessionKey)
        {
            var response =
                this.httpClient.GetAsync(MsClient.BASE + MsClient.PRODUCTS_GET_ALL + sessionKey).Result;

            var result = response.Content.ReadAsStringAsync().Result;

            ICollection<ProductClientModel> products =
                JsonConvert.DeserializeObject<ICollection<ProductClientModel>>(result);

            return products;
        }
        // post
        public ICollection<ProductClientModel> GetAllByFilters(FiltrationModel filtration, string sessionKey)
        {
            HttpContent postContent = new StringContent(JsonConvert.SerializeObject(filtration));
            postContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");

            var response =
                this.httpClient.PostAsync(MsClient.BASE + MsClient.PRODUCTS_POST_FILTERED + sessionKey, postContent).Result;

            var result = response.Content.ReadAsStringAsync().Result;

            ICollection<ProductClientModel> products =
                JsonConvert.DeserializeObject<ICollection<ProductClientModel>>(result);

            return products;
        }

        // storeproducts service consumming

        public void PostStoreProductNode(StoreProductClientFullDescModel node, string sessionKey)
        {
            HttpContent postContent = new StringContent(JsonConvert.SerializeObject(node));
            postContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");

            var response =
                this.httpClient.PostAsync(MsClient.BASE + MsClient.STOREPRODUCT_ADD_NEW + sessionKey, postContent).Result;

            var result = response.Content.ReadAsStringAsync().Result;
        }

        // users service consumming

        public void RegisterUser(UserRegisterClientModel registerModel)
        {
            registerModel = new UserRegisterClientModel()
            {
                Username = "sample",
                Password = "daipak",
                StoreId = 2,
            };

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

            //UserLoggedClientModel loggedUser = JsonConvert.DeserializeObject<UserLoggedClientModel>(result);

        }

        //public string LoginUserGetSessionKey(UserLoginClientModel loginUser)
        //{
        //
        //}
    }
}
