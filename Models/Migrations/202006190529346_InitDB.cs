namespace Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitDB : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BookCategories",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Image = c.String(maxLength: 256),
                        Description = c.String(nullable: false),
                        HomeFlag = c.Boolean(nullable: false),
                        CreateDate = c.DateTime(),
                        CreateBy = c.String(maxLength: 256),
                        UpdateDate = c.DateTime(),
                        UpdateBy = c.String(maxLength: 256),
                        Status = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Books",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 256),
                        Image = c.String(),
                        MoreImages = c.String(storeType: "xml"),
                        Description = c.String(),
                        Content = c.String(),
                        CategoryID = c.Int(nullable: false),
                        NxbID = c.Int(nullable: false),
                        TacGiaID = c.Int(nullable: false),
                        Price = c.Decimal(precision: 18, scale: 2),
                        PromotionPrice = c.Decimal(precision: 18, scale: 2),
                        PageNumber = c.Int(),
                        CreateDate = c.DateTime(),
                        CreateBy = c.String(maxLength: 256),
                        UpdateDate = c.DateTime(),
                        UpdateBy = c.String(maxLength: 256),
                        Status = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.BookCategories", t => t.CategoryID, cascadeDelete: true)
                .ForeignKey("dbo.NhanXuatBan", t => t.NxbID, cascadeDelete: true)
                .ForeignKey("dbo.TacGia", t => t.TacGiaID, cascadeDelete: true)
                .Index(t => t.CategoryID)
                .Index(t => t.NxbID)
                .Index(t => t.TacGiaID);
            
            CreateTable(
                "dbo.NhanXuatBan",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Description = c.String(),
                        CreateDate = c.DateTime(),
                        CreateBy = c.String(maxLength: 256),
                        UpdateDate = c.DateTime(),
                        UpdateBy = c.String(maxLength: 256),
                        Status = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.TacGia",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Image = c.String(),
                        Description = c.String(nullable: false),
                        CreateDate = c.DateTime(),
                        CreateBy = c.String(maxLength: 256),
                        UpdateDate = c.DateTime(),
                        UpdateBy = c.String(maxLength: 256),
                        Status = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Footer",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Content = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Books", "TacGiaID", "dbo.TacGia");
            DropForeignKey("dbo.Books", "NxbID", "dbo.NhanXuatBan");
            DropForeignKey("dbo.Books", "CategoryID", "dbo.BookCategories");
            DropIndex("dbo.Books", new[] { "TacGiaID" });
            DropIndex("dbo.Books", new[] { "NxbID" });
            DropIndex("dbo.Books", new[] { "CategoryID" });
            DropTable("dbo.Footer");
            DropTable("dbo.TacGia");
            DropTable("dbo.NhanXuatBan");
            DropTable("dbo.Books");
            DropTable("dbo.BookCategories");
        }
    }
}
