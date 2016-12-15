// Create by Felix A. Bueno

using System;
using System.Configuration;
using System.Text;
using System.Web;
using Angkor.O7Framework.Web.Exception;
using Angkor.O7Framework.Web.Utility;

namespace Angkor.O7Framework.Web.HtmlHelper
{
    public static class LinkHelper
    {
        public static string SourceLink(string controller, string action, params Tuple<string, string>[] parameters)
        {
            var link = SourceLink();
            var builder = new StringBuilder();
            for (var i = 0; i < parameters.Length; i++)
            {
                var parameter = parameters[i];
                builder.Append($"{parameter.Item1}={parameter.Item2}");
            }
            return $"{link}/{controller}/{action}?{builder}";
        }

        public static string SourceLink()
        {
            var source = get_source();
            var portPath = !string.IsNullOrEmpty(source.Port) ? $"{source.Port}" : string.Empty;
            return string.IsNullOrEmpty(portPath) ? $"http://{source.Address}/" : $"http://{source.Address}:{portPath}/";            
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

        private static O7WebSource get_source()
        {
            var source = ConfigurationManager.GetSection("O7WebSource") as O7WebSource;
            if (source == null) throw O7WebSourceException.MakeWebSourceException;
            return source;
        }

        private static string build_source(O7WebSource source, string link)
        {
            var portPath = !string.IsNullOrEmpty(source.Port) ? $":{source.Port}" : string.Empty;
            var sourcePath = !string.IsNullOrEmpty(source.Source) ? $"/{source.Source}/" : "/";
            return $"http://{source.Address}{portPath}{sourcePath}{link}";        
        }
    }
}