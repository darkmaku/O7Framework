using Angkor.O7Framework.Utility;
using Angkor.O7Framework.Web.Model;
using Angkor.O7Framework.Web.Utility;
using System.Collections.Generic;
using System.Web;

namespace Angkor.O7Framework.Web.Security
{
    public class O7Authentication
    {
        private readonly HttpSessionStateBase _sessionBase;

        public O7Authentication(HttpSessionStateBase sessionBase)
        {
            _sessionBase = sessionBase;
            _sessionBase.Timeout = 100000;
        }


        public List<O7Menu> Menus
        {
            get
            {
                var serializedMenu = (string)_sessionBase[WebConstant.MENU_COOKIE];
                return O7JsonSerealizer.Deserialize<List<O7Menu>>(serializedMenu);
            }
        }

        public void SetMenu(List<O7Menu> menus)
        {
            var serializedMenu = O7JsonSerealizer.Serialize(menus);
            _sessionBase.Add(WebConstant.MENU_COOKIE, serializedMenu);
        }


        public O7User User
        {
            get
            {
                var serializedUser = (string)_sessionBase[WebConstant.USER_COOKIE];
                return O7JsonSerealizer.Deserialize<O7User>(serializedUser);
            }
        }

        public void SetUser(O7User user)
        {
            var serializedUser = O7JsonSerealizer.Serialize(user);
            _sessionBase.Add(WebConstant.USER_COOKIE, serializedUser);
        }


        public List<O7Module> Modules
        {
            get
            {
                var serializedCookie = (string)_sessionBase[WebConstant.MODULE_COOKIE];
                return O7JsonSerealizer.Deserialize<List<O7Module>>(serializedCookie);
            }
        }

        public void SetModule(List<O7Module> modules)
        {
            var serializedModule = O7JsonSerealizer.Serialize(modules);
            _sessionBase.Add(WebConstant.MODULE_COOKIE, serializedModule);
        }


        public void RemoveAll()
        {
            RemoveModule();
            RemoveUser();
            RemoveMenus();
        }

        public void RemoveModule()
        {
            _sessionBase.Remove(WebConstant.MODULE_COOKIE);
        }

        public void RemoveUser()
        {
            _sessionBase.Remove(WebConstant.USER_COOKIE);
        }

        public void RemoveMenus()
        {
            _sessionBase.Remove(WebConstant.MENU_COOKIE);
        }
    }
}