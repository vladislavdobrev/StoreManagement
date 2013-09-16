using System.Collections.Generic;
namespace MelonStoreApp.Data
{
    public class DataPersister
    {
        internal static object LoginUser(string username, string password)
        {
            return true;
        }

        internal static List<string> GetStores()
        {
            return new List<string> { "store1", "store2", "store3" };
        }

        internal static object RegisterUser(string store, string username, string password)
        {
            return true;
        }
    }
}