using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MelonStore.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string SessionKey { get; set; }
        public string Password { get; set; }
        public virtual Store Store { get; set; }
    }
}
