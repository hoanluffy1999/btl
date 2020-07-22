using Microsoft.AspNet.Identity.EntityFramework;
using Models.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class WebDbContext : IdentityDbContext<ApplicationUser>
    {
        public WebDbContext() : base("WebBanSach")
        {
            this.Configuration.LazyLoadingEnabled = true;
            this.Configuration.ProxyCreationEnabled = false;
        }
        public DbSet<Book> Books { get; set; }
        public DbSet<TacGia> TacGia { get; set; }
        public DbSet<BookCategory> BookCategories { get; set; }
        public DbSet<NhaXuatBan> NhaXuatBan { get; set; }
        public DbSet<Footer> Footers { get; set; }

        public static WebDbContext Create()
        {
            return new WebDbContext();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<IdentityUserRole>().HasKey(i => new { i.UserId, i.RoleId });
            modelBuilder.Entity<IdentityUserLogin>().HasKey(i => i.UserId);
        }
    }
}
