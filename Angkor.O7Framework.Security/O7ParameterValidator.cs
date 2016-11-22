// Create by Felix A. Bueno

using System.Linq;

namespace Angkor.O7Framework.Utility
{
    public class O7ParameterValidator
    {
        public static bool IsNotEmpty(params string[] value)
        {
            return value.All(val => !string.IsNullOrEmpty(val));
        }
    }
}