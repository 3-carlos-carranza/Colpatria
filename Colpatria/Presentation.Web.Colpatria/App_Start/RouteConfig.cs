using System.Web.Mvc;
using System.Web.Routing;

namespace Presentation.Web.Colpatria
{
    public static class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Request", action = "Index", id = UrlParameter.Optional }
            );
            routes.MapRoute(
             "FormTrackingRoute",
             "Formularios/{RequestStep}",
             new
             {
                 controller = "Request",
                 action = "HandleRequest"
             },
             new { allowedUrl = new AllowedUrlConstraint() });
        }
    }
}
