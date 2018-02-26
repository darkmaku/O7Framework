// Create by Felix A. Bueno

using System.Web.Mvc;
using System.Diagnostics.Contracts;
using Angkor.O7Framework.Common.Model;
using Angkor.O7Framework.Utility;

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
            try
            {
                set_response_to_controller(context);
            }
            catch (System.Exception exception)
            {
                context.RequestContext.HttpContext.Response.StatusCode = 500;
                context.RequestContext.HttpContext.Response.StatusDescription = exception.Message;
            }
            base.ExecuteResult(context);
        }

        private void set_response_to_controller(ControllerContext context)
        {
            switch (_response)
            {
                case O7ErrorResponse errorResponse:
                    context.RequestContext.HttpContext.Response.StatusCode = 500;
                    context.RequestContext.HttpContext.Response.StatusDescription = errorResponse.Message;
                    break;
                case O7SuccessResponse<string> jsonResponse:
                    Data = jsonResponse.Value1;                    
                    context.RequestContext.HttpContext.Response.StatusCode = 200;
                    break;
                default:
                    var successResponse = (O7SuccessResponse<object>)_response;
                    Data = O7JsonSerealizer.Serialize(successResponse.Value1);
                    context.RequestContext.HttpContext.Response.StatusCode = 200;
                    break;
            }
        }
    }
}