namespace Raiduga.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddApplyToCourseRequest : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ApplyToCourseRequests",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ChildName = c.String(nullable: false),
                        Phone = c.String(nullable: false),
                        Email = c.String(),
                        CourseId = c.Int(nullable: false),
                        BirthDate = c.DateTime(nullable: false),
                        CreationDate = c.DateTime(),
                        UpdationDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Courses", t => t.CourseId, cascadeDelete: true)
                .Index(t => t.CourseId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ApplyToCourseRequests", "CourseId", "dbo.Courses");
            DropIndex("dbo.ApplyToCourseRequests", new[] { "CourseId" });
            DropTable("dbo.ApplyToCourseRequests");
        }
    }
}
