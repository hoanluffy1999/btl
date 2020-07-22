using AutoMapper;
using Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Web_Ban_Sach.Models;

namespace Web_Ban_Sach.Mappings
{
    public class AutoMapperConfiguration:Profile
    {
        public AutoMapperConfiguration()
        {
            CreateMap<TacGia, TacGiaViewModel>();
            CreateMap<Book, BookViewModel>();
            CreateMap<BookCategory, BookCategoryViewModel>();
            CreateMap<NhaXuatBan, NhaXuatBanViewModel>();
        }
    }
}