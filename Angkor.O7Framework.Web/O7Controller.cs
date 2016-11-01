// Create by Felix A. Bueno

using System.Web.Mvc;

namespace Angkor.O7Framework.Web
{
    public class O7Controller : Controller
    {
        protected new virtual O7Principal User => HttpContext.User as O7Principal;
    }
}