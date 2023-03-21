using Microsoft.AspNetCore.Mvc;

namespace prjMvcCoreLab.Controllers
{
	public class AController : Controller
	{
        private readonly IWebHostEnvironment enviro;

        public AController(IWebHostEnvironment enviro )
        {
            this.enviro = enviro;
        }
		public IActionResult fileUploadDemo()
		{
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
