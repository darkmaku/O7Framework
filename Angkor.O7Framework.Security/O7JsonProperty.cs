// Create by Felix A. Bueno

namespace Angkor.O7Framework.Utility
{
    public class O7JsonProperty
    {
        public static string GetStringValue(object value, string parameter)
        {
            var method = value.GetType().GetMethod("Value");
            method = method.MakeGenericMethod(typeof(string));
            return method.Invoke(value, new object[] {parameter}) as string;
//            var json = JToken.FromObject(value);
//            var login = json.Value<string>(parameter);
//            var password = json.Value<string>("Password");
//
//            var properties = value.GetType().GetProperties();
//            for (var i = 0; i < properties.Length; i++)
//            {
//                var property = properties[i];
//                if (property.Name == parameter)
//                    return property.GetValue(value) as string;
//            }
//            throw O7AttributeException.MakeGetterException;
        }
    }
}