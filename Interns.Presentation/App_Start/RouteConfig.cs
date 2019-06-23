using System.Web.Mvc;
using System.Web.Routing;

namespace Interns.Presentation
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapMvcAttributeRoutes();
            
            routes.MapRoute(
                "Page",
                "{controller}/{action}/Page{page}"
            );
            routes.MapRoute(
                "SortOrder",
                "{controller}/{action}/Page{page}/{sortOrder}"
            );
            
            routes.MapRoute(
                "Default",
                "{controller}/{action}/{id}",
                new { controller = "Advertise", action = "Advertises", id = UrlParameter.Optional }
            );
        }
    }
}
