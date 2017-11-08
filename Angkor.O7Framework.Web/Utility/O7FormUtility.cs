// Solution: O7Framework
// Owner: FBUENO
// Date: 07 - 11 - 2017

using System.Collections.Specialized;

namespace Angkor.O7Framework.Web.Utility
{
    public static class O7FormUtility
    {
        public static string[] ParametersValue(this NameValueCollection formCollection, params string[] parameters)
        {
            var strArray = new string[parameters.Length];
            for (var index = 0; index < parameters.Length; ++index)
                strArray[index] = formCollection[parameters[index]];
            return strArray;
        }
    }
}