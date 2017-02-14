namespace Raiduga.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeCourseSectionToAgeGroup : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Courses", "SectionId", "dbo.CourseSections");
            DropIndex("dbo.Courses", new[] { "SectionId" });
            CreateTable(
                "dbo.AgeGroups",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Lessons", "AgeGroupId", c => c.Int());
            CreateIndex("dbo.Lessons", "AgeGroupId");
            AddForeignKey("dbo.Lessons", "AgeGroupId", "dbo.AgeGroups", "Id");
            DropColumn("dbo.Courses", "SectionId");
            DropTable("dbo.CourseSections");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.CourseSections",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Courses", "SectionId", c => c.Int());
            DropForeignKey("dbo.Lessons", "AgeGroupId", "dbo.AgeGroups");
            DropIndex("dbo.Lessons", new[] { "AgeGroupId" });
            DropColumn("dbo.Lessons", "AgeGroupId");
            DropTable("dbo.AgeGroups");
            CreateIndex("dbo.Courses", "SectionId");
            AddForeignKey("dbo.Courses", "SectionId", "dbo.CourseSections", "Id");
        }
    }
}
