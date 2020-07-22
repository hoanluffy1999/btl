using Models;
using Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.Migrations;

namespace Services
{
    public class TacGiaService
    {
        private WebDbContext _context;
        public TacGiaService(WebDbContext context)
        {
            this._context = context;
        }
        public void Save()
        {
            _context.SaveChanges();
        }
        public void Add(TacGia entity)
        {
            _context.TacGia.Add(entity);
        }
        public bool Update(TacGia entity)
        {
            var tacgia = _context.TacGia.FirstOrDefault(x => x.ID == entity.ID);
            if (tacgia != null)
            {
                _context.TacGia.AddOrUpdate(entity);
                return true;
            }
            else return false;
        }
        public bool Delete(int id)
        {
            var tacGia = _context.TacGia.FirstOrDefault(x => x.ID == id);
            if (tacGia != null)
            {
                _context.TacGia.Remove(tacGia);
                return true;
            }
            else return false;
        }

        public IEnumerable<TacGia> GetAll()
        {
            return _context.TacGia.Where(x => x.Status == true).ToList();
        }

        public TacGia GetById(int id)
        {
            return _context.TacGia.Find(id);
        }

        public IEnumerable<TacGia> GetPaging( int page, int pageSize, out int totalRow)
        {
            var query = _context.TacGia.Where(x => x.Status == true).ToList();

            totalRow = query.Count();

            return query.OrderByDescending(x => x.ID).Skip((page - 1) * pageSize).Take(pageSize);
        }

    }
}