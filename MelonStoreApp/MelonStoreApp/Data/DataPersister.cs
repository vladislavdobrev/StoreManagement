using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
