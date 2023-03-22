namespace prjMvcCoreLab.Models
{
	public class CProductWrap
	{
		public CProductWrap()
		{
			_product = new TProduct();
		}
		private TProduct _product;

		public TProduct product 
		{
			get { return _product; }
			set { _product = value; }
		}
		public int FId
		{
			get => _product.FId;
			set => _product.FId = value; 
		}
		public string? FName
		{
			get => _product.FName;
			set => _product.FName = value;
		}

		public int? FQty
		{
			get => _product.FQty;
			set => _product.FQty = value;
		}

		public decimal? FCost
		{
			get => _product.FCost;
			set => _product.FCost = value;
		}

		public decimal? FPrice
		{
			get => _product.FPrice;
			set => _product.FPrice = value;
		}

		public string? FImagePath
		{
			get => _product.FImagePath;
			set => _product.FImagePath = value;
		}

		public IFormFile photo { get; set; }
	}
}
