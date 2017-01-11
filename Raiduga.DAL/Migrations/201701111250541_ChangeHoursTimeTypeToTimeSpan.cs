namespace Raiduga.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeHoursTimeTypeToTimeSpan : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Hours", "Start", c => c.Time(nullable: false, precision: 7));
            AlterColumn("dbo.Hours", "End", c => c.Time(nullable: false, precision: 7));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Hours", "End", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Hours", "Start", c => c.DateTime(nullable: false));
        }
    }
}
