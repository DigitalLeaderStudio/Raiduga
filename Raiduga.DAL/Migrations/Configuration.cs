namespace Raiduga.DAL.Migrations
{
	using Microsoft.AspNet.Identity;
	using Raiduga.Models;
	using Raiduga.Models.Identity;
	using System;
	using System.Collections.Generic;
	using System.Data.Entity;
	using System.Data.Entity.Migrations;
	using System.Linq;

	internal sealed class Configuration : DbMigrationsConfiguration<Raiduga.DAL.ApplicationDbContext>
	{
		public Configuration()
		{
			AutomaticMigrationsEnabled = false;
		}

		protected override void Seed(ApplicationDbContext context)
		{
			char tab = '\u0009';

			#region User add

			var role = new Role
			{
				Name = "Admin"
			};

			context.Roles.AddOrUpdate(r => r.Name, role);

			var user = new User
				{
					UserName = "admin@admin.com",
					Email = "admin@admin.com",
					EmailConfirmed = true,
					SecurityStamp = "random",
					PasswordHash = new PasswordHasher().HashPassword("admin11")
				};

			context.Users.AddOrUpdate(u => u.Email, user);

			user.Roles.Add(new UserRole
			{
				RoleId = role.Id,
				UserId = user.Id
			});
			context.Users.AddOrUpdate(u => u.Email, user);

			context.SaveChanges();

			#endregion

			#region affiliates add
			
			#region affiliate 1

			var affiliate = new Affiliate
			{
				Name = "Volgogradska",
				Title = "філія 1",
				Description = "Головне вiддiлення",
				Address = new Address
				{
					Name = "вул. Волгоградська, 18",
					Latitude = 50.423958,
					Longitude = 30.484752
				},
				IsPrimary = true,
				Hours = new List<Hours>(),
				Emails = new List<Email>(),
				Phones = new List<Phone>(),
				HtmlDataContacts = @"<address>
								<i class=""fa fa-phone""></i>
								<a href=""tel:(044) 275-17-79"">(044) 275-17-79</a>
								<br>
								<i class=""fa fa-phone""></i>
								<a href=""tel:(096) 003-31-14"">(096) 003-31-14</a>
								<br>
								<i class=""fa fa-phone""></i>
								<a href=""tel:(099) 007-59-54"">(099) 007-59-54</a>
								<br>
						</address>
						<address>
							<i class=""fa fa-envelope""></i>
							<a href=""mailto:office@raiduga.kiev.ua"">office@raiduga.kiev.ua</a>
							<br>
						</address>".Replace(tab.ToString(), "")
			};

			affiliate.Phones.Add(new Phone { Number = "(044) 275-17-79" });
			affiliate.Phones.Add(new Phone { Number = "(096) 003-31-14" });
			affiliate.Phones.Add(new Phone { Number = "(099) 007-59-54" });
			affiliate.Emails.Add(new Email { Value = "office@raiduga.kiev.ua" });
			affiliate.Hours.Add(
				new Hours
				{
					Start = new TimeSpan(8, 30, 0),
					End = new TimeSpan(19, 0, 0)
				});

			context.Affiliates.AddOrUpdate(a => a.Name, affiliate);
			context.SaveChanges();
			
			#endregion
			
			#region affiliate 2

			var affiliate1 = new Affiliate
			{
				Name = "Piterska",
				Title = "філія 2",
				Description = "офісний центр, вхід через прохідну з вул.Єреванської за попереднім записом",
				Address = new Address
				{
					Name = "вул. Пітерська, 4а",
					Latitude = 50.433685,
					Longitude = 30.455922
				},

				IsPrimary = false,
				Hours = new List<Hours>(),
				Emails = new List<Email>(),
				Phones = new List<Phone>(),
				HtmlDataContacts = @"<address>
										<i class=""fa fa-phone""></i>
										<a href=""tel:(050) 448-49-07"">(050) 448-49-07</a>
										<br>
										<i class=""fa fa-phone""></i>
										<a href=""tel:(068) 455-04-26"">(068) 455-04-26</a>
										<br>
								</address>
								<address>
										<i class=""fa fa-envelope""></i>
										<a href=""mailto:office@raiduga.kiev.ua"">office@raiduga.kiev.ua</a>
										<br>
								</address>".Replace(tab.ToString(), "")
			};

			affiliate1.Phones.Add(new Phone { Number = "(050) 448-49-07" });
			affiliate1.Phones.Add(new Phone { Number = "(068) 455-04-26" });
			affiliate1.Emails.Add(new Email { Value = "office@raiduga.kiev.ua" });
			affiliate1.Hours.Add(
				new Hours
				{
					Start = new TimeSpan(9, 0, 0),
					End = new TimeSpan(19, 0, 0)
				});

			context.Affiliates.AddOrUpdate(a => a.Name, affiliate1);
			context.SaveChanges();
			
			#endregion 

			#region affiliate 3

			var affiliate2 = new Affiliate
			{
				Name = "Dontsa",
				Title = "філія 3",
				Description = "В приміщені колишнього ЖЕК, 2й поверх",
				Address = new Address
				{
					Name = "вул. Михайла Донця, 21Б",
					Latitude = 50.426862,
					Longitude = 30.426359
				},
				IsPrimary = false,
				Hours = new List<Hours>(),
				Emails = new List<Email>(),
				Phones = new List<Phone>(),
				HtmlDataContacts = @"<address>
										<i class=""fa fa-phone""></i>
										<a href=""tel:(044) 275-17-79"">(044) 275-17-79</a>
										<br>
										<i class=""fa fa-phone""></i>
										<a href=""tel:(066) 747-56-15"">(066) 747-56-15</a>
										<br>
										<i class=""fa fa-phone""></i>
										<a href=""tel:(063) 151-53-13"">(063) 151-53-13</a>
										<br>
								</address>
								<address>
										<i class=""fa fa-envelope""></i>
										<a href=""mailto:office@raiduga.kiev.ua"">office@raiduga.kiev.ua</a>
										<br>
								</address>".Replace(tab.ToString(), "")
			};

			affiliate2.Phones.Add(new Phone { Number = "(044) 275-17-79" });
			affiliate2.Phones.Add(new Phone { Number = "(066) 747-56-15" });
			affiliate2.Phones.Add(new Phone { Number = "(063) 151-53-13" });
			affiliate2.Emails.Add(new Email { Value = "office@raiduga.kiev.ua" });
			affiliate2.Hours.Add(
				new Hours
				{
					Start = new TimeSpan(9, 0, 0),
					End = new TimeSpan(19, 0, 0)
				});

			context.Affiliates.AddOrUpdate(a => a.Name, affiliate2);
			context.SaveChanges();

			#endregion

			#endregion
		}
	}
}
