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

		#region DbSets

		public virtual DbSet<SliderItem> SliderItems { get; set; }

		public virtual DbSet<Affiliate> Affiliates { get; set; }

		public virtual DbSet<ContactRequest> ContactRequests { get; set; }

		public virtual DbSet<Service> Services { get; set; }

		public virtual DbSet<File> Files { get; set; }

		public virtual DbSet<UserFeedback> UserFeedbacks { get; set; }

		public virtual DbSet<HtmlContent> HtmlContents { get; set; }

		public virtual DbSet<Article> Articles { get; set; }

		#endregion

		protected override void OnModelCreating(System.Data.Entity.DbModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);

			modelBuilder.Entity<User>().ToTable("Users");
			modelBuilder.Entity<UserClaim>().ToTable("UserClaims");
			modelBuilder.Entity<UserLogin>().ToTable("UserLogins");
			modelBuilder.Entity<UserRole>().ToTable("UserRoles");
			modelBuilder.Entity<Role>().ToTable("Roles");

			modelBuilder.Entity<Affiliate>()
				.HasMany(a => a.Phones)
				.WithMany(p => p.Affiliates)
				.Map(map =>
				{
					map.ToTable("PhonesToAffiliates");
					map.MapLeftKey("PhoneId");
					map.MapRightKey("AffiliateId");
				});

			modelBuilder.Entity<Affiliate>()
				.HasMany(a => a.Emails)
				.WithMany(p => p.Affiliates)
				.Map(map =>
				{
					map.ToTable("EmailsToAffiliates");
					map.MapLeftKey("EmailId");
					map.MapRightKey("AffiliateId");
				});

			modelBuilder.Entity<Affiliate>()
				.HasMany(a => a.Hours)
				.WithMany(p => p.Affiliates)
				.Map(map =>
				{
					map.ToTable("HoursToAffiliates");
					map.MapLeftKey("HoursId");
					map.MapRightKey("AffiliateId");
				});
		}
	}
}
