// Create by Felix A. Bueno

using System;
using System.Configuration;
using System.Text;
using Angkor.O7Framework.Web.Utility;

namespace Angkor.O7Framework.Web.HtmlHelper
{
    public partial class LinkHelper
    {
        private static O7WebSource get_source()
        {            
            var source = (O7WebSource)ConfigurationManager.GetSection("O7WebSource");
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