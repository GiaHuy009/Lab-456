namespace Lab_456.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateTableCourse : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 255),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Courses",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        LucturerID = c.String(nullable: false, maxLength: 128),
                        Place = c.String(nullable: false, maxLength: 255),
                        DateTime = c.DateTime(nullable: false),
                        CategoryID = c.Byte(nullable: false),
                        category_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Categories", t => t.category_ID)
                .ForeignKey("dbo.AspNetUsers", t => t.LucturerID, cascadeDelete: true)
                .Index(t => t.LucturerID)
                .Index(t => t.category_ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Courses", "LucturerID", "dbo.AspNetUsers");
            DropForeignKey("dbo.Courses", "category_ID", "dbo.Categories");
            DropIndex("dbo.Courses", new[] { "category_ID" });
            DropIndex("dbo.Courses", new[] { "LucturerID" });
            DropTable("dbo.Courses");
            DropTable("dbo.Categories");
        }
    }
}
