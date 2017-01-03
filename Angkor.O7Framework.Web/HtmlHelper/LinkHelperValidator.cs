using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Angkor.O7Framework.Web.Utility;

namespace Angkor.O7Framework.Web.HtmlHelper
{
    public class LinkHelperValidator
    {
        public static bool ValidParameters(System.Web.Mvc.HtmlHelper helper, string link)
        {
            return helper != null && !String.IsNullOrEmpty(link);
        }

        public static bool ValidParameters(System.Web.Mvc.HtmlHelper helper, string link,string media)
        {
            return helper != null && !String.IsNullOrEmpty(link) && !String.IsNullOrEmpty(media);
        }
        public static bool ValidParameters(O7WebSource source, string link)
        {
            return source != null && !String.IsNullOrEmpty(link) && !String.IsNullOrEmpty(media);
        }
    }
}
