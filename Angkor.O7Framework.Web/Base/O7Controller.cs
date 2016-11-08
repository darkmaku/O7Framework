// Create by Felix A. Bueno

using System.Web.Mvc;
using Angkor.O7Framework.Web.Security;

namespace Angkor.O7Framework.Web.Base
{
    public class O7Controller : Controller
    {
        protected new virtual O7Principal User => HttpContext.User as O7Principal;
    }
}