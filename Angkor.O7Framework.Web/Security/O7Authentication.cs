

using Angkor.O7Framework.Utility;
using Angkor.O7Framework.Web.Model;
using Angkor.O7Framework.Web.Security;
using Angkor.O7Framework.Web.Utility;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Script.Serialization;

namespace Angkor.O7Framework.Web.Security
{
    public class O7Authentication
    {

        private readonly HttpSessionStateBase _sessionBase;

        public O7Authentication(HttpSessionStateBase sessionBase)
        {
            _sessionBase = sessionBase;
        }

        public void SetMenu(List<O7Menu> menus)
        {
            var serializedMenu = O7JsonSerealizer.Serialize(menus);
            _sessionBase.Add(WebConstant.MENU_COOKIE, serializedMenu);
        }

        public void SetUser(O7User user)
        {
            var js = new JavaScriptSerializer();
            var serializedUser = js.Serialize(user);
            _sessionBase.Add(WebConstant.USER_COOKIE, serializedUser);
        }

        public void SetModule(List<O7Module> modules)
        {
            var serializedModule = O7JsonSerealizer.Serialize(modules);
            _sessionBase.Add(WebConstant.MODULE_COOKIE, serializedModule);
        }

        public List<O7Module> Modules
        {
            get
            {
                var serializedCookie = (string)_sessionBase[WebConstant.MODULE_COOKIE];
                return O7JsonSerealizer.Deserialize<List<O7Module>>(serializedCookie);
            }
        }

        public List<O7Menu> Menus
        {
            get
            {
                var serializedMenu = (string)_sessionBase[WebConstant.MENU_COOKIE];
                return O7JsonSerealizer.Deserialize<List<O7Menu>>(serializedMenu);
            }
        }

        public O7User User
        {
            get
            {
                try
                {
                    var serializedUser = (string)_sessionBase[WebConstant.USER_COOKIE];
                    var js = new JavaScriptSerializer();
                    var resp = js.Deserialize<O7User>(serializedUser);
                    return resp;
                }
                catch (System.Exception e)
                {
                    return null;
                }

            }
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