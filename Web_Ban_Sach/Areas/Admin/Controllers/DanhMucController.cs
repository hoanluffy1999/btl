using AutoMapper;
using Common;
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
    [Authorize]
    public class DanhMucController : Controller
    {
        private WebDbContext _context;
        private BookCategoriesService _bookCategoryService;
        public DanhMucController()
        {
            _context = new WebDbContext();
            _bookCategoryService = new BookCategoriesService(_context);
        }
        // GET: Admin/DanhMuc
        public ActionResult Index(int page = 1)
        {
            int pageSize = CommonConstants.PageSize;
            int totalRow = 0;
            var listBookCategory = _bookCategoryService.GetPaging(page, pageSize, out totalRow);
            var listBookCategoryVm = Mapper.Map<IEnumerable<BookCategory>, IEnumerable<BookCategoryViewModel>>(listBookCategory);
            int totalPage = (int)Math.Ceiling((double)totalRow / pageSize);
            var model = new PaginationSet<BookCategoryViewModel>()
            {
                Page = page,
                MaxPage = CommonConstants.MaxPage,
                TotalCount = totalRow,
                TotalPages = totalPage,
                items = listBookCategoryVm
            };
            return View(model);
        }

        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Add(BookCategoryViewModel model)
        {
            if (ModelState.IsValid)
            {
                var bookCategory = new BookCategory();
                bookCategory.UpdateBookCategory(model);
                _bookCategoryService.Add(bookCategory);
                _context.SaveChanges();
                ViewData["successMsg"] = "Thêm thành công";
            }
            return View();
        }
        [HttpGet]
        public ActionResult Update(int id)
        {
            var bookCategory = _bookCategoryService.GetById(id);
            var bookCategoryVm = Mapper.Map<BookCategory, BookCategoryViewModel>(bookCategory);
            return View(bookCategoryVm);
        }

        [HttpPost]
        public ActionResult Update(BookCategoryViewModel model)
        {
            if (ModelState.IsValid)
            {
                var bookCategory = new BookCategory();
                bookCategory.UpdateBookCategory(model);
                _bookCategoryService.Update(bookCategory);
                _context.SaveChanges();
                ViewData["successMsg"] = "Sua thành công";
            }
            return View(model);
        }
        [HttpDelete]
        public JsonResult Delete(int id)
        {
            bool result = _bookCategoryService.Delete(id);
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