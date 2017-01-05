// Create by Felix A. Bueno

using System.Web.Mvc;
using Angkor.O7Framework.Web.Security;

namespace Angkor.O7Framework.Web.Base
{
    public abstract class O7ViewPage : WebViewPage
    {
        public new virtual O7Principal User
        {
            get
            {

                base.User as O7Principal;
            }
        }
    }

    public abstract class O7ViewPage<TModel> : WebViewPage<TModel>
    {
        public new virtual O7Principal User => base.User as O7Principal;
    }
}