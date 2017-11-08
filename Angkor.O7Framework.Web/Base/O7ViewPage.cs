
using System.Collections.Generic;
using System.Web.Mvc;
using Angkor.O7Framework.Web.Model;
using Angkor.O7Framework.Web.Security;

namespace Angkor.O7Framework.Web.Base
{
    public abstract class O7ViewPage : WebViewPage
    {
        public virtual List<O7Menu> Menus => new O7Authentication(Session).Menus;

        public virtual List<O7Module> Modules => new O7Authentication(Session).Modules;

        public new virtual O7Principal User
        {
            get
            {
                var user = new O7Authentication(Session).User;
                return new O7Principal(user.Login, user.Company, user.Branch, user.Name, user.Password,user.UserApplication,user.Atrributes);
            }
        }
    }

    public abstract class O7ViewPage<TModel> : WebViewPage<TModel>
    {
        public virtual List<O7Module> Modules => new O7Authentication(Session).Modules;

        public virtual List<O7Menu> Menus => new O7Authentication(Session).Menus;

        public new virtual O7Principal User
        {
            get
            {
                var user = new O7Authentication(Session).User;
                return new O7Principal(user.Login, user.Company, user.Branch, user.Name, user.Password,user.UserApplication,user.Atrributes);
            }
        }
    }
}