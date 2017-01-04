using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Angkor.O7Framework.Web.Utility;
using Angkor.O7Framework.Common.Validator;
namespace Angkor.O7Framework.Tools
{
    public class LinkValidator
    {
        public static bool ValidParameters(System.Web.Mvc.HtmlHelper helper, params string[] strings)
        {
            return helper != null && StringsValidator.AllNotNull(strings);
        }
        public static bool ValidParametersSource(O7WebSource source, params string[] strings)
        {
            return source != null && StringsValidator.AllNotNull(strings);
        }
    }
}
