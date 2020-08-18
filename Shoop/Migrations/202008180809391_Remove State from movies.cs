namespace Shoop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveStatefrommovies : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Orders", "State_Id", "dbo.States");
            DropForeignKey("dbo.Movies", "StateId", "dbo.States");
            DropIndex("dbo.Orders", new[] { "State_Id" });
            DropIndex("dbo.Movies", new[] { "StateId" });
            DropColumn("dbo.Orders", "State_Id");
            DropColumn("dbo.Movies", "StateId");
            DropTable("dbo.States");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.States",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Status = c.String(nullable: false, maxLength: 20),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Movies", "StateId", c => c.Int(nullable: false));
            AddColumn("dbo.Orders", "State_Id", c => c.Int());
            CreateIndex("dbo.Movies", "StateId");
            CreateIndex("dbo.Orders", "State_Id");
            AddForeignKey("dbo.Movies", "StateId", "dbo.States", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Orders", "State_Id", "dbo.States", "Id");
        }
    }
}
