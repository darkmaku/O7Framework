// Create by Felix A. Bueno
using System.Diagnostics.Contracts;
using System.Web.Mvc;
using Angkor.O7Framework.Web.Model;
using Angkor.O7Framework.Web.Security;
using Angkor.O7Framework.Web.HtmlHelper;
using System.Web;

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
                return new O7Principal(user.Login, user.Company, user.Branch, user.Name, user.Password,user.UserApplication,user.Attributes);                
            }
        }

        public ActionResult ReturnToServerError(string message)
        {
            return Redirect(LinkHelper.SourceLink("Error", "ServerError") + "?message=" + HttpUtility.UrlEncode(message));
        }

        public ActionResult ReturnToAuthorizationError(string message)
        {
            return Redirect(LinkHelper.SourceLink("Error", "AuthorizationError") + "?message=" + HttpUtility.UrlEncode(message));
        }

        public ActionResult ReturnToUnfoundError(string message)
        {
            return Redirect(LinkHelper.SourceLink("Error", "UnfoundError") + "?message=" + HttpUtility.UrlEncode(message));
        }
    }
}