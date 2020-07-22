using Models;
using Models.Models;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web_Ban_Sach.Models;
using Web_Ban_Sach.Infrastructure.Extension;
using Common;
using AutoMapper;
using Web_Ban_Sach.Infrastructure.Core;

namespace Web_Ban_Sach.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    public class NhaXuatBanController : Controller
    {
        WebDbContext context;
        NhaXuatBanService _nhaXuatBanService;
        public NhaXuatBanController()
        {
            this.context = new WebDbContext();
            this._nhaXuatBanService = new NhaXuatBanService(context);
        }
        // GET: Admin/NhaXuatBan
        public ActionResult Index(int page = 1)
        {
            int pageSize = CommonConstants.PageSize;
            int totalRow = 0;
            var listNxb = _nhaXuatBanService.GetPaging(page, pageSize, out totalRow);
            var listNxbVm = Mapper.Map<IEnumerable<NhaXuatBan>, IEnumerable<NhaXuatBanViewModel>>(listNxb);
            var totalPages = (int)Math.Ceiling((double)totalRow / pageSize);
            var model = new PaginationSet<NhaXuatBanViewModel>()
            {
                Page = page,
                MaxPage = CommonConstants.MaxPage,
                TotalCount = totalRow,
                TotalPages = totalPages,
                items = listNxbVm

            };
            return View(model);
        }
        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Add(NhaXuatBanViewModel model)
        {
            if (ModelState.IsValid)
            {
                model.CreateDate = DateTime.Now;
                var nxb = new NhaXuatBan();
                nxb.UpdateNhaXuatBan(model);
                _nhaXuatBanService.Add(nxb);
                context.SaveChanges();
                ViewData["successMsg"] = "Thêm thành công";
            }
            return View();
        }
        [HttpGet]
        public ActionResult Update(int id)
        {
            var nxb = _nhaXuatBanService.GetById(id);
            var nxbVm = Mapper.Map<NhaXuatBan, NhaXuatBanViewModel>(nxb);
            return View(nxbVm);
        }
        [HttpPost]
        public ActionResult Update(NhaXuatBanViewModel model)
        {
            if (ModelState.IsValid)
            {
                var nxb = new NhaXuatBan();
                nxb.UpdateNhaXuatBan(model);
                _nhaXuatBanService.Update(nxb);
                context.SaveChanges();
                ViewData["successMsg"] = "Sua thành công";
            }
            return View(model);
        }

        [HttpDelete]
        public JsonResult Delete(int id)
        {
            bool result = _nhaXuatBanService.Delete(id);
            context.SaveChanges();
            if (result)
            {
                return Json(new
                {
                    data = true
                });
            }
            else
                return Json(new
                {
                    data = false
                });
        }
    }
}
