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
using Web_Ban_Sach.Models;

namespace Web_Ban_Sach.Controllers
{
    public class BookController : Controller
    {
        private WebDbContext _context;
        private BookCategoriesService _bookCategoriesService;
        private BookService _bookeService;
        public BookController()
        {
            _context = new WebDbContext();
            _bookeService = new BookService(_context);
            _bookCategoriesService = new BookCategoriesService(_context);
        }
        // GET: Book

        public ActionResult Detail(int id)
        {
            var book = _bookeService.GetById(id);
            var bookVm = Mapper.Map<Book, BookViewModel>(book);

            return View(bookVm);
        }
        [HttpGet]
        public ActionResult Category(int id,int page = 1)
        {
            int pageSize = 12;
            int totalRow = 0;
            var books = _bookeService.GetPagingByCategoryId(page, pageSize, out totalRow, id);
            var booksVm = Mapper.Map<IEnumerable<Book>, IEnumerable<BookViewModel>>(books);
            int totalPage = (int)Math.Ceiling((double)totalRow / pageSize);
            var model = new PaginationSet<BookViewModel>()
            {
                items  = booksVm,
                Page = page,
                MaxPage = 4,
                TotalCount = totalRow,
                TotalPages = totalPage
            };
            var category = _bookCategoriesService.GetById(id);
            var categoryVm = Mapper.Map<BookCategory, BookCategoryViewModel>(category);
            
            ViewBag.Category = categoryVm;
            return View(model);
        }
        public ActionResult ListLeft()
        {
            return PartialView();
        }
    }
}