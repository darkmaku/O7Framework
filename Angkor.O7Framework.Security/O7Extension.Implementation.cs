// Create by Felix A. Bueno

using System;
using System.Reflection;

namespace Angkor.O7Framework.Utility
{
    public static partial class O7Extension
    {
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
            if (value is T) return (T)value;
            throw new InvalidCastException();
        }

        private static string append(object currentValue, object appendValue)
        {
            return $"{currentValue}{appendValue}";
        }
    }
}