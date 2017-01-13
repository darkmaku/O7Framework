// Create by Felix A. Bueno
using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Angkor.O7Framework.Utility
{
    public static partial class O7JsonSerealizer
    {
        private static bool json_is_generic(string json)
        {
            return json[0] == '[' && json[json.Length-1] == ']';
        }

        private static bool json_is_class(string json)
        {
            return json[0] == '{' && json[json.Length - 1] == '}';
        }

        
        private static List<string> get_json_segment_attribute(string segment)
        {
            var openNonGeneric = 0;
            var openGeneric = 0;
            var attributeValue = false;
            var result = new List<string>();
            var builder = new StringBuilder();
            for (var i = 0; i < segment.Length; i++)
            {
                if (segment[i] == ':' && openGeneric == 0) attributeValue = true;

                if (attributeValue)
                {
                    if (segment[i] == '"' && openGeneric == 0)
                    {
                        openNonGeneric++;
                        builder.Append(segment[i]);                        
                        if (openNonGeneric == 2)
                        {
                            openNonGeneric = 0;                            
                            result.Add(builder.ToString());
                            i++;
                            builder = new StringBuilder();
                            attributeValue = false;                            
                        }
                        continue;
                    }
                    
                    if (segment[i] == '[')
                    {
                        openGeneric++;
                        builder.Append(segment[i]);                        
                        continue;
                    }

                    if (segment[i] == ']')
                    {
                        openGeneric--;
                        builder.Append(segment[i]);
                        if (openGeneric == 0)
                        {
                            i++;
                            result.Add(builder.ToString());
                            i++;
                            builder = new StringBuilder();
                            attributeValue = false;
                        }
                        continue;
                    }
                }
                if (openGeneric > 0 || (segment[i] != '{' && segment[i] != '}'))
                    builder.Append(segment[i]);
            }
            return result;
        }

        private static void validate_bracket_counter(char letter, ref int count)
        {
            if (letter == '{') count++;
            if (letter == '}') count--;
        }

        private static void add_json_to_list(ICollection<string> list, ref StringBuilder builder, ref int count)
        {
            var json = builder.ToString();
            list.Add(json);
            builder = new StringBuilder();
            count++;
        }

        private static List<string> get_json_segment(string json)
        {
            var openBracket = 0;
            var result = new List<string>();
            var builder = new StringBuilder();
            for (var i = 0; i < json.Length; i++)
            {
                var letter = json[i];
                validate_bracket_counter(letter, ref openBracket);
                builder.Append(letter);
                if (openBracket == 0) add_json_to_list(result, ref builder, ref i);
            }
            return result;
        }

        private static string get_attribute_name(string json)
        {
            var builder = new StringBuilder();
            var quoques = 0;            
            for (var i = 0; i < json.Length; i++)
            {
                if (json[i] == '"')
                {
                    quoques++;
                    continue;
                }
                if (quoques == 2)
                {                    
                    return builder.ToString();
                }
                builder.Append(json[i]);
            }
            return string.Empty;
        }

        private static string get_value_non_generic(string json)
        {
            var stringBuilder = new StringBuilder();
            var afterDot = false;
            for (int i = 0; i < json.Length; i++)
            {
                if (json[i] == ':' && !afterDot)
                {
                    afterDot = true;
                    i++;
                }
                if (afterDot)
                {
                    stringBuilder.Append(json[i]);
                }
            }
            return stringBuilder.ToString();
        }

        private static bool not_instanceable(Type type)
        {
            return !type.IsClass || type == typeof(string);
        }

        private static object build_json_simple(string json, object objToInsert)
        {                        
            var properties = objToInsert.GetType().GetProperties();            
            var attributes = get_json_segment_attribute(json);
            foreach (var attribute in attributes)
            {
                foreach (var property in properties)
                {
                    if (get_attribute_name(attribute) == property.Name)
                    {
                        var propertyObj = not_instanceable(property.PropertyType) ? "" : Activator.CreateInstance(property.PropertyType);
                        property.SetValue(objToInsert, object_initialize(propertyObj, get_value_non_generic(attribute)));
                    }
                }
            }
            return objToInsert;
        }

        private static object build_json_generic(string json, Type typeResult)
        {
            var listType = typeof(List<>);
            var resultListType = listType.MakeGenericType(typeResult);
            var resultList = (IList)Activator.CreateInstance(resultListType);
            json = remove_braces(json);
            var segments = get_json_segment(json);
            foreach (var segment in segments)
            {
                var item =Activator.CreateInstance(typeResult);
                resultList.Add(object_initialize(item, segment));
            }            
            return resultList;
        }

        private static object object_initialize(object obj, string json)
        {
            if (json_is_generic(json))
            {
                return build_json_generic(json, obj.GetType().GetGenericArguments()[0]);
            }
            else
            {
                if (json_is_class(json)) return build_json_simple(json, obj);
                return remove_quoqes(json);
            }
        }

        private static string remove_braces(string json)
        {
            var result = json.Remove(0, 1);
            return result.Remove(result.Length - 1);
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
            var list = (IList)obj;
            var stringBuilder = new StringBuilder();
            for (var i = 0; i < list.Count; i++)
            {
                var item = list[i];
                var itemType = item.GetType();
                var serializedItem = itemType.IsGenericType ? build_generic(item, itemType) : build_non_generic(item, itemType);
                stringBuilder.Append($"{serializedItem}{build_comma(i + 1 < list.Count)}");
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
        {
            string result;
            var objType = obj.GetType();
            if (objType.IsGenericType)            
                result = build_generic(obj, objType);            
            else 
                result = obj is string ? $"\"{obj}\"" : $"{obj}";
            return result;
        }

        private static string build_comma(bool value)
            => value ? "," : string.Empty;
    }
}