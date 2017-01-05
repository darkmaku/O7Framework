// Create by Felix A. Bueno

using System.Diagnostics.Contracts;
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
                Contract.Requires(base.User is O7Principal);
                return (O7Principal)base.User;
            }
        }
    }

    public abstract class O7ViewPage<TModel> : WebViewPage<TModel>
    {
        public new virtual O7Principal User
        {
            get
            {
                Contract.Requires(base.User is O7Principal);
                return (O7Principal) base.User;
            }
        }
    }
}