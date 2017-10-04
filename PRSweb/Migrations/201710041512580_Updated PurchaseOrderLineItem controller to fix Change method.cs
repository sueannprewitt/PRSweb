namespace PRSweb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatedPurchaseOrderLineItemcontrollertofixChangemethod : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.PurchaseRequestLineItems", "PurchaseRequest_ID", "dbo.PurchaseRequests");
            DropIndex("dbo.PurchaseRequestLineItems", new[] { "PurchaseRequest_ID" });
            RenameColumn(table: "dbo.PurchaseRequestLineItems", name: "PurchaseRequest_ID", newName: "PurchaseRequestId");
            AlterColumn("dbo.PurchaseRequestLineItems", "PurchaseRequestId", c => c.Int(nullable: false));
            CreateIndex("dbo.PurchaseRequestLineItems", "PurchaseRequestId");
            AddForeignKey("dbo.PurchaseRequestLineItems", "PurchaseRequestId", "dbo.PurchaseRequests", "ID", cascadeDelete: true);
            DropColumn("dbo.PurchaseRequestLineItems", "PurhaseRequestId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.PurchaseRequestLineItems", "PurhaseRequestId", c => c.Int(nullable: false));
            DropForeignKey("dbo.PurchaseRequestLineItems", "PurchaseRequestId", "dbo.PurchaseRequests");
            DropIndex("dbo.PurchaseRequestLineItems", new[] { "PurchaseRequestId" });
            AlterColumn("dbo.PurchaseRequestLineItems", "PurchaseRequestId", c => c.Int());
            RenameColumn(table: "dbo.PurchaseRequestLineItems", name: "PurchaseRequestId", newName: "PurchaseRequest_ID");
            CreateIndex("dbo.PurchaseRequestLineItems", "PurchaseRequest_ID");
            AddForeignKey("dbo.PurchaseRequestLineItems", "PurchaseRequest_ID", "dbo.PurchaseRequests", "ID");
        }
    }
}
