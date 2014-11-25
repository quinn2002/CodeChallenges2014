using System.Collections.Generic;
using System.Web.Mvc;
using MVCCodeChallenges.Models;

namespace MVCCodeChallenges.ViewModels
{
	public class HomeIndexViewModel
	{
		public IEnumerable<Challenge> Challenges { get; set; }
		public string SelectedYear { get; set; }
		public SelectList Years { get; set; }
	}
}