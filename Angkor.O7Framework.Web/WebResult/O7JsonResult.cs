// Create by Felix A. Bueno

using System.Web.Mvc;
using Angkor.O7Framework.Domain.Response;
using System.Diagnostics.Contracts;

namespace Angkor.O7Framework.Web.WebResult
{
    public class O7JsonResult : JsonResult
    {
        private readonly O7Response _response;

        public O7JsonResult(O7Response value)
        {
            Contract.Requires(value != null);
            _response = value;
            JsonRequestBehavior = JsonRequestBehavior.AllowGet;
            ContentType = "application/json";
        }

        public override void ExecuteResult(ControllerContext context)
        {
            var errorResponse = _response as O7ErrorResponse;
            if (errorResponse != null)
            {
                context.RequestContext.HttpContext.Response.StatusCode = errorResponse.Code;
                context.RequestContext.HttpContext.Response.StatusDescription = errorResponse.Message;
            }
            var successResponse = _response as O7SuccessResponse<string>;
            if (successResponse != null)
            {
                Data = successResponse.Value1;
            }
            else
            {
                context.RequestContext.HttpContext.Response.StatusCode = 400;
                context.RequestContext.HttpContext.Response.StatusDescription = "Bad Request";
            }
            base.ExecuteResult(context);
        }
    }
}