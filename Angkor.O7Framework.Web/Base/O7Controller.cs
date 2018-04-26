// Create by Felix A. Bueno
using System.Diagnostics.Contracts;
using System.Web.Mvc;
using Angkor.O7Framework.Web.Model;
using Angkor.O7Framework.Web.Security;
using Angkor.O7Framework.Web.HtmlHelper;
using System.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using Angkor.O7Framework.Common.Model;
using Angkor.O7Framework.Components;
using Angkor.O7Framework.Utility;

namespace Angkor.O7Framework.Web.Base
{
    public class O7Controller : Controller
    {
        private O7Logger _logger;
        protected new virtual O7Principal User
        {
            get
            {
                Contract.Requires(HttpContext.User is O7Principal);
                var user = new O7Authentication(Session).User;
                return new O7Principal(user.Login, user.Company, user.Branch, user.Name, user.Password,user.UserApplication,user.Attributes);                
            }
        }

        public void WriteLog(string errorMessage)
        {
            MakeLogger();
            Logger.AppendError(errorMessage);
        }
        protected void MakeLogger()
            => _logger = new O7Logger(User.UserApplication, GetType());

        protected O7Logger Logger
            => _logger;

        protected override void OnException(ExceptionContext filterContext)
        {
            filterContext.ExceptionHandled = true;
            var reloadUrl = filterContext.RequestContext.HttpContext.Request.Url.AbsoluteUri;
            string detail = "O7StackTraceBegin"+ filterContext.Exception.StackTrace.Substring(0,200) + "O7StackTraceEnd";
            filterContext.Result = ReturnToServerError(filterContext.Exception.Message,reloadUrl);           
        }

        public ActionResult ReturnToServerError(string message,string reloadUrl)
        {
            return Redirect(LinkHelper.SourceLink("Error", "ServerError") + "?message=" + HttpUtility.UrlEncode(message) + "?reloadUrl=" + HttpUtility.UrlEncode(reloadUrl));
        }
        
        public ActionResult ReturnToAuthorizationError(string message, string reloadUrl)
        {
            return Redirect(LinkHelper.SourceLink("Error", "AuthorizationError") + "?message=" + HttpUtility.UrlEncode(message) + "?reloadUrl=" + HttpUtility.UrlEncode(reloadUrl));
        }

        public ActionResult ReturnToUnfoundError(string message)
        {
            return Redirect(LinkHelper.SourceLink("Error", "UnfoundError") + "?message=" + HttpUtility.UrlEncode(message));
        }

        public JsonResult GetResult<T>(List<string> parameters, DataTableAjaxPostModel model, Func<string[], O7Response> method)
        {
            int filteredResultsCount;
            int totalResultsCount;
            var dt= new O7DatatablesManager();
            var res = dt.SearchValues<T>(method, parameters, model, out filteredResultsCount, out totalResultsCount);
            var result = res.ToList();
            return Json(new
            {
                // this is what datatables wants sending back
                draw = model.draw,
                recordsTotal = totalResultsCount,
                recordsFiltered = filteredResultsCount,
                data = result
            });
        }

       
    }
}