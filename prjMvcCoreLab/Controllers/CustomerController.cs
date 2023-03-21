using Microsoft.AspNetCore.Mvc;
using prjMvcCoreLab.Models;

namespace prjMvcCoreLab.Controllers
{
	public class CustomerController : Controller
	{
		public IActionResult Edit(int? id)
		{
			if (id != null)
			{
				dbDemoContext db = new dbDemoContext();
				TCustomer customer = db.TCustomers.FirstOrDefault(c => c.FId == id);
				if (customer != null)
				{
					return View(customer);
				}
			}
			return RedirectToAction("List");
		}
		[HttpPost]
		public IActionResult Edit(TCustomer cIn)
		{
			dbDemoContext db = new dbDemoContext();
			TCustomer customer = db.TCustomers.FirstOrDefault(p => p.FId == cIn.FId);
			if (customer != null)
			{	customer.FName = cIn.FName;
				customer.FEmail = cIn.FEmail;
				customer.FAddress = cIn.FAddress;
				customer.FPhone = cIn.FPhone;
				db.SaveChanges();
			}

			return RedirectToAction("List");
		}

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
