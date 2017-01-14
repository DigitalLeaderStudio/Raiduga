namespace Raiduga.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddHtmlContent : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.HtmlContents",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        BodyHtml = c.String(),
                        CreationDate = c.DateTime(),
                        UpdationDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.HtmlContents");
        }
    }
}
