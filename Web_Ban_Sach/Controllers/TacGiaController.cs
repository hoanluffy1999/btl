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
    public class TacGiaController : Controller
    {
        private WebDbContext _context;
        private TacGiaService _tacGiaService;
        private BookService _bookService;
        public TacGiaController()
        {
            _context = new WebDbContext();
            _bookService = new BookService(_context);
            _tacGiaService = new TacGiaService(_context);
        }
        // GET: TacGia
        public ActionResult Index(int page = 1)
        {
            int pageSize = 9;
            int totalRow = 0;
            var listTacGia = _tacGiaService.GetPaging(page, pageSize, out totalRow);
            var listTacGiaVm = Mapper.Map<IEnumerable<TacGia>, IEnumerable<TacGiaViewModel>>(listTacGia);
            int totalPage = (int)Math.Ceiling((double)totalRow / pageSize);
            var model = new PaginationSet<TacGiaViewModel>()
            {
                items = listTacGiaVm,
                Page = page,
                MaxPage = 5,
                TotalCount = totalRow,
                TotalPages = totalPage
            };
            return View(model);
        }
        public ActionResult Detail(int id,int page = 1)
        {
            int pageSize = 10;
            int totalRow = 0;
            var books = _bookService.GetPagingByTgId(page, pageSize, out totalRow,id);
            var booksVm = Mapper.Map<IEnumerable<Book>, IEnumerable<BookViewModel>>(books);
            int totalPage = (int)Math.Ceiling((double)totalRow / pageSize);
            var model = new PaginationSet<BookViewModel>()
            {
                items = booksVm,
                Page = page,
                MaxPage = 5,
                TotalCount = totalRow,
                TotalPages = totalPage
            };
            return View(model);
        }
    }

   
}