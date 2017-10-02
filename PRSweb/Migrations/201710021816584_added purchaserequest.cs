namespace PRSweb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedpurchaserequest : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PurchaseRequests",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Description = c.String(nullable: false, maxLength: 50),
                        Justification = c.String(nullable: false, maxLength: 50),
                        DateNeeded = c.DateTime(nullable: false),
                        DeliveryMode = c.String(nullable: false, maxLength: 50),
                        Status = c.String(nullable: false, maxLength: 50),
                        Total = c.Double(nullable: false),
                        SubmittedDate = c.DateTime(nullable: false),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PurchaseRequests", "UserId", "dbo.Users");
            DropIndex("dbo.PurchaseRequests", new[] { "UserId" });
            DropTable("dbo.PurchaseRequests");
        }
    }
}
