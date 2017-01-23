// Create by Felix A. Bueno
using System;
using System.Web.Mvc;
using System.Diagnostics.Contracts;
using Angkor.O7Framework.Common.Model;

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
                context.RequestContext.HttpContext.Response.StatusCode = 500;
                context.RequestContext.HttpContext.Response.StatusDescription = errorResponse.Message;
            }
            else
            {
                var successResponse = (O7SuccessResponse<string>)_response;
                Data = successResponse.Value1;
            }
            base.ExecuteResult(context);
        }
    }
}