using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MelonStoreApp.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string SessionKey { get; set; }
        public string Password { get; set; }
        public Nullable<int> Store_Id { get; set; }
    }
}
