using System.Web.Mvc;

namespace GameOfLife.Controllers
{
	public class HomeController : Controller
	{
		public ActionResult Index()
		{
			return View();
		}
	}
}
