// Create by Felix A. Bueno

using System;
using System.Collections.Generic;
using System.Reflection;

namespace Angkor.O7Framework.Utility
{
    public static class O7Extension
    {
        public static void Append<TValue,TEntity>(this List<TEntity> list, string propertyName, TValue value)            
        {
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

        private static string replace_percent_encoding(string url, params Tuple<string, string>[] values)
        {
            for (var i = 0; i < values.Length; i++)
                url = replace_char(url, values[i]);
            return url;
        }

        private static string replace_char(string url, Tuple<string, string> value)
        {
            return url.Replace(value.Item1, value.Item2);
        }

        private static T get_value<T>(PropertyInfo info, object sourceObject)
        {
            var value = info.GetValue(sourceObject);
            if (value is T) return (T) value;
            throw new InvalidCastException();
        }

        private static string append(object currentValue, object appendValue)
        {
            return $"{currentValue}{appendValue}";
        }    
    }
}