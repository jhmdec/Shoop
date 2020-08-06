namespace Shoop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedState : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Movies", "State", c => c.Int(nullable: false));
            DropColumn("dbo.Movies", "StatusFlag");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Movies", "StatusFlag", c => c.Int(nullable: false));
            DropColumn("dbo.Movies", "State");
        }
    }
}
