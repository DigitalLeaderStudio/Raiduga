namespace Raiduga.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ExtendCampaign : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Campaigns", "Title", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Campaigns", "Title");
        }
    }
}
