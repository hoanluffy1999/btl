using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web_Ban_Sach.Models
{
    public class BookViewModel
    {
        public int ID { get; set; }

        public string Name { get; set; }
        public string Image { get; set; }

        public string MoreImages { get; set; }

        public string Description { get; set; }
        public string Content { get; set; }

        public int CategoryID { get; set; }

        public int NxbID { get; set; }

        public int TacGiaID { get; set; }

        public decimal? Price { get; set; }

        public decimal? PromotionPrice { get; set; }

        public int? PageNumber { get; set; }

        public virtual BookCategoryViewModel BookCategory { get; set; }

        public virtual NhaXuatBanViewModel NhaXuatBan { get; set; }
        
        public virtual TacGiaViewModel TacGia { get; set; }
        public DateTime? CreateDate { get; set; }

        public string CreateBy { get; set; }

        public DateTime? UpdateDate { get; set; }

        public string UpdateBy { get; set; }

        public bool Status { get; set; }
    }
}