using Microsoft.AspNetCore.Mvc;
using prjMvcCoreLab.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace prjMvcCoreLab.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class GameQueryServicesController : ControllerBase
	{
		// GET: api/<GameQueryServicesController>
		[HttpGet]
		public IEnumerable<TProduct> Get()
		{
			var datas = (new dbDemoContext()).TProducts;
			foreach (var t in datas)
			{
				t.FCost = 0;
				if (t.FQty > 100)
				{
					t.FQty = 100;
				}
			}
			return datas;
		}

		// GET api/<GameQueryServicesController>/5
		[HttpGet("{id}")]
		public string Get(int id)
		{
			return "value";
		}

		// POST api/<GameQueryServicesController>
		[HttpPost]
		public void Post([FromBody] string value)
		{
		}

		// PUT api/<GameQueryServicesController>/5
		[HttpPut("{id}")]
		public void Put(int id, [FromBody] string value)
		{
		}

		// DELETE api/<GameQueryServicesController>/5
		[HttpDelete("{id}")]
		public void Delete(int id)
		{
		}
	}
}
