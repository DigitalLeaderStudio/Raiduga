namespace Raiduga.Interface.Attribute
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Text;
	using System.Threading.Tasks;

	[AttributeUsage(AttributeTargets.Method)]
	public class MapToFileAttribute : Attribute
	{
		public string EntityPropertyName { get; set; }
	}
}
