using Microsoft.AspNetCore.Mvc;
using prjMvcCoreLab.Models;

namespace prjMvcCoreLab.Controllers
{
	public class ProductController : Controller
	{
		public IActionResult List()
		{
			string keyword = Request.Form["txtKeyword"];
			dbDemoContext db = new dbDemoContext();
			IEnumerable<TProduct> datas = null;
			if (string.IsNullOrEmpty(keyword))
			{
				datas = from p in db.TProducts
						select p;
			}
			else
			{
				datas = db.TProducts.Where(p => p.FName.Contains(keyword));
			}
			return View(datas);
		}
		public IActionResult Create()
		{
			return View();
		}
		[HttpPost]
		public IActionResult Create(TProduct p)
		{
			dbDemoContext db = new dbDemoContext();
			db.TProducts.Add(p);
			db.SaveChanges();

			return RedirectToAction("List");
		}
		public IActionResult Delete(int? id)
		{
			if (id != null)
			{
				dbDemoContext db = new dbDemoContext();
				TProduct prod = db.TProducts.FirstOrDefault(p => p.FId == id);
				if (prod != null)
				{
					db.TProducts.Remove(prod);
					db.SaveChanges();
				}
			}

			return RedirectToAction("List");
		}
		public IActionResult Edit(int? id)
		{
			if (id != null)
			{
				dbDemoContext db = new dbDemoContext();
				TProduct prod = db.TProducts.FirstOrDefault(p => p.FId == id);
				if (prod != null)
				{
					return View(prod);
				}
			}
			return RedirectToAction("List");
		}
		//[HttpPost]
		//public IActionResult Edit(TProduct pIn)
		//{
		//	dbDemoContext db = new dbDemoContext();
		//	TProduct prod = db.TProducts.FirstOrDefault(p => p.FId == pIn.FId);
		//	if (prod != null)
		//	{
		//		if (pIn.photo != null)
		//		{
		//			string photoName = Guid.NewGuid().ToString() + ".jpg";
		//			pIn.photo.SaveAs(Server.MapPath("../../Images/" + photoName));
		//			prod.FImagePath = photoName;
		//		}
		//		prod.FName = pIn.FName;
		//		prod.FQty = pIn.FQty;
		//		prod.FCost = pIn.FCost;
		//		prod.FPrice = pIn.FPrice;
		//		db.SaveChanges();
		//	}

		//	return RedirectToAction("List");
		//}
	}
}
