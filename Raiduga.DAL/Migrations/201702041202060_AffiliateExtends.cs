namespace Raiduga.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AffiliateExtends : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Services", "AffiliateId", c => c.Int());
            CreateIndex("dbo.Services", "AffiliateId");
            AddForeignKey("dbo.Services", "AffiliateId", "dbo.Affiliates", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Services", "AffiliateId", "dbo.Affiliates");
            DropIndex("dbo.Services", new[] { "AffiliateId" });
            DropColumn("dbo.Services", "AffiliateId");
        }
    }
}
