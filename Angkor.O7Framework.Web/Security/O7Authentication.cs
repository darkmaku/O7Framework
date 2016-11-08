// Create by Felix A. Bueno

using System;
using System.Web;
using System.Web.Security;
using Angkor.O7Framework.Utility;

namespace Angkor.O7Framework.Web.Security
{
    public class O7Authentication
    {
        public static HttpCookie Generate(O7User user)
        {
            var userJson = O7JsonSerealizer.Serialize(user);
            var ticket = new FormsAuthenticationTicket(1, user.Login, DateTime.Now, DateTime.Now.AddMinutes(20), false, userJson);
            var encrypted = FormsAuthentication.Encrypt(ticket);
            return new HttpCookie(FormsAuthentication.FormsCookieName, encrypted);
        }

        public static O7Principal Extract(HttpCookie cookie)
        {
            var ticket = FormsAuthentication.Decrypt(cookie.Value);
            var user = O7JsonSerealizer.Deserialize<O7User>(ticket.UserData);
            return new O7Principal(user.Login, user.Company, user.Branch, user.Name, user.Password);
        }
    }
}