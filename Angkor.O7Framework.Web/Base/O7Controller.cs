// Create by Felix A. Bueno

using System.Diagnostics.Contracts;
using System.Web.Mvc;
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
                return (O7Principal) HttpContext.User;
            }
        }
    }
}