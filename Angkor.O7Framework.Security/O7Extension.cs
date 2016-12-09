﻿// Create by Felix A. Bueno

using System;
using System.Collections.Generic;
using System.Reflection;
using Angkor.O7Framework.Data.Common;

namespace Angkor.O7Framework.Utility
{
    public static class O7Extension
    {
        public static List<TEntity> Append<TValue,TEntity>(this List<TEntity> list, string propertyName, TValue value)
            where TEntity : O7Entity
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
            return list;
        }

        public static string ToUriPath(this string url)
        {
            return replacePercentEncoding(url, new Tuple<string, string>("!", "%21"),
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

        private static string replacePercentEncoding(string url, params Tuple<string, string>[] values)
        {
            for (var i = 0; i < values.Length; i++)
                url = replaceChar(url, values[i]);
            return url;
        }

        private static string replaceChar(string url, Tuple<string, string> value)
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