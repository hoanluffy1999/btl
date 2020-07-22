using AutoMapper;
using Common;
using Models;
using Models.Models;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using Web_Ban_Sach.Models;

namespace Web_Ban_Sach.Controllers
{
    public class ShoppingCartController : Controller
    {
        private WebDbContext _context;
        private BookService _bookService;
        public ShoppingCartController()
        {
            _context = new WebDbContext();
            _bookService = new BookService(_context);
        }
        public ActionResult Index()
        {
            if (Session[CommonConstants.SessionCart] == null)
            {
                Session[CommonConstants.SessionCart] = new List<ShoppingCartViewModel>();
            }

            return View();
        }

        [HttpGet]
        public JsonResult GetAll()
        {
            if (Session[CommonConstants.SessionCart] == null)
            {
                Session[CommonConstants.SessionCart] = new List<ShoppingCartViewModel>();
            }
            var cart = (List<ShoppingCartViewModel>)Session[CommonConstants.SessionCart];
            return Json(new
            {
                data = cart,
                status = true
            }, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult Add(int bookId)
        {
            if (Session[CommonConstants.SessionCart] == null)
            {
                Session[CommonConstants.SessionCart] = new List<ShoppingCartViewModel>();
            }
            var cart = (List<ShoppingCartViewModel>)Session[CommonConstants.SessionCart];
            if(cart.Any(x=>x.BookId == bookId))
            {
                foreach(var item in cart)
                {
                    if (item.BookId == bookId)
                        item.Quantity += 1;
                }
            }
            else
            {
                var book = _bookService.GetById(bookId);
                var bookVm = Mapper.Map<Book, BookViewModel>(book);
                var cartItem = new ShoppingCartViewModel()
                {
                    BookId = bookId,
                    Book = bookVm,
                    Quantity = 1

                };
                cart.Add(cartItem);
                
            }
            Session[CommonConstants.SessionCart] = cart;
            return Json(new {
                status = true
            });
        }

        [HttpPost]
        public JsonResult DeleteItem(int bookId)
        {
            var cart = (List<ShoppingCartViewModel>)Session[CommonConstants.SessionCart];
            if(cart != null)
            {
                var item = cart.SingleOrDefault(x => x.BookId == bookId);
                cart.Remove(item);
            }
            return Json(new
            {
                status = true
            });
        }
        [HttpPost]
        public JsonResult UpdateItem(string cartData)
        {
            var cartViewModel = new JavaScriptSerializer().Deserialize<List<ShoppingCartViewModel>>(cartData);
            var cart = (List<ShoppingCartViewModel>)Session[CommonConstants.SessionCart];
            foreach(var item in cart)
            {
                foreach(var jitem in cartViewModel)
                {
                    if(item.BookId == jitem.BookId)
                    {
                        item.Quantity = jitem.Quantity;
                    }
                }
            }
            Session[CommonConstants.SessionCart] = cart;
            return Json(new
            {
                status = true
            });
        }
    }
}