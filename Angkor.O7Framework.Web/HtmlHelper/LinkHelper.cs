// Create by Felix A. Bueno

using System;
using System.Diagnostics.Contracts;
using System.Web;
using Angkor.O7Framework.Common.Validator;
using System.Web.Mvc;

namespace Angkor.O7Framework.Web.HtmlHelper
{
    public static partial class LinkHelper
    {

        
        public static string SourceLink(string controller, string action, params Tuple<string, string>[] parameters)
        {
            Contract.Requires(ContractValidator.StringIsNotNullOrEmpty(controller, action));
            Contract.Ensures(ContractValidator.StringIsNotNullOrEmpty(Contract.Result<string>()));
            var link = SourceLink();
            var paramter = build_parameters_path(parameters);
            return $"{link}{controller}/{action}{paramter}";
        }        

        public static string SourceLink()
        {
            Contract.Ensures(ContractValidator.StringIsNotNullOrEmpty(Contract.Result<string>()));
            var source = get_source();
            return build_source(source, string.Empty);
        }

        public static IHtmlString SourceLink(this System.Web.Mvc.HtmlHelper helper, string source)
        {
            Contract.Requires(ContractValidator.StringIsNotNullOrEmpty(source));            
            return new HtmlString($"{SourceLink()}{source}");
        }

        public static IHtmlString JavaScriptLink(this System.Web.Mvc.HtmlHelper helper, string link)
        {            
            Contract.Requires(ContractValidator.StringIsNotNullOrEmpty(link));
            var source = get_source();            
            return new HtmlString($"<script src='{build_source(source, link)}'></script>");
        }
        
        public static IHtmlString StyleLink(this System.Web.Mvc.HtmlHelper helper, string link)
        {
            Contract.Requires(ContractValidator.StringIsNotNullOrEmpty(link));
            var source = get_source();
            return new HtmlString($"<link href='{build_source(source, link)}' rel='stylesheet' />");
        }

        public static IHtmlString StyleLink(this System.Web.Mvc.HtmlHelper helper, string link, string mediaType)
        {
            Contract.Requires(ContractValidator.StringIsNotNullOrEmpty(link, mediaType));
            var source = get_source();
            return new HtmlString($"<link href='{build_source(source, link)}' rel='stylesheet' media='{mediaType}' />");
        }        
        
    }
}