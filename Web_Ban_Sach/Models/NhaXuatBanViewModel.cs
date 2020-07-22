using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web_Ban_Sach.Models
{
    public class NhaXuatBanViewModel
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public DateTime? CreateDate { get; set; }

        public string CreateBy { get; set; }

        public DateTime? UpdateDate { get; set; }

        public string UpdateBy { get; set; }

        public bool Status { get; set; }
    }
}