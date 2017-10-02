namespace PRSweb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedproduct : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        VendorPartNumber = c.String(nullable: false, maxLength: 50),
                        Name = c.String(nullable: false, maxLength: 50),
                        Price = c.Double(nullable: false),
                        Unit = c.String(nullable: false, maxLength: 50),
                        PhotoPath = c.String(nullable: false, maxLength: 50),
                        VendorId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Vendors", t => t.VendorId, cascadeDelete: true)
                .Index(t => t.VendorId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Products", "VendorId", "dbo.Vendors");
            DropIndex("dbo.Products", new[] { "VendorId" });
            DropTable("dbo.Products");
        }
    }
}
