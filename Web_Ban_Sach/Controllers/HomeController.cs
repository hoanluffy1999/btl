using AutoMapper;
using Models;
using Models.Models;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web_Ban_Sach.Models;

namespace Web_Ban_Sach.Controllers
{
    public class HomeController : Controller
    {
        private WebDbContext _context;
        private BookCategoriesService _bookCategoriesService;
        private BookService _bookService;
        public HomeController()
        {
            _context = new WebDbContext();
            _bookCategoriesService = new BookCategoriesService(_context);
            _bookService = new BookService(_context);
        }
        // GET: Home
        public ActionResult Index()
        {
            var bookCategories = _bookCategoriesService.GetNumber(4);
            var bookCategoriesVm = Mapper.Map<IEnumerable<BookCategory>, IEnumerable<BookCategoryViewModel>>(bookCategories);
            foreach(var item in bookCategoriesVm)
            {
                var books = _bookService.GetByCategoryId(item.ID);
                var booksVm = Mapper.Map<IEnumerable<Book>, IEnumerable<BookViewModel>>(books);
                item.Books = booksVm;
            }
            return View(bookCategoriesVm);
        }
        [ChildActionOnly]
        [OutputCache(Duration =60,Location =System.Web.UI.OutputCacheLocation.Client)]
        public ActionResult Header()
        {
            var bookCategories = _bookCategoriesService.GetAll();
            var bookCategoriesVm = Mapper.Map<IEnumerable<BookCategory>, IEnumerable<BookCategoryViewModel>>(bookCategories);
            return PartialView(bookCategoriesVm);
        }
        [ChildActionOnly]
        public ActionResult NewBook()
        {
            var books = _bookService.GetByNumber(7);
            var booksVm = Mapper.Map<IEnumerable<Book>, IEnumerable<BookViewModel>>(books);
            return PartialView(booksVm);
        }
    }
}