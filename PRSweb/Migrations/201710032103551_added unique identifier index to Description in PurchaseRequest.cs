namespace PRSweb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addeduniqueidentifierindextoDescriptioninPurchaseRequest : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.PurchaseRequests", "Description", unique: true);
        }
        
        public override void Down()
        {
            DropIndex("dbo.PurchaseRequests", new[] { "Description" });
        }
    }
}
