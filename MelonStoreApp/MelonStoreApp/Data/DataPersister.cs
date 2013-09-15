using System.Collections.Generic;
namespace MelonStoreApp.Data
{
    public class DataPersister
    {
        internal static string LoginUser(string username, string password)
        {
            var userModel = new Models.User
            {
                Username = username,
                Password = password
            };

            //var loginResponse = HttpRequester.Post<LoginResponseModel>(BaseServicesUrl + "auth/token",
            //    userModel);
            //AccessToken = loginResponse.AccessToken;
            //return loginResponse.Username;

            return username;
        }

        internal static List<string> GetStores()
        {
            return new List<string> { "store1", "store2", "store3" };
        }
    }
}