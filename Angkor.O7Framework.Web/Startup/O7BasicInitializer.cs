// Solution: O7Framework
// Owner: FBUENO
// Date: 23 - 02 - 2018

using System.Configuration;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Angkor.O7Framework.Web.Utility;

namespace Angkor.O7Framework.Web.Startup
{
    public class O7BasicInitializer : HttpApplication
    {
        private readonly RouteCollection _routeCollection;
        private readonly GlobalFilterCollection _filterCollection;

        public O7BasicInitializer()
        {
            _routeCollection = RouteTable.Routes;
            _filterCollection = GlobalFilters.Filters;
        }

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            build_route_config();
            RegisterGlobalFilters();
        }

        private void build_route_config()
        {
            _routeCollection.IgnoreRoute("{resource}.axd/{*pathInfo}");
            _routeCollection.MapRoute(
                "Default",
                "{controller}/{action}/{id}",
                make_action_default(),
                make_controller_namespaces()
            );
        }

        private object make_action_default()
        {
            return new
            {
                controller = get_appstart().Controller,
                action = get_appstart().Action,
                id = UrlParameter.Optional
            };
        }

        private string[] make_controller_namespaces()
        {
            return new[] { get_appstart().Namespace };
        }

        private O7WebAppstart get_appstart()
        {
            return (O7WebAppstart)ConfigurationManager.GetSection("O7WebAppstart");
        }


        protected virtual void RegisterGlobalFilters()
        {
            _filterCollection.Add(new HandleErrorAttribute());            
        }


        protected void RegisterFilters(params ActionFilterAttribute[] filters)
        {
            foreach (var filter in filters)            
                _filterCollection.Add(filter);            
        }

    }
}