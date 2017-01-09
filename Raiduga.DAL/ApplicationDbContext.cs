namespace Raiduga.DAL
{
	using Microsoft.AspNet.Identity.EntityFramework;
	using Raiduga.Models;
	using Raiduga.Models.Identity;
	using System.Data.Entity;

	public class ApplicationDbContext :
		IdentityDbContext<User, Role, int, UserLogin, UserRole, UserClaim>
	{
		public ApplicationDbContext()
			: base("RaidugaConnection")
		{
		}

		public static ApplicationDbContext Create()
		{
			return new ApplicationDbContext();
		}

		protected override void OnModelCreating(System.Data.Entity.DbModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);

			modelBuilder.Entity<User>().ToTable("Users");
			modelBuilder.Entity<UserClaim>().ToTable("UserClaims");
			modelBuilder.Entity<UserLogin>().ToTable("UserLogins");
			modelBuilder.Entity<UserRole>().ToTable("UserRoles");
			modelBuilder.Entity<Role>().ToTable("Roles");
		}

		public DbSet<SliderItem> SliderItems { get; set; }
	}
}
