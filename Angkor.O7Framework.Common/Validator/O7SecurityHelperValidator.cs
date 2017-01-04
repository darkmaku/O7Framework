using System;
using System.Web;

namespace Angkor.O7Framework.Web.Security
{
    public static class O7SecurityHelperValidator
    {
        public static bool ValidParameters(string company, string branch, string login, string name, string password)
        {
            return !String.IsNullOrEmpty(company) && !String.IsNullOrEmpty(branch) && !String.IsNullOrEmpty(login) &&
                   !String.IsNullOrEmpty(name) && !String.IsNullOrEmpty(password);
        }

        public static bool ValidParameters(HttpCookie cookie)
        {
            return cookie != null;
        }
    }
}