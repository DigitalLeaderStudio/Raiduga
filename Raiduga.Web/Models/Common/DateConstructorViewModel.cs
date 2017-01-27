namespace Raiduga.Web.Models.Common
{
	using Raiduga.Web.Localization;
	using System;
	using System.Collections.Generic;
	using System.ComponentModel.DataAnnotations;
	using System.Globalization;
	using System.Web.Mvc;

	public class DateConstructorViewModel
	{
		public DateConstructorViewModel()
		{
			this.Years = new List<SelectListItem>();
			this.Months = new List<SelectListItem>();
			this.Days = new List<SelectListItem>();

			for (int i = DateTime.Now.Year; i > 1990; i--)
			{
				Years.Add(new SelectListItem
				{
					Text = i.ToString(),
					Value = i.ToString()
				});
			}

			for (int i = 1; i <= 13; i++)
			{
				Months.Add(new SelectListItem
				{
					Text = DateTimeFormatInfo.CurrentInfo.GetAbbreviatedMonthName(i),
					Value = i.ToString()
				});
			}

			for (int i = 1; i <= 31; i++)
			{
				Days.Add(new SelectListItem
				{
					Text = i.ToString(),
					Value = i.ToString()
				});
			}
		}

		[Display(ResourceType = typeof(Translations), Name = "Year")]
		public int Year { get; set; }
		public List<SelectListItem> Years { get; set; }

		[Display(ResourceType = typeof(Translations), Name = "Month")]
		public int Month { get; set; }
		public List<SelectListItem> Months { get; set; }

		[Display(ResourceType = typeof(Translations), Name = "Day")]
		public int Day { get; set; }
		public List<SelectListItem> Days { get; set; }
	}
}