using System.Web.Mvc;

namespace Web_Ban_Sach.Areas.Admin
{
    public class AdminAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "Admin";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
               name: "Sach",
               url: "sach",
               defaults: new { Controller = "Sach", action = "Index", id = UrlParameter.Optional },
               namespaces: new string[] { "Web_Ban_Sach.Areas.Admin.Controllers" }
            );
            context.MapRoute(
               name: "TacGia",
               url: "tac-gia",
               defaults: new { Controller = "TacGia", action = "Index", id = UrlParameter.Optional },
               namespaces: new string[] { "Web_Ban_Sach.Areas.Admin.Controllers" }
            );
            context.MapRoute(
               name: "ThemTacGia",
               url: "them-tac-gia",
               defaults: new { Controller = "TacGia", action = "Add", id = UrlParameter.Optional },
               namespaces: new string[] { "Web_Ban_Sach.Areas.Admin.Controllers" }
            );
            context.MapRoute(
               name: "DanhMuc",
               url: "danh-muc",
               defaults: new { Controller = "DanhMuc", action = "Index", id = UrlParameter.Optional },
               namespaces: new string[] { "Web_Ban_Sach.Areas.Admin.Controllers" }
            );
            context.MapRoute(
               name: "NhaXuatBan",
               url: "nha-xuat-ban",
               defaults: new { Controller = "NhaXuatBan", action = "Index", id = UrlParameter.Optional },
               namespaces: new string[] { "Web_Ban_Sach.Areas.Admin.Controllers" }
            );
            context.MapRoute(
               name: "Admin",
               url: "Admin",
               defaults: new { Controller = "Home", action = "Index", id = UrlParameter.Optional },
               namespaces: new string[] { "Web_Ban_Sach.Areas.Admin.Controllers" }
            );
            context.MapRoute(
                "Admin_default",
                "Admin/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional },
                new string[] { "Web_Ban_Sach.Areas.Admin.Controllers" }

            );
        }
    }
}