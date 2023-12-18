namespace BlogApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Firstmigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Blogs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        CategoryId = c.Int(nullable: false),
                        Photo1 = c.String(),
                        Description1 = c.String(),
                        Photo2 = c.String(),
                        Description2 = c.String(),
                        Photo3 = c.String(),
                        Description3 = c.String(),
                        Photo4 = c.String(),
                        Description4 = c.String(),
                        Photo5 = c.String(),
                        Description5 = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Categories", t => t.CategoryId, cascadeDelete: true)
                .Index(t => t.CategoryId);
            
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        CategoryId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.CategoryId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Blogs", "CategoryId", "dbo.Categories");
            DropIndex("dbo.Blogs", new[] { "CategoryId" });
            DropTable("dbo.Categories");
            DropTable("dbo.Blogs");
        }
    }
}
