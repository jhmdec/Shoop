namespace Shoop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Step01 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Movies", "MovieImageUrl", c => c.String());
            AlterColumn("dbo.Movies", "IMDBUrl", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Movies", "IMDBUrl", c => c.String(maxLength: 255));
            AlterColumn("dbo.Movies", "MovieImageUrl", c => c.String(maxLength: 255));
        }
    }
}
