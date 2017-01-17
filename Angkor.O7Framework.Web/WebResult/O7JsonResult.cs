// Create by Felix A. Bueno

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
            //DEBES HACER ALGO ACA PARA QUE CUANDO CASTEE EL ERROR DISCIERNA ENTRE LOGICO Y BD
            var errorResponse = _response as O7ErrorResponse;
            if (errorResponse != null)
            {
                //NO SE CAMBIA EL ESTADO DE CODIGO, PERO SI ES ERROR DE DB AGREGAR EL MENSAJE ACA
                context.RequestContext.HttpContext.Response.StatusCode = 500;
                context.RequestContext.HttpContext.Response.StatusDescription = errorResponse.Message;
            }
            var successResponse = _response as O7SuccessResponse<string>;
            if (successResponse != null)
            {
                Data = successResponse.Value1;
            }
            else
            {
                //SI EL ERROR ES LOGICO CAMBIAR EL ERROR DE LA DESCRIPCION POR EL LOGICO
                context.RequestContext.HttpContext.Response.StatusCode = 400;
                context.RequestContext.HttpContext.Response.StatusDescription = "Bad Request";
            }
            base.ExecuteResult(context);
        }
    }
}