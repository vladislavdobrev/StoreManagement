using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MelonStoreClient.Models
{
    public class UserLoggedClientModel
    {
        public string Username { get; set; }

        public string SessionKey { get; set; }

        public int StoreId { get; set; }
    }
}
