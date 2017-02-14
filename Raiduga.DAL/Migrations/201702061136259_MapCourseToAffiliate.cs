namespace Raiduga.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MapCourseToAffiliate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Courses", "AffiliateId", c => c.Int());
            CreateIndex("dbo.Courses", "AffiliateId");
            AddForeignKey("dbo.Courses", "AffiliateId", "dbo.Affiliates", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Courses", "AffiliateId", "dbo.Affiliates");
            DropIndex("dbo.Courses", new[] { "AffiliateId" });
            DropColumn("dbo.Courses", "AffiliateId");
        }
    }
}
