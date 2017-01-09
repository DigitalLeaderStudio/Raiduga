namespace Raiduga.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddFile : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.SliderItems",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(maxLength: 24),
                        SubTitle = c.String(maxLength: 128),
                        Image_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Files", t => t.Image_Id)
                .Index(t => t.Image_Id);
            
            CreateTable(
                "dbo.Files",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FileName = c.String(),
                        ContentType = c.String(),
                        Content = c.Binary(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SliderItems", "Image_Id", "dbo.Files");
            DropIndex("dbo.SliderItems", new[] { "Image_Id" });
            DropTable("dbo.Files");
            DropTable("dbo.SliderItems");
        }
    }
}
