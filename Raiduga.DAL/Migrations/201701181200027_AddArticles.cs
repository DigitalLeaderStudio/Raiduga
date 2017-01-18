namespace Raiduga.DAL.Migrations
{
	using System;
	using System.Data.Entity.Migrations;

	public partial class AddArticles : DbMigration
	{
		public override void Up()
		{
			CreateTable(
				"dbo.Articles",
				c => new
					{
						Id = c.Int(nullable: false, identity: true),
						IsPublished = c.Boolean(nullable: false),
						Author = c.String(),
						Keywords = c.String(),
						Title = c.String(maxLength: 100),
						Description = c.String(maxLength: 500),
						BodyHtml = c.String(),
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
			DropForeignKey("dbo.Articles", "ImageId", "dbo.Files");
			DropIndex("dbo.Articles", new[] { "ImageId" });
			DropTable("dbo.Articles");
		}
	}
}
