namespace Raiduga.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CourseExtending : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Lessons",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TeacherFullName = c.String(),
                        StartTime = c.Time(nullable: false, precision: 7),
                        GroupName = c.String(),
                        WeekDay = c.Int(nullable: false),
                        CourseId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Courses", t => t.CourseId, cascadeDelete: true)
                .Index(t => t.CourseId);
            
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
            CreateIndex("dbo.Courses", "SectionId");
            AddForeignKey("dbo.Courses", "SectionId", "dbo.CourseSections", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Courses", "SectionId", "dbo.CourseSections");
            DropForeignKey("dbo.Lessons", "CourseId", "dbo.Courses");
            DropIndex("dbo.Lessons", new[] { "CourseId" });
            DropIndex("dbo.Courses", new[] { "SectionId" });
            DropColumn("dbo.Courses", "SectionId");
            DropTable("dbo.CourseSections");
            DropTable("dbo.Lessons");
        }
    }
}
