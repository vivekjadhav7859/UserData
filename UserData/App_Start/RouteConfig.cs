using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Microsoft.AspNet.FriendlyUrls;

namespace UserData
{
    public static class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            var settings = new FriendlyUrlSettings();
            settings.AutoRedirectMode = RedirectMode.Permanent;
            routes.EnableFriendlyUrls(settings);

            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                    name: "Default",
                    url: "{controller}/{action}/{id}",
                    defaults: new { action = "Index", id = UrlParameter.Optional }
                );
            routes.MapRoute(
                    name: "SignIn",
                    url: "User/SignIn",
                    defaults: new { controller = "User", action = "SignIn" }
                );
            routes.MapRoute(
                    name: "Login",
                    url: "User/Login",
                    defaults: new { controller = "User", action = "Login" }
                );
            routes.MapRoute(
                    name: "Home",
                    url: "Home",
                    defaults: new { controller = "Home", action = "Login" }
                );
        }
    }
}
