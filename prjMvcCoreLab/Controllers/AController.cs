using Microsoft.AspNetCore.Mvc;

namespace prjMvcCoreLab.Controllers
{
	public class AController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
