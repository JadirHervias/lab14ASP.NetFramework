using System.Web.Mvc;
using System.Web.Routing;

namespace MVCAjax
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Index",
                url: "{controller}/{action}",
                defaults: new { controller = "Student", action = "Index" }
            );

            routes.MapRoute(
                name: "IndexRazor",
                url: "{controller}/{action}",
                defaults: new { controller = "Student", action = "IndexRazor" }
            );

            routes.MapRoute(
                name: "getStudent",
                url: "{controller}/{action}",
                defaults: new { controller = "Student", action = "getStudent" }
            );

            routes.MapRoute(
                name: "searchStudents",
                url: "{controller}/{action}/{nameLastName}",
                defaults: new { controller = "Student", action = "searchStudents", nameLastName = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "studentDetail",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Student", action = "getStudent", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "createStudent",
                url: "{controller}/{action}",
                defaults: new { controller = "Student", action = "createStudent" }
            );
        }
    }
}
