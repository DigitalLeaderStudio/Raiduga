namespace Raiduga.Models.Identity
{
	using Microsoft.AspNet.Identity.EntityFramework;

	public class User : IdentityUser<int, UserLogin, UserRole, UserClaim>
	{

	}
}
