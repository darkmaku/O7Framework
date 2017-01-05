// Create by Felix A. Bueno

using System.Web.Mvc;
using Angkor.O7Framework.Web.Base;
using Angkor.O7Framework.Web.Utility;
using System.Diagnostics.Contracts;
using Angkor.O7Framework.Common.Model;

namespace Angkor.O7Framework.Web.WebResult
{
    public class O7HttpResult
    {
        public static O7JsonResult MakeJsonResult(O7Response value) 
            => new O7JsonResult(value);

        public static O7RedirectResult MakeRedirectLogin() 
            => new O7RedirectResult("Security");

        public static O7RedirectResult MakeRedirectError(int code, string message) 
            => new O7RedirectResult(code, message);

        public static ActionResult MakeActionResult<TViewModel>(O7Response response, O7ViewModelMapper<TViewModel> mapper) 
            where TViewModel : O7ViewModel
        {
            Contract.Requires(mapper != null);
            var errorResponse = response as O7ErrorResponse;
            if (errorResponse != null) return new O7RedirectResult(errorResponse);            
            return new O7ViewResult(mapper.MapTarget());
        }
    }
}