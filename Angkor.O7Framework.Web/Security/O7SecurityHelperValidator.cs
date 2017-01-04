using System;
using System.Web;
using Angkor.O7Framework.Common.Validator;

namespace Angkor.O7Framework.Web.Security
{
    public static class O7SecurityHelperValidator
    {
        public static bool ValidParameters(params string[] strings)
        {
            return StringsValidator.AllNotNull(strings);
        }

        public static bool ValidCookie(HttpCookie cookie)
        {
            return cookie != null;
        }
    }
}