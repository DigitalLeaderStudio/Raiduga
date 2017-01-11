namespace Raiduga.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AffiliateSimpleContactsSolution : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Affiliates", "HtmlDataContacts", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Affiliates", "HtmlDataContacts");
        }
    }
}
