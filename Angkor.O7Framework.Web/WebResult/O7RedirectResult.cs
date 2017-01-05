﻿// Create by Felix A. Bueno

using System;
using System.Diagnostics.Contracts;
using System.Web.Mvc;
using Angkor.O7Framework.Common.Validator;
using Angkor.O7Framework.Domain.Response;
using Angkor.O7Framework.Web.HtmlHelper;

namespace Angkor.O7Framework.Web.WebResult
{
    public class O7RedirectResult : RedirectResult
    {
        public O7RedirectResult(O7ErrorResponse response) : base(make_error_url(response))
        {
            Contract.Requires(response != null);
        }

        public O7RedirectResult(string module) : base(make_module_url(module))
        {
            Contract.Requires(ContractValidator.StringIsNotNullOrEmpty(module));
        }

        public O7RedirectResult(int code, string message) : base(make_error_url(code.ToString(), message))
        {
            Contract.Requires(code > 0 && ContractValidator.StringIsNotNullOrEmpty(message));
        }

        public O7RedirectResult(string url, bool permanent) : base(url, permanent)
        {            
        }

        private static string make_error_url(O7ErrorResponse response)
            => make_error_url(response.Code.ToString(), response.Message);

        private static string make_error_url(string code, string message)
            => LinkHelper.SourceLink("Error", "ManagementError", Tuple.Create(code, message));

        private static string make_module_url(string module)
            => $"{LinkHelper.SourceLink()}{module}";
    }
}