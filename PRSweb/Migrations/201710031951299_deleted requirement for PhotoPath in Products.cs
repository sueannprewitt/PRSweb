namespace PRSweb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class deletedrequirementforPhotoPathinProducts : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Products", "PhotoPath", c => c.String(maxLength: 50));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Products", "PhotoPath", c => c.String(nullable: false, maxLength: 50));
        }
    }
}
