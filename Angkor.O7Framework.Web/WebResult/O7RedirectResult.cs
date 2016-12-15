// Create by Felix A. Bueno

using System;
using System.Web.Mvc;
using Angkor.O7Framework.Domain.Response;
using Angkor.O7Framework.Web.HtmlHelper;

namespace Angkor.O7Framework.Web.WebResult
{
    public class O7RedirectResult : RedirectResult
    {
        public O7RedirectResult(O7ErrorResponse response) :base(make_error_url(response))
        {
        }
        
        public O7RedirectResult(string url, bool permanent) : base(url, permanent)
        {
        }

        private static string make_error_url(O7ErrorResponse response)
        {
            return LinkHelper.SourceLink("Error", "ManagementError", Tuple.Create(response.Code.ToString(), response.Message));
        }
    }
}