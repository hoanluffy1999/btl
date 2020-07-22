using Models;
using Models.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class BookService
    {
        private WebDbContext _context;
        public BookService(WebDbContext context)
        {
            this._context = context;
        }
        public void Save()
        {
            _context.SaveChanges();
        }
        public void Add(Book entity)
        {
            _context.Books.Add(entity);
        }
        public bool Update(Book entity)
        {
            var Book = _context.Books.FirstOrDefault(x => x.ID == entity.ID);
            if (Book != null)
            {
                _context.Books.AddOrUpdate(entity);
                return true;
            }
            else return false;
        }
        public bool Delete(int id)
        {
            var Book = _context.Books.FirstOrDefault(x => x.ID == id);
            if (Book != null)
            {
                _context.Books.Remove(Book);
                return true;
            }
            else return false;
        }

        public IEnumerable<Book> GetAll()
        {
            return _context.Books.Where(x => x.Status == true).ToList();
        }

        public Book GetById(int id)
        {
            return _context.Books.Find(id);
        }

        public IEnumerable<Book> GetPaging(int page, int pageSize, out int totalRow)
        {
            var query = _context.Books.Where(x => x.Status == true).ToList();

            totalRow = query.Count();

            return query.OrderByDescending(x => x.ID).Skip((page - 1) * pageSize).Take(pageSize);
        }
        public IEnumerable<Book> GetPagingByCategoryId(int page, int pageSize, out int totalRow,int categoryId)
        {
            var query = _context.Books.Where(x => x.Status == true && x.CategoryID ==categoryId).ToList();

            totalRow = query.Count();

            return query.OrderByDescending(x => x.ID).Skip((page - 1) * pageSize).Take(pageSize);
        }
        public IEnumerable<Book> GetPagingByTgId(int page, int pageSize, out int totalRow, int tgId)
        {
            var query = _context.Books.Where(x => x.Status == true && x.TacGiaID == tgId).ToList();

            totalRow = query.Count();

            return query.OrderByDescending(x => x.ID).Skip((page - 1) * pageSize).Take(pageSize);
        }
        public IEnumerable<Book> GetByCategoryId(int id)
        {
            return _context.Books.Where(x => x.Status == true && x.CategoryID == id).ToList();
        }
        public IEnumerable<Book> GetByNumber(int number)
        {
            return _context.Books.Where(x => x.Status).Take(number).ToList();
        }
    }
}
