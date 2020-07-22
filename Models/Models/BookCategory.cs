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
    [Table("BookCategories")]
    public class BookCategory :Auditable
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        [Required]
        public string Name { get; set; }
        [MaxLength(256)]
        public string Image { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public bool HomeFlag { get; set; }

        public virtual IEnumerable<Book> Books { get; set; }

    }
}
