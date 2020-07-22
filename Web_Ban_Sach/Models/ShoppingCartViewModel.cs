using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web_Ban_Sach.Models
{
    [Serializable]
    public class ShoppingCartViewModel
    {
        
        public int BookId { get; set; }
        public BookViewModel Book { get; set; }
        public int Quantity { get; set; }
    }
}