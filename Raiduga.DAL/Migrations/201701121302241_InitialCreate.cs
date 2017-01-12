namespace Raiduga.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
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
                        HtmlDataContacts = c.String(),
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
                        Start = c.Time(nullable: false, precision: 7),
                        End = c.Time(nullable: false, precision: 7),
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
                "dbo.ContactRequests",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Phone = c.String(),
                        Email = c.String(nullable: false),
                        Message = c.String(nullable: false),
                        CreationDate = c.DateTime(),
                        UpdationDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
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
            
            CreateTable(
                "dbo.Roles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.UserRoles",
                c => new
                    {
                        UserId = c.Int(nullable: false),
                        RoleId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.Roles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.Services",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        BodyHtml = c.String(),
                        Description = c.String(),
                        ImageId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Files", t => t.ImageId)
                .Index(t => t.ImageId);
            
            CreateTable(
                "dbo.Courses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PriorityOrder = c.Int(nullable: false),
                        Name = c.String(),
                        Description = c.String(),
                        Price = c.String(),
                        BodyHtml = c.String(),
                        Duration = c.Time(nullable: false, precision: 7),
                        CreationDate = c.DateTime(),
                        UpdationDate = c.DateTime(),
                        ServiceId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Services", t => t.ServiceId, cascadeDelete: true)
                .Index(t => t.ServiceId);
            
            CreateTable(
                "dbo.SliderItems",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(maxLength: 24),
                        SubTitle = c.String(maxLength: 128),
                        ImageId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Files", t => t.ImageId)
                .Index(t => t.ImageId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.UserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.UserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
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
            DropForeignKey("dbo.UserRoles", "UserId", "dbo.Users");
            DropForeignKey("dbo.UserLogins", "UserId", "dbo.Users");
            DropForeignKey("dbo.UserClaims", "UserId", "dbo.Users");
            DropForeignKey("dbo.SliderItems", "ImageId", "dbo.Files");
            DropForeignKey("dbo.Services", "ImageId", "dbo.Files");
            DropForeignKey("dbo.Courses", "ServiceId", "dbo.Services");
            DropForeignKey("dbo.UserRoles", "RoleId", "dbo.Roles");
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
            DropIndex("dbo.UserLogins", new[] { "UserId" });
            DropIndex("dbo.UserClaims", new[] { "UserId" });
            DropIndex("dbo.Users", "UserNameIndex");
            DropIndex("dbo.SliderItems", new[] { "ImageId" });
            DropIndex("dbo.Courses", new[] { "ServiceId" });
            DropIndex("dbo.Services", new[] { "ImageId" });
            DropIndex("dbo.UserRoles", new[] { "RoleId" });
            DropIndex("dbo.UserRoles", new[] { "UserId" });
            DropIndex("dbo.Roles", "RoleNameIndex");
            DropIndex("dbo.Affiliates", new[] { "Address_Id" });
            DropTable("dbo.PhonesToAffiliates");
            DropTable("dbo.HoursToAffiliates");
            DropTable("dbo.EmailsToAffiliates");
            DropTable("dbo.UserLogins");
            DropTable("dbo.UserClaims");
            DropTable("dbo.Users");
            DropTable("dbo.SliderItems");
            DropTable("dbo.Courses");
            DropTable("dbo.Services");
            DropTable("dbo.UserRoles");
            DropTable("dbo.Roles");
            DropTable("dbo.Files");
            DropTable("dbo.ContactRequests");
            DropTable("dbo.Phones");
            DropTable("dbo.Hours");
            DropTable("dbo.Emails");
            DropTable("dbo.Addresses");
            DropTable("dbo.Affiliates");
        }
    }
}
