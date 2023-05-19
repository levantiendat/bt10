namespace bt10.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DBQLBBKHv1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BAIBAO",
                c => new
                    {
                        ID_BB = c.String(nullable: false, maxLength: 10),
                        Name = c.String(),
                        TinhTrang = c.Boolean(nullable: false),
                        NamXuatBan = c.Int(nullable: false),
                        ID_TheLoai = c.String(maxLength: 5),
                        ID_TG = c.String(maxLength: 5),
                    })
                .PrimaryKey(t => t.ID_BB)
                .ForeignKey("dbo.TACGIA", t => t.ID_TG)
                .ForeignKey("dbo.THELOAI", t => t.ID_TheLoai)
                .Index(t => t.ID_TheLoai)
                .Index(t => t.ID_TG);
            
            CreateTable(
                "dbo.TACGIA",
                c => new
                    {
                        ID_TG = c.String(nullable: false, maxLength: 5),
                        Name = c.String(),
                        ID_NXB = c.String(maxLength: 5),
                    })
                .PrimaryKey(t => t.ID_TG)
                .ForeignKey("dbo.NHAXUATBAN", t => t.ID_NXB)
                .Index(t => t.ID_NXB);
            
            CreateTable(
                "dbo.NHAXUATBAN",
                c => new
                    {
                        ID_NXB = c.String(nullable: false, maxLength: 5),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.ID_NXB);
            
            CreateTable(
                "dbo.THELOAI",
                c => new
                    {
                        ID_TheLoai = c.String(nullable: false, maxLength: 5),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.ID_TheLoai);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.BAIBAO", "ID_TheLoai", "dbo.THELOAI");
            DropForeignKey("dbo.TACGIA", "ID_NXB", "dbo.NHAXUATBAN");
            DropForeignKey("dbo.BAIBAO", "ID_TG", "dbo.TACGIA");
            DropIndex("dbo.TACGIA", new[] { "ID_NXB" });
            DropIndex("dbo.BAIBAO", new[] { "ID_TG" });
            DropIndex("dbo.BAIBAO", new[] { "ID_TheLoai" });
            DropTable("dbo.THELOAI");
            DropTable("dbo.NHAXUATBAN");
            DropTable("dbo.TACGIA");
            DropTable("dbo.BAIBAO");
        }
    }
}
