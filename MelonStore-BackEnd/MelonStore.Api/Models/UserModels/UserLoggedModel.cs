using MelonStore.Models;
using System;
using System.Linq;
using System.Runtime.Serialization;

namespace MelonStore.Api.Models
{
    [DataContract]
    public class UserLoggedModel
    {
        [DataMember(Name = "id")]
        public int Id { get; set; }

        [DataMember(Name = "username")]
        public string Username { get; set; }

        [DataMember(Name = "sessionKey")]
        public string SessionKey { get; set; }

        [DataMember(Name = "storeId")]
        public int? StoreId { get; set; }

        public static UserLoggedModel CreateModel(User user)
        {
            UserLoggedModel model = new UserLoggedModel()
            {
                Id = user.Id,
                Username = user.Username,
                SessionKey = user.SessionKey,
                StoreId = user.Store_Id,
            };

            return model;
        }
    }
}