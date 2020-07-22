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
    public class NhaXuatBanService
    {
        private WebDbContext _context;
        public NhaXuatBanService(WebDbContext context)
        {
            this._context = context;
        }
       
        public void Add(NhaXuatBan entity)
        {
            _context.NhaXuatBan.Add(entity);
        }
        public bool Update(NhaXuatBan entity)
        {
            var NhaXuatBan = _context.NhaXuatBan.FirstOrDefault(x => x.ID == entity.ID);
            if (NhaXuatBan != null)
            {
                _context.NhaXuatBan.AddOrUpdate(entity);
                return true;
            }
            else return false;
        }
        public bool Delete(int id)
        {
            var NhaXuatBan = _context.NhaXuatBan.FirstOrDefault(x => x.ID == id);
            if (NhaXuatBan != null)
            {
                _context.NhaXuatBan.Remove(NhaXuatBan);
                return true;
            }
            else return false;
        }

        public IEnumerable<NhaXuatBan> GetAll()
        {
            return _context.NhaXuatBan.Where(x=>x.Status==true).ToList();
        }

        public NhaXuatBan GetById(int id)
        {
            return _context.NhaXuatBan.Find(id);
        }

        public IEnumerable<NhaXuatBan> GetPaging(int page, int pageSize, out int totalRow)
        {
            var query = _context.NhaXuatBan.Where(x => x.Status == true).ToList();

            totalRow = query.Count();

            return query.OrderByDescending(x => x.ID).Skip((page - 1) * pageSize).Take(pageSize);
        }

    }
}
