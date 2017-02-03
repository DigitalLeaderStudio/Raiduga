namespace Raiduga.Models.Identity
{
	using Microsoft.AspNet.Identity.EntityFramework;
	using Raiduga.Interface;

	public class UserLogin : IdentityUserLogin<int>, IEntity
	{
	}
}
