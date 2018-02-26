// Create by Felix A. Bueno
using System.Diagnostics.Contracts;
using fastJSON;

namespace Angkor.O7Framework.Utility
{
    public static class O7JsonSerealizer
    {
        public static string Serialize(object obj)
        {
            Contract.Requires(obj != null);
            return JSON.ToJSON(obj);            
        }

        public static TResult Deserialize<TResult>(string json) where TResult : class
        {
            Contract.Requires(!string.IsNullOrEmpty(json));            
            Contract.Ensures(Contract.Result<TResult>() != null);
            return JSON.ToObject<TResult>(json);
        }
    }
}