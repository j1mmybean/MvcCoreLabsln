using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http.Metadata;
using prjMvcCoreLab.Models;
//using Newtonsoft.Json;
using System.Text.Json;

namespace prjMvcCoreLab.Controllers
{
	public class AController : Controller
	{
		public string demoObjToJson()
		{
			TCustomer x = new TCustomer()
			{
				FId = 1,
				FName = "Marco",
				FPhone = "0100000112",
				FEmail = "Marco@gmail.com",
				FAddress = "Taipei",
				FPassword = "1234",
			};
			string json = JsonSerializer.Serialize(x);
			return json;
		}
		public string demoJsonToObj()
		{
			string json = demoObjToJson();
			TCustomer x = JsonSerializer.Deserialize<TCustomer>(json);
			return x.FName + "<br/>" + x.FPhone;
		}
		private readonly IWebHostEnvironment enviro;

		public AController(IWebHostEnvironment enviro)
		{
			this.enviro = enviro;
		}
		public IActionResult fileUploadDemo()
		{
			return View();
		}
		public IActionResult showCountBySession()
		{
			int count = 0;
			if (HttpContext.Session.Keys.Contains("COUNT"))
			{
				count = (int)HttpContext.Session.GetInt32("COUNT");
			}
			count++;
			HttpContext.Session.SetInt32("COUNT", count);
			ViewBag.COUNT = count;
			return View();
		}
		[HttpPost]
		public IActionResult fileUploadDemo(IFormFile photo)
		{
			string path = enviro.WebRootPath + "/images/001.jpg";
			photo.CopyTo(new FileStream(path, FileMode.Create));
			return View();
		}
	}
}
