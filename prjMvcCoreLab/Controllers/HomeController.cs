using Microsoft.AspNetCore.Mvc;
using prjMvcCoreLab.Models;
using prjMvcDemo.ViewModels;
using System.Diagnostics;
using System.Text.Json;
namespace prjMvcCoreLab.Controllers
{
	public class HomeController : Controller
	{
		public IActionResult Login()
		{
			return View();
		}
		[HttpPost]
		public IActionResult Login(CLoginViewModel vm)
		{
			TCustomer user = (new dbDemoContext()).TCustomers.FirstOrDefault(t => t.FEmail.Equals(vm.txtAccount));

			if (user != null && user.FPassword.Equals(vm.txtPassword))
			{
				if (user.FPassword.Equals(vm.txtPassword))
				{
					string json = JsonSerializer.Serialize(user);
					HttpContext.Session.SetString(CDictionary.SK_LOGINED_USER, json);
					return RedirectToAction("Index");
				}
			}
			return View();
		}
		private readonly ILogger<HomeController> _logger;

		public HomeController(ILogger<HomeController> logger)
		{
			_logger = logger;
		}

		public IActionResult Index()
		{
			if (!HttpContext.Session.Keys.Contains(CDictionary.SK_LOGINED_USER))
			{
				return RedirectToAction("Login");
			}
			return View();
		}

		public IActionResult Privacy()
		{
			return View();
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}