// Create by Felix A. Bueno

using System;
using System.Configuration;
using System.Diagnostics.Contracts;
using System.Text;
using System.Web;
using System.Web.Mvc;
using Angkor.O7Framework.Web.Exception;
using Angkor.O7Framework.Web.Utility;

namespace Angkor.O7Framework.Web.HtmlHelper
{
    public static class LinkHelper
    {
        public static string SourceLink(string controller, string action, params Tuple<string, string>[] parameters)
        {
            Contract.Requires(!string.IsNullOrEmpty(controller) && !string.IsNullOrEmpty(action) );

            var link = SourceLink();
            var paramter = build_parameters_path(parameters);
            return $"{link}{controller}/{action}{paramter}";
        }        

        public static string SourceLink()
        {
            var source = get_source();
            return build_source(source, string.Empty);
        }

        public static IHtmlString SourceLink(this System.Web.Mvc.HtmlHelper helper, string source)
        {
            return new HtmlString($"{SourceLink()}{source}");
        }

        public static IHtmlString JavaScriptLink(this System.Web.Mvc.HtmlHelper helper, string link)
        {            
            var source = get_source();            
            return new HtmlString($"<script src='{build_source(source, link)}'></script>");
        }
        
        public static IHtmlString StyleLink(this System.Web.Mvc.HtmlHelper helper, string link)
        {
            var source = get_source();
            return new HtmlString($"<link href='{build_source(source, link)}' rel='stylesheet' />");
        }

        public static IHtmlString StyleLink(this System.Web.Mvc.HtmlHelper helper, string link, string mediaType)
        {
            var source = get_source();
            return new HtmlString($"<link href='{build_source(source, link)}' rel='stylesheet' media='{mediaType}' />");
        }

        private static O7WebSource get_source()
        {
            Contract.Ensures(Contract.Result<O7WebSource>() != null);

            var source = ConfigurationManager.GetSection("O7WebSource") as O7WebSource;
            return source;
        }

        private static string build_source(O7WebSource source, string link)
        {
            var portPath = !string.IsNullOrEmpty(source.Port) ? $":{source.Port}" : string.Empty;
            var sourcePath = !string.IsNullOrEmpty(source.Source) ? $"/{source.Source}/" : "/";
            return $"http://{source.Address}{portPath}{sourcePath}{link}";        
        }

        private static string build_parameters_path(params Tuple<string, string>[] parameters)
        {
            if (parameters.Length == 0) return string.Empty;
            var builder = new StringBuilder("?");
            for (var i = 0; i < parameters.Length; i++)
            {
                var parameter = parameters[i];
                builder.Append($"{parameter.Item1}={parameter.Item2}");
            }
            return builder.ToString();
        }
    }
}