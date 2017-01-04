using System.Linq;

namespace Angkor.O7Framework.Common.Validator
{
    public static class StringsValidator
    {
        public static bool AllNotNull(params string[] strings)
        {            
            return strings.All(s => !string.IsNullOrEmpty(s));
        }


    }
}
