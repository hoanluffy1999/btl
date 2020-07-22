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
    public class BookCategoriesService
    {
        private WebDbContext _context;
        public BookCategoriesService(WebDbContext context)
        {
            this._context = context;
        }
        public void Add(BookCategory entity)
        {
            _context.BookCategories.Add(entity);
        }
        public bool Update(BookCategory entity)
        {
            var BookCategory = _context.BookCategories.FirstOrDefault(x => x.ID == entity.ID);
            if (BookCategory != null)
            {
                _context.BookCategories.AddOrUpdate(entity);
                return true;
            }
            else return false;
        }
        public bool Delete(int id)
        {
            var BookCategory = _context.BookCategories.FirstOrDefault(x => x.ID == id);
            if (BookCategory != null)
            {
                _context.BookCategories.Remove(BookCategory);
                return true;
            }
            else return false;
        }

        public IEnumerable<BookCategory> GetAll()
        {
            return _context.BookCategories.Where(x => x.Status == true).ToList();
        }

        public BookCategory GetById(int id)
        {
            return _context.BookCategories.Find(id);
        }
        public void Save()
        {
            _context.SaveChanges();
        }

        public IEnumerable<BookCategory> GetPaging(int page, int pageSize, out int totalRow)
        {
            var query = _context.BookCategories.Where(x => x.Status == true).ToList();

            totalRow = query.Count();

            return query.OrderByDescending(x => x.ID).Skip((page - 1) * pageSize).Take(pageSize);
        }
        public IEnumerable<BookCategory> GetNumber(int number)
        {
            return _context.BookCategories.Where(x => x.Status).OrderByDescending(x => x.ID).Take(number).ToList();
        }
    }
}
