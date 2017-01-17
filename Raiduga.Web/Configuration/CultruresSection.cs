namespace Raiduga.Web.Configuration
{
	using System;
	using System.Collections.Generic;
	using System.Configuration;
	using System.Linq;
	using System.Web;

	public class CultruresSection : ConfigurationSection
	{
		[ConfigurationProperty("Cultures", IsRequired = true)]
		[ConfigurationCollection(typeof(CultureCollection), AddItemName = "CultureElement")]
		public CultureCollection Cultures
		{
			get
			{
				return base["Cultures"] as CultureCollection;
			}
			set
			{
				base["Cultures"] = value;
			}
		}
	}
}