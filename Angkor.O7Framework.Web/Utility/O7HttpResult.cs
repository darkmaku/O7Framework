// Create by Felix A. Bueno

using System.Web.Mvc;
using Angkor.O7Framework.Infrastructure;

namespace Angkor.O7Framework.Web.Utility
{
    public class O7HttpResult
    {
        public static O7JsonResult MakeJsonResult(O7ResponseContract<string> value) => new O7JsonResult(value);
    }

    public class O7JsonResult : JsonResult
    {
        private O7ResponseContract<string> _contract;

        public O7JsonResult(O7ResponseContract<string> value)
        {            
            _contract = value;
            if (!_contract.HasError) Data = _contract.Response.Item1;
            JsonRequestBehavior = JsonRequestBehavior.AllowGet;
        }

        public override void ExecuteResult(ControllerContext context)
        {
            if (_contract.HasError)
            {
                context.RequestContext.HttpContext.Response.StatusCode = _contract.ErrorCode;
                context.RequestContext.HttpContext.Response.StatusDescription = _contract.ErrorMessage;
            }            
            base.ExecuteResult(context);            
        }
    }
}