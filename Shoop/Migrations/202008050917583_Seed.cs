namespace Shoop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Seed : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Customers", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.Customers", new[] { "UserId" });
            AlterColumn("dbo.Customers", "UserId", c => c.String(maxLength: 128));
            CreateIndex("dbo.Customers", "UserId");
            AddForeignKey("dbo.Customers", "UserId", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Customers", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.Customers", new[] { "UserId" });
            AlterColumn("dbo.Customers", "UserId", c => c.String(nullable: false, maxLength: 128));
            CreateIndex("dbo.Customers", "UserId");
            AddForeignKey("dbo.Customers", "UserId", "dbo.AspNetUsers", "Id", cascadeDelete: true);
        }
    }
}
