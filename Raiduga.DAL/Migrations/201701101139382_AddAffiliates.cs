namespace Raiduga.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddAffiliates : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Affiliates",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 64),
                        Title = c.String(maxLength: 64),
                        Description = c.String(),
                        IsPrimary = c.Boolean(nullable: false),
                        Address_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Addresses", t => t.Address_Id)
                .Index(t => t.Address_Id);
            
            CreateTable(
                "dbo.Addresses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Latitude = c.Double(nullable: false),
                        Longitude = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Emails",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Value = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Hours",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Start = c.DateTime(nullable: false),
                        End = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Phones",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Number = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.EmailsToAffiliates",
                c => new
                    {
                        EmailId = c.Int(nullable: false),
                        AffiliateId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.EmailId, t.AffiliateId })
                .ForeignKey("dbo.Affiliates", t => t.EmailId, cascadeDelete: true)
                .ForeignKey("dbo.Emails", t => t.AffiliateId, cascadeDelete: true)
                .Index(t => t.EmailId)
                .Index(t => t.AffiliateId);
            
            CreateTable(
                "dbo.HoursToAffiliates",
                c => new
                    {
                        HoursId = c.Int(nullable: false),
                        AffiliateId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.HoursId, t.AffiliateId })
                .ForeignKey("dbo.Affiliates", t => t.HoursId, cascadeDelete: true)
                .ForeignKey("dbo.Hours", t => t.AffiliateId, cascadeDelete: true)
                .Index(t => t.HoursId)
                .Index(t => t.AffiliateId);
            
            CreateTable(
                "dbo.PhonesToAffiliates",
                c => new
                    {
                        PhoneId = c.Int(nullable: false),
                        AffiliateId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.PhoneId, t.AffiliateId })
                .ForeignKey("dbo.Affiliates", t => t.PhoneId, cascadeDelete: true)
                .ForeignKey("dbo.Phones", t => t.AffiliateId, cascadeDelete: true)
                .Index(t => t.PhoneId)
                .Index(t => t.AffiliateId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PhonesToAffiliates", "AffiliateId", "dbo.Phones");
            DropForeignKey("dbo.PhonesToAffiliates", "PhoneId", "dbo.Affiliates");
            DropForeignKey("dbo.HoursToAffiliates", "AffiliateId", "dbo.Hours");
            DropForeignKey("dbo.HoursToAffiliates", "HoursId", "dbo.Affiliates");
            DropForeignKey("dbo.EmailsToAffiliates", "AffiliateId", "dbo.Emails");
            DropForeignKey("dbo.EmailsToAffiliates", "EmailId", "dbo.Affiliates");
            DropForeignKey("dbo.Affiliates", "Address_Id", "dbo.Addresses");
            DropIndex("dbo.PhonesToAffiliates", new[] { "AffiliateId" });
            DropIndex("dbo.PhonesToAffiliates", new[] { "PhoneId" });
            DropIndex("dbo.HoursToAffiliates", new[] { "AffiliateId" });
            DropIndex("dbo.HoursToAffiliates", new[] { "HoursId" });
            DropIndex("dbo.EmailsToAffiliates", new[] { "AffiliateId" });
            DropIndex("dbo.EmailsToAffiliates", new[] { "EmailId" });
            DropIndex("dbo.Affiliates", new[] { "Address_Id" });
            DropTable("dbo.PhonesToAffiliates");
            DropTable("dbo.HoursToAffiliates");
            DropTable("dbo.EmailsToAffiliates");
            DropTable("dbo.Phones");
            DropTable("dbo.Hours");
            DropTable("dbo.Emails");
            DropTable("dbo.Addresses");
            DropTable("dbo.Affiliates");
        }
    }
}
