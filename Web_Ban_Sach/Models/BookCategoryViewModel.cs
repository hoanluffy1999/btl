
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web_Ban_Sach.Models
{
    public class BookCategoryViewModel
    {
        public int ID { get; set; }

        public string Name { get; set; }
        
        public string Image { get; set; }

        public string Description { get; set; }

        public bool HomeFlag { get; set; }

        public DateTime? CreateDate { get; set; }

        public string CreateBy { get; set; }

        public DateTime? UpdateDate { get; set; }

        public string UpdateBy { get; set; }

        public bool Status { get; set; }

        public virtual IEnumerable<BookViewModel> Books { get; set; }
    }
}