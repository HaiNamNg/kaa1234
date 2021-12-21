namespace Demo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.HocTaps",
                c => new
                    {
                        HoVaTen = c.String(nullable: false, maxLength: 128),
                        MaSinhVien = c.String(nullable: false),
                        TenLop = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.HoVaTen)
                .ForeignKey("dbo.Lops", t => t.TenLop)
                .Index(t => t.TenLop);
            
            CreateTable(
                "dbo.Lops",
                c => new
                    {
                        MaLop = c.String(nullable: false, maxLength: 128),
                        TenLop = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.MaLop);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.HocTaps", "TenLop", "dbo.Lops");
            DropIndex("dbo.HocTaps", new[] { "TenLop" });
            DropTable("dbo.Lops");
            DropTable("dbo.HocTaps");
        }
    }
}
