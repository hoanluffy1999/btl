using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Web_Ban_Sach
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
               name: "Danh Nhap",
               url: "dang-nhap",
               defaults: new { Controller = "Account", action = "Login", id = UrlParameter.Optional },
               namespaces: new string[] { "Web_Ban_Sach.Controllers" }
            );
            routes.MapRoute(
               name: "Gio Hang",
               url: "gio-hang",
               defaults: new { Controller = "ShoppingCart", action = "Index", id = UrlParameter.Optional },
               namespaces: new string[] { "Web_Ban_Sach.Controllers" }
            );
            routes.MapRoute(
               name: "Danh sach tac gia",
               url: "danh-sach-tac-gia",
               defaults: new { Controller = "TacGia", action = "index", id = UrlParameter.Optional },
               namespaces: new string[] { "Web_Ban_Sach.Controllers" }
            );
            routes.MapRoute(
             name: "Book Category",
             url: "danh-muc-sach-{id}",
             defaults: new { controller = "Book", action = "Category", id = UrlParameter.Optional },
               namespaces: new string[] { "Web_Ban_Sach.Controllers" }
         );
            routes.MapRoute(
             name: "Book ",
             url: "chi-tiet-sach-{id}",
             defaults: new { controller = "Book", action = "Detail", id = UrlParameter.Optional },
               namespaces: new string[] { "Web_Ban_Sach.Controllers" }
         );
            routes.MapRoute(
             name: "Tac gia ",
             url: "thong-tin-tac-gia-{id}",
             defaults: new { controller = "TacGia", action = "Detail", id = UrlParameter.Optional },
               namespaces: new string[] { "Web_Ban_Sach.Controllers" }
         );
            
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                namespaces: new string[] { "Web_Ban_Sach.Controllers" }
            );
        }
    }
}
