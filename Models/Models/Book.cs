using Models.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Models
{
    [Table("Books")]
   public class Book:Auditable
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        [Required]
        [MaxLength(256)]
        public string Name { get; set; }
        public string Image { get; set; }
        [Column(TypeName = "xml")]
        public string MoreImages { get; set; }

        public string Description { get; set; }
        public string Content { get; set; }

        public int CategoryID { get; set; }

        public int NxbID { get; set; }

        public int TacGiaID { get; set; }

        public decimal? Price { get; set; }

        public decimal? PromotionPrice { get; set; }

        public int? PageNumber { get; set; }

        [ForeignKey("CategoryID")]
        public virtual BookCategory BookCategory { get; set; }

        [ForeignKey("NxbID")]
        public virtual NhaXuatBan NhaXuatBan { get; set; }

        [ForeignKey("TacGiaID")]
        public virtual TacGia TacGia { get; set; }
    }

}
