using AutoMapper;
using Models;
using Models.Models;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web_Ban_Sach.Infrastructure.Core;
using Web_Ban_Sach.Infrastructure.Extension;
using Web_Ban_Sach.Models;

namespace Web_Ban_Sach.Areas.Admin.Controllers
{
    [Authorize(Roles ="Admin")]
    public class TacGiaController : Controller
    {
        private WebDbContext _context;
        private TacGiaService _tacGiaService;
        public TacGiaController()
        {
            _context = new WebDbContext();
            _tacGiaService = new TacGiaService(_context);
        }
        public ActionResult Index(int page = 1)
        {
            int pageSize = Common.CommonConstants.PageSize;
            int totalRow = 0;

            var tacGia = _tacGiaService.GetPaging(page,pageSize,out totalRow);
            var tacGiaVm = Mapper.Map<IEnumerable<TacGia>, IEnumerable<TacGiaViewModel>>(tacGia);
            var totalPages = (int)Math.Ceiling((double)totalRow / pageSize);
            var model = new PaginationSet<TacGiaViewModel>()
            {
                Page = page,
                MaxPage = Common.CommonConstants.MaxPage,
                TotalCount = totalRow,
                TotalPages = totalPages,
                items = tacGiaVm

            };

            return View(model);
        }
        [HttpGet]
        public ActionResult Add()
        {
           
            return View();
        }
        [HttpPost]
        public ActionResult Add(TacGiaViewModel model)
        {
            if (ModelState.IsValid)
            {
                model.CreateDate = DateTime.Now;
                TacGia tacGia = new TacGia();
                tacGia.UpdateTacGia(model);
                _tacGiaService.Add(tacGia);
                _context.SaveChanges();
                ViewData["successMsg"] = "Thêm thành công";
            }
            return View();
        }

        [HttpGet]
        public ActionResult Update(int id)
        {
            var model = _tacGiaService.GetById(id);
            var modelVm = Mapper.Map<TacGia, TacGiaViewModel>(model);

            return View(modelVm);
        }
        [HttpPost]
        public ActionResult Update(TacGiaViewModel model)
        {
            if (ModelState.IsValid)
            {
                model.UpdateDate = DateTime.Now;
                TacGia tacGia = new TacGia();
                tacGia.UpdateTacGia(model);
                _tacGiaService.Update(tacGia);
                _context.SaveChanges();
                ViewData["successMsg"] = "Sửa thành công";
            }

            return View(model);
        }
        [HttpDelete]
        public JsonResult Delete(int id)
        {
           bool result = _tacGiaService.Delete(id);
            _context.SaveChanges();
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