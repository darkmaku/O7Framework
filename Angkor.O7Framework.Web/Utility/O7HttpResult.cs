// Create by Felix A. Bueno

using System.Web.Mvc;
using Angkor.O7Framework.Domain.Response;

namespace Angkor.O7Framework.Web.Utility
{
    public class O7HttpResult
    {
        public static O7JsonResult MakeJsonResult(O7Response value) => new O7JsonResult(value);
    }

    public class O7JsonResult : JsonResult
    {
        private readonly O7Response _response;

        public O7JsonResult(O7Response value)
        {
            _response = value;
            JsonRequestBehavior = JsonRequestBehavior.AllowGet;
        }

        public override void ExecuteResult(ControllerContext context)
        {
            var errorResponse = _response as O7ErrorResponse;
            if(errorResponse != null)
            {                
                context.RequestContext.HttpContext.Response.StatusCode = errorResponse.Code;
                context.RequestContext.HttpContext.Response.StatusDescription = errorResponse.Message;
            }            
            base.ExecuteResult(context);            
        }        
    }
}