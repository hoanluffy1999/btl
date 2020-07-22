using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Abstract
{
    public class Auditable :IAuditable
    {
        public DateTime? CreateDate { get; set; }
        [MaxLength(256)]
        public string CreateBy { get; set; }

        public DateTime? UpdateDate { get; set; }
        [MaxLength(256)]
        public string UpdateBy { get; set; }
        [Required]
        public bool Status { get; set; }
    }
}
