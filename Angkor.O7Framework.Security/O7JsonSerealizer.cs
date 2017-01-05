// Create by Felix A. Bueno

using System;
using System.Collections;
using System.Diagnostics.Contracts;
using System.Reflection;
using System.Text;
using Angkor.O7Framework.Common.Validator;

namespace Angkor.O7Framework.Utility
{
    public static class O7JsonSerealizer
    {
        public static string Serialize(object obj)
        {
            var type = obj.GetType();
            return type.IsGenericType ? build_generic(obj, type) : build_non_generic(obj, type);
        }

        public static TResult Deserialize<TResult>(string json) where TResult : class
        {
            Contract.Ensures(ContractValidator.ValidTResultResult(Contract.Result<TResult>()));
            var typeResult = typeof(TResult);
            var result = Activator.CreateInstance(typeResult);
            object_initialize(result, typeResult.GetProperties(), json);
            return (TResult) result;
        }

        private static void object_initialize(object obj, PropertyInfo[] objProperties, string json)
        {
            var jsonProperties = build_json_properties(json);            
            for (var i = 0; i < jsonProperties.Length; i++)
            {
                var jsonProperty = jsonProperties[i];
                var jsonMetaProperty = jsonProperty.Split(':');
                var jsonPropertyName = remove_quoqes(jsonMetaProperty[0]);
                var jsonPropertyValue = build_json_value(jsonMetaProperty[1]);
                sync_value(obj, objProperties, jsonPropertyName, jsonPropertyValue);
            }
        }

        private static void sync_value(object obj, PropertyInfo[] properties, string name, string value)
        {
            for (var i = 0; i < properties.Length; i++)
            {
                var property = properties[i];
                if (property.Name != name) continue;
                var convertValue = Convert.ChangeType(value, property.PropertyType);
                property.SetValue(obj, convertValue);
            }
        }

        private static string build_json_value(string value) => value.Contains("\"") ? remove_quoqes(value) : value;

        private static string[] build_json_properties(string value)
        {
            var result = value.Remove(0, 1);
            return result.Remove(result.Length - 1, 1).Split(',');
        }

        private static string remove_quoqes(string json)
        {
            var result = json.Remove(0, 1);
            return result.Remove(result.Length - 1, 1);
        }

        private static string build_non_generic(object obj, Type type)
        {
            if (type.IsPrimitive)
                return $"{obj}";
            var properties = type.GetProperties();
            return $"{{{build_entity(obj, properties, properties.Length)}}}";
        }

        private static string build_generic(object obj, Type type)
            => $"[{build_entity_list(obj, type)}]";


        private static string build_entity_list(object obj, Type type)
        {
            var list = (IList) obj;
            var stringBuilder = new StringBuilder();
            for (var i = 0; i < list.Count; i++)
            {
                var item = list[i];                
                stringBuilder.Append($"{build_non_generic(item, item.GetType())}{build_comma(i + 1 < list.Count)}");                
            }
            return stringBuilder.ToString();
        }

        private static string build_entity(object obj, PropertyInfo[] properties, int length)
        {
            var stringBuilder = new StringBuilder();
            for (var i = 0; i < length; i++)
            {
                var property = properties[i];
                stringBuilder.Append($"\"{property.Name}\":{build_value(property.GetValue(obj))}{build_comma(i + 1 < length)}");
            }
            return stringBuilder.ToString();
        }

        private static string build_value(object obj)
            => obj is string ? $"\"{obj}\"" : $"{obj}";

        private static string build_comma(bool value)
            => value ? "," : string.Empty;
    }
}