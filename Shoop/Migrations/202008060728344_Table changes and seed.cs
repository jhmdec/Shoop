namespace Shoop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Tablechangesandseed : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.States", "Status", c => c.String(nullable: false, maxLength: 20));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.States", "Status", c => c.String());
        }
    }
}
