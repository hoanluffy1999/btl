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
    [Authorize(Roles = "Admin")]
    public class SachController : Controller
    {
        private WebDbContext _context;
        private BookService _bookService;
        private BookCategoriesService _bookCategoriesService;
        private TacGiaService _tacGiaService;
        private NhaXuatBanService _nhaXuatBanService;
        public SachController()
        {
            _context = new WebDbContext();
            _bookService = new BookService(_context);
            _nhaXuatBanService = new NhaXuatBanService(_context);
            _tacGiaService = new TacGiaService(_context);
            _bookCategoriesService = new BookCategoriesService(_context);
        }
        // GET: Admin/DanhMuc
        public ActionResult Index(int page = 1)
        {
            int pageSize = CommonConstants.PageSize;
            int totalRow = 0;
            var listBook = _bookService.GetPaging(page, pageSize, out totalRow);
            var listBookVm = Mapper.Map<IEnumerable<Book>, IEnumerable<BookViewModel>>(listBook);
            int totalPage = (int)Math.Ceiling((double)totalRow / pageSize);
            var model = new PaginationSet<BookViewModel>()
            {
                Page = page,
                MaxPage = CommonConstants.MaxPage,
                TotalCount = totalRow,
                TotalPages = totalPage,
                items = listBookVm
            };
            return View(model);
        }

        [HttpGet]
        public ActionResult Add()
        {
            SetViewBag();
            return View();
        }
        [HttpPost]
        public ActionResult Add(BookViewModel model)
        {
            if (ModelState.IsValid)
            {
                SetViewBag();
                var book = new Book();
                book.UpdateBook(model);
                _bookService.Add(book);
                _context.SaveChanges();
                ViewData["successMsg"] = "Thêm thành công";
            }
            return View();
        }
        [HttpGet]
        public ActionResult Update(int id)
        {
            var book = _bookService.GetById(id);
            var bookVm = Mapper.Map<Book, BookViewModel>(book);
            return View(bookVm);
        }

        [HttpPost]
        public ActionResult Update(BookViewModel model)
        {
            if (ModelState.IsValid)
            {
                var book = new Book();
                book.UpdateBook(model);
                _bookService.Update(book);
                _context.SaveChanges();
                ViewData["successMsg"] = "Sua thành công";
            }
            return View(model);
        }
        public void SetViewBag(int? categoryId = null, int? tacGiaId = null, int? nxbId = null)
        {

            ViewBag.CategoryID = new SelectList(_bookCategoriesService.GetAll(), "ID", "Name", categoryId);
            ViewBag.TacGiaID = new SelectList(_tacGiaService.GetAll(), "ID", "Name",tacGiaId);
            ViewBag.NxbID = new SelectList(_nhaXuatBanService.GetAll(), "ID", "Name", nxbId);
        }
        [HttpDelete]
        public JsonResult Delete(int id)
        {
            bool result = _bookService.Delete(id);
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