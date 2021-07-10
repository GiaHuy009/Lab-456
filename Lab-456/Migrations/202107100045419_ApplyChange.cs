namespace Lab_456.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ApplyChange : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Courses", "category_ID", "dbo.Categories");
            DropIndex("dbo.Courses", new[] { "category_ID" });
            DropColumn("dbo.Courses", "CategoryID");
            RenameColumn(table: "dbo.Courses", name: "category_ID", newName: "CategoryID");
            DropPrimaryKey("dbo.Categories");
            AlterColumn("dbo.Courses", "CategoryID", c => c.Byte(nullable: false));
            AlterColumn("dbo.Categories", "ID", c => c.Byte(nullable: false));
            AddPrimaryKey("dbo.Categories", "ID");
            CreateIndex("dbo.Courses", "CategoryID");
            AddForeignKey("dbo.Courses", "CategoryID", "dbo.Categories", "ID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Courses", "CategoryID", "dbo.Categories");
            DropIndex("dbo.Courses", new[] { "CategoryID" });
            DropPrimaryKey("dbo.Categories");
            AlterColumn("dbo.Categories", "ID", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.Courses", "CategoryID", c => c.Int());
            AddPrimaryKey("dbo.Categories", "ID");
            RenameColumn(table: "dbo.Courses", name: "CategoryID", newName: "category_ID");
            AddColumn("dbo.Courses", "CategoryID", c => c.Byte(nullable: false));
            CreateIndex("dbo.Courses", "category_ID");
            AddForeignKey("dbo.Courses", "category_ID", "dbo.Categories", "ID");
        }
    }
}
