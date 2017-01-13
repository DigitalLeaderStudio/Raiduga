namespace Raiduga.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddUserFeedback : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UserFeedbacks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserName = c.String(),
                        Text = c.String(),
                        IsActive = c.Boolean(nullable: false),
                        CreationDate = c.DateTime(),
                        UpdationDate = c.DateTime(),
                        ImageId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Files", t => t.ImageId)
                .Index(t => t.ImageId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserFeedbacks", "ImageId", "dbo.Files");
            DropIndex("dbo.UserFeedbacks", new[] { "ImageId" });
            DropTable("dbo.UserFeedbacks");
        }
    }
}
