using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MelonStoreClient.Models
{
    public class UserRegisterClientModel
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public int StoreId { get; set; }
    }
}
