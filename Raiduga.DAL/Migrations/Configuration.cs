namespace Raiduga.DAL.Migrations
{
	using Microsoft.AspNet.Identity;
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

		protected override void Seed(Raiduga.DAL.ApplicationDbContext context)
		{
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
		}
	}
}
