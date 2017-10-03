namespace PRSweb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addeduniqueidentifiertoProductVendorPartNumber : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.Products", "VendorPartNumber", unique: true);
        }
        
        public override void Down()
        {
            DropIndex("dbo.Products", new[] { "VendorPartNumber" });
        }
    }
}
