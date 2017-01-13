// Create by Felix A. Bueno

using System;
using System.Diagnostics.Contracts;
using Angkor.O7Framework.Common.Validator;

namespace Angkor.O7Framework.Utility
{
    public static partial class O7JsonSerealizer
    {
        public static string Serialize(object obj)
        {
            Contract.Requires(obj != null);
            var type = obj.GetType();
            return type.IsGenericType ? build_generic(obj, type) : build_non_generic(obj, type);
        }

        public static TResult Deserialize<TResult>(string json) where TResult : class
        {
            Contract.Requires(ContractValidator.StringIsJson(json));
            Contract.Ensures(Contract.Result<TResult>() != null);
            var typeResult = typeof(TResult);
            var result = Activator.CreateInstance(typeResult);
            result = object_initialize(result, json);
            return (TResult) result;
        }
    }
}