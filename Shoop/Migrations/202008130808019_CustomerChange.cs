namespace Shoop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CustomerChange : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Customers", "DeliveryAddress", c => c.String(maxLength: 250));
            AlterColumn("dbo.Customers", "DeliveryPostalCode", c => c.String(maxLength: 10));
            AlterColumn("dbo.Customers", "PhoneNumber", c => c.String(nullable: false, maxLength: 15));
            AlterColumn("dbo.Customers", "EmailAddress", c => c.String(nullable: false, maxLength: 255));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Customers", "EmailAddress", c => c.String(maxLength: 255));
            AlterColumn("dbo.Customers", "PhoneNumber", c => c.String(maxLength: 15));
            AlterColumn("dbo.Customers", "DeliveryPostalCode", c => c.String(nullable: false, maxLength: 10));
            AlterColumn("dbo.Customers", "DeliveryAddress", c => c.String(nullable: false, maxLength: 250));
        }
    }
}
