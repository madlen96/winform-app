namespace ConsoleApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddUrl5 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Products", "Unitprice", c => c.Decimal(nullable: false, storeType: "money"));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Products", "Unitprice", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
    }
}
