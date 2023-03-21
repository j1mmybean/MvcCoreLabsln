using Microsoft.AspNetCore.Mvc;
using prjMvcCoreLab.Models;

namespace prjMvcCoreLab.Controllers
{
	public class CustomerController : Controller
	{
		public IActionResult Delete(int? id)
		{
			if (id != null)
			{
				dbDemoContext db = new dbDemoContext();
				TCustomer customer = db.TCustomers.FirstOrDefault(c => c.FId == id);
				if (customer != null)
				{
					db.TCustomers.Remove(customer);
					db.SaveChanges();
				}
			}

			return RedirectToAction("List");
		}
		public IActionResult Create()
		{
			return View();
		}
		[HttpPost]
		public IActionResult Create(TCustomer p)
		{
			dbDemoContext dbDemoContext = new dbDemoContext();
			dbDemoContext.TCustomers.Add(p);
			dbDemoContext.SaveChanges();
			return RedirectToAction("List");
		}
		public IActionResult List()
		{
			dbDemoContext dbDemoContext = new dbDemoContext();
			var data = from c in dbDemoContext.TCustomers
					   select c;
			return View(data);
		}
	}
}
