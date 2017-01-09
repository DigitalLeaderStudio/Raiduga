namespace Raiduga.Web.Managers
{
	using Microsoft.AspNet.Identity.Owin;
	using Microsoft.Owin;
	using Microsoft.Owin.Security;
	using Raiduga.Models.Identity;
	using System.Security.Claims;
	using System.Threading.Tasks;

	public class ApplicationSignInManager : SignInManager<User, int>
	{
		public ApplicationSignInManager(
			ApplicationUserManager userManager,
			IAuthenticationManager authenticationManager)
			: base(userManager, authenticationManager)
		{
		}

		public override Task<ClaimsIdentity> CreateUserIdentityAsync(User user)
		{
			return (UserManager as ApplicationUserManager).GenerateUserIdentityAsync(user);
		}

		public static ApplicationSignInManager Create(
			IdentityFactoryOptions<ApplicationSignInManager> options,
			IOwinContext context)
		{
			return new ApplicationSignInManager(context.GetUserManager<ApplicationUserManager>(), context.Authentication);
		}
	}
}