// Create by Felix A. Bueno
using System.Diagnostics.Contracts;
using System.Web.Mvc;
using Angkor.O7Framework.Web.Model;
using Angkor.O7Framework.Web.Security;

namespace Angkor.O7Framework.Web.Base
{
    public class O7Controller : Controller
    {
        protected new virtual O7Principal User
        {
            get
            {
                Contract.Requires(HttpContext.User is O7Principal);
                var user = new O7Authentication(Session).User;
                return new O7Principal(user.Login, user.Company, user.Branch, user.Name, user.Password,user.UserApplication,user.Atrributes);                
            }
        }
    }
}