using Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Web_Ban_Sach.Models;

namespace Web_Ban_Sach.Infrastructure.Extension
{
    public static class EntityExtension
    {
        public static void UpdateTacGia(this TacGia tacGia, TacGiaViewModel tacGiaViewModel)
        {
            tacGia.ID = tacGiaViewModel.ID;
            tacGia.Name = tacGiaViewModel.Name;
            tacGia.Image = tacGiaViewModel.Image;
            tacGia.Description = tacGiaViewModel.Description;
            tacGia.CreateDate = tacGiaViewModel.CreateDate;
            tacGia.CreateBy = tacGiaViewModel.CreateBy;
            tacGia.UpdateDate = tacGiaViewModel.UpdateDate;
            tacGia.UpdateBy = tacGiaViewModel.UpdateBy;
            tacGia.Status = tacGiaViewModel.Status;

        }

        public static void UpdateBook(this Book book, BookViewModel bookViewModel)
        {
            book.ID = bookViewModel.ID;
            book.Name = bookViewModel.Name;
            book.Image = bookViewModel.Image;
            book.MoreImages = bookViewModel.MoreImages;
            book.Description = bookViewModel.Description;
            book.Content = bookViewModel.Content;
            book.CategoryID = bookViewModel.CategoryID;
            book.NxbID = bookViewModel.NxbID;
            book.TacGiaID = bookViewModel.TacGiaID;
            book.Price = bookViewModel.Price;
            book.PromotionPrice = bookViewModel.PromotionPrice;
            book.PageNumber = bookViewModel.PageNumber;


            book.CreateDate = bookViewModel.CreateDate;
            book.CreateBy = bookViewModel.CreateBy;
            book.UpdateDate = bookViewModel.UpdateDate;
            book.UpdateBy = bookViewModel.UpdateBy;
            book.Status = bookViewModel.Status;
        }
        public static void UpdateBookCategory(this BookCategory bookCategory, BookCategoryViewModel bookCategoryViewModel)
        {
            bookCategory.ID = bookCategoryViewModel.ID;
            bookCategory.Name = bookCategoryViewModel.Name;
            bookCategory.Image = bookCategoryViewModel.Image;
            bookCategory.Description = bookCategoryViewModel.Description;
            bookCategory.HomeFlag = bookCategoryViewModel.HomeFlag;
            bookCategory.CreateDate = bookCategoryViewModel.CreateDate;
            bookCategory.CreateBy = bookCategoryViewModel.CreateBy;
            bookCategory.UpdateDate = bookCategoryViewModel.UpdateDate;
            bookCategory.UpdateBy = bookCategoryViewModel.UpdateBy;
            bookCategory.Status = bookCategoryViewModel.Status;

        }
        public static void UpdateNhaXuatBan(this NhaXuatBan nhaXuatBan, NhaXuatBanViewModel nhaXuatBanViewModel)
        {
            nhaXuatBan.ID = nhaXuatBanViewModel.ID;
            nhaXuatBan.Name = nhaXuatBanViewModel.Name;

            nhaXuatBan.Description = nhaXuatBanViewModel.Description;
   
            nhaXuatBan.CreateDate = nhaXuatBanViewModel.CreateDate;
            nhaXuatBan.CreateBy = nhaXuatBanViewModel.CreateBy;
            nhaXuatBan.UpdateDate = nhaXuatBanViewModel.UpdateDate;
            nhaXuatBan.UpdateBy = nhaXuatBanViewModel.UpdateBy;
            nhaXuatBan.Status = nhaXuatBanViewModel.Status;

        }


    }
}