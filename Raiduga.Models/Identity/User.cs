namespace Raiduga.Models.Identity
{
	using Microsoft.AspNet.Identity.EntityFramework;
	using Raiduga.Interface;

	public class User : IdentityUser<int, UserLogin, UserRole, UserClaim>, IEntity
	{

	}
}
