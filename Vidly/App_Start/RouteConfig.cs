using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Vidly
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            //// Below is old way of adding custom route
            //routes.MapRoute(
            //    "MoviesByReleaseDate",
            //    "movies/released/{year}/{month}",
            //    new { controller = "Movies", action = "ByReleaseDate" },
            //    new
            //    { // This is added to put constraints on parameters 'year' & 'month' with the help of regular expression
            //        year = @"\d{4}" // @ is added because regular expression contains '\' which is an escape character. \d --> means digit {4} means digit should be repeated four times
            //        , month = @"\d{2}" // \d means digit, {2} means digit should be repeated twice
            //    } 
            //    );

            // This is method call enables new way of routing called as attribute routes. 
            //In attribute routes url , parameters & parameter constraints are added as attribute of Action method inside controller.
            routes.MapMvcAttributeRoutes();

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
