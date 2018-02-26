// Solution: O7Framework
// Owner: FBUENO
// Date: 26 - 02 - 2018

using System.Collections.Generic;
using System.Web;
using Angkor.O7Framework.Utility;
using Angkor.O7Framework.Web.Model;
using Angkor.O7Framework.Web.Utility;

namespace Angkor.O7Framework.Web.Security
{
    public static class AuthenticationExtension
    {
        public static void SetMenu(this HttpSessionStateBase sessionBase, List<O7Menu> menus)
        {
            var serializedMenu = O7JsonSerealizer.Serialize(menus);
            sessionBase.Add(WebConstant.MENU_COOKIE, serializedMenu);
        }

        public static void SetUser(this HttpSessionStateBase sessionBase, O7User user)
        {
            var serializedUser = O7JsonSerealizer.Serialize(user);
            sessionBase.Add(WebConstant.USER_COOKIE, serializedUser);
        }

        public static void SetModule(this HttpSessionStateBase sessionBase, List<O7Module> modules)
        {
            var serializedModule = O7JsonSerealizer.Serialize(modules);
            sessionBase.Add(WebConstant.MODULE_COOKIE, serializedModule);
        }

        public static void RemoveAllO7Cookies(this HttpSessionStateBase sessionBase)
        {
            sessionBase.RemoveModule();
            sessionBase.RemoveUser();
            sessionBase.RemoveMenus();
        }

        public static void RemoveModule(this HttpSessionStateBase sessionBase)
        {
            sessionBase.Remove(WebConstant.MODULE_COOKIE);
        }

        public static void RemoveUser(this HttpSessionStateBase sessionBase)
        {
            sessionBase.Remove(WebConstant.USER_COOKIE);
        }

        public static void RemoveMenus(this HttpSessionStateBase sessionBase)
        {
            sessionBase.Remove(WebConstant.MENU_COOKIE);
        }
    }
}