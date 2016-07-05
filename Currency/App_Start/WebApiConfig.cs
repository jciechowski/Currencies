using System.Web.Http;

namespace Currency
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "GetByCurrency",
                routeTemplate: "api/{controller}/{currency}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
