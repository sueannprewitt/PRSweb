namespace PRSweb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedpurchaserequestlineitem : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PurchaseRequestLineItems",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Quantity = c.Int(nullable: false),
                        PurhaseRequestId = c.Int(nullable: false),
                        ProductId = c.Int(nullable: false),
                        PurchaseRequest_ID = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Products", t => t.ProductId, cascadeDelete: true)
                .ForeignKey("dbo.PurchaseRequests", t => t.PurchaseRequest_ID)
                .Index(t => t.ProductId)
                .Index(t => t.PurchaseRequest_ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PurchaseRequestLineItems", "PurchaseRequest_ID", "dbo.PurchaseRequests");
            DropForeignKey("dbo.PurchaseRequestLineItems", "ProductId", "dbo.Products");
            DropIndex("dbo.PurchaseRequestLineItems", new[] { "PurchaseRequest_ID" });
            DropIndex("dbo.PurchaseRequestLineItems", new[] { "ProductId" });
            DropTable("dbo.PurchaseRequestLineItems");
        }
    }
}
