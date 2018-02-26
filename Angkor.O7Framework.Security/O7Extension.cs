// Create by Felix A. Bueno

using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using Angkor.O7Framework.Common.Validator;

namespace Angkor.O7Framework.Utility
{
    public static partial class O7Extension
    {
        public static void Append<TValue,TEntity>(this List<TEntity> list, string propertyName, TValue value)            
        {
            Contract.Requires(ContractValidator.StringIsNotNullOrEmpty(propertyName));
            var type = typeof(TEntity);
            var property = type.GetProperty(propertyName);
            foreach (var entity in list)
            {
                var currentValue = get_value<TValue>(property, entity);
                if (currentValue is string)
                    property.SetValue(entity, append(currentValue, value));
                else
                    property.SetValue(entity, value);
            }
        }

        public static string GetValueFrom(this string source, string name)
        {
            Contract.Requires(ContractValidator.StringIsSource(source) && ContractValidator.StringIsNotNullOrEmpty(name));
            var values = source.Split(';');
            foreach (var value in values)
            {
                var current = value.Split('=');
                if (current[0] == name) return current[1];
            }
            return string.Empty;
        }

        public static string ToUriPath(this string url)
        {            
            Contract.Ensures(ContractValidator.StringIsNotNullOrEmpty(Contract.Result<string>()));
            return replace_percent_encoding(url, new Tuple<string, string>("!", "%21"),
                new Tuple<string, string>("#", "%23"), new Tuple<string, string>("$", "%24"),
                new Tuple<string, string>("&", "%26"), new Tuple<string, string>("'", "%27"),
                new Tuple<string, string>("(", "%28"), new Tuple<string, string>(")", "%29"),
                new Tuple<string, string>("*", "%2A"), new Tuple<string, string>("+", "%2B"),
                new Tuple<string, string>(",", "%2C"), new Tuple<string, string>("/", "%2F"),
                new Tuple<string, string>(":", "%3A"), new Tuple<string, string>(";", "%3B"),
                new Tuple<string, string>("=", "%3D"), new Tuple<string, string>("?", "%3F"),
                new Tuple<string, string>("@", "%40"), new Tuple<string, string>("[", "%5B"),
                new Tuple<string, string>("]", "%5D"));
        }        
    }
}