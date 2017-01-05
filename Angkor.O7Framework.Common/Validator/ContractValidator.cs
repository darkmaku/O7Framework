// Create by Felix A. Bueno
namespace Angkor.O7Framework.Common.Validator
{
    public static class ContractValidator
    {
        public static bool StringIsNotNullOrEmpty(params string[] parameters)
        {
            for (var i = 0; i < parameters.Length; i++)
            {
                var parameter = parameters[i];
                if(string.IsNullOrEmpty(parameter)) return false;
            }
            return true;
        }

        public static bool StringIsSource(string source)
        {
            return source.Contains("=");
        }

        public static bool StringIsJson(string value)
        {
            if(string.IsNullOrEmpty(value)) return false;
            return value.Contains("{") && value.Contains("}") && value.Contains("\"") && value.Contains(":");
        }

    }
}