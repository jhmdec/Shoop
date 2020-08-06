namespace Shoop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NewAttempttoAddState : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.States",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Status = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Orders", "State_Id", c => c.Int());
            AddColumn("dbo.Movies", "StateId", c => c.Int(nullable: false));
            CreateIndex("dbo.Orders", "State_Id");
            CreateIndex("dbo.Movies", "StateId");
            AddForeignKey("dbo.Orders", "State_Id", "dbo.States", "Id");
            AddForeignKey("dbo.Movies", "StateId", "dbo.States", "Id", cascadeDelete: true);
            DropColumn("dbo.Movies", "State");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Movies", "State", c => c.Int(nullable: false));
            DropForeignKey("dbo.Movies", "StateId", "dbo.States");
            DropForeignKey("dbo.Orders", "State_Id", "dbo.States");
            DropIndex("dbo.Movies", new[] { "StateId" });
            DropIndex("dbo.Orders", new[] { "State_Id" });
            DropColumn("dbo.Movies", "StateId");
            DropColumn("dbo.Orders", "State_Id");
            DropTable("dbo.States");
        }
    }
}
