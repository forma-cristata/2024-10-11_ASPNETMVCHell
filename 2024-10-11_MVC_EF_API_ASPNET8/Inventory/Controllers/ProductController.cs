using Microsoft.AspNetCore.Mvc;
using Inventory.Shared.Models;
using System.Diagnostics;
using System.Linq.Expressions;

namespace Inventory.Controllers
{
	public class ProductController : Controller
	{
		private readonly IHttpClientFactory _httpClientFactory;

		public ProductController(IHttpClientFactory httpClientFactory)
		{
			_httpClientFactory = httpClientFactory;
		}
		[HttpGet]
		public async Task<IActionResult> Detail(String id)
		{
			HttpClient client = _httpClientFactory.CreateClient();

			try
			{
				ProductController? response = await client.GetFromJsonAsync<ProductController>($"{Constants.API_URL}/v1/Product/GetProductFromSlug?productSlug={id}");

				if (response == null)
				{
					throw new HttpRequestException("Product not found");
				}

				return View(response);
			}
			catch (Exception e)
			{
#if DEBUG
				Debugger.Break();
#endif
				Console.Error.WriteLine(e.Message);

				return View("Error");
			}
		}




		[HttpGet]
		public async Task<IActionResult> List()
		{
			try
			{
				HttpClient client = _httpClientFactory.CreateClient();

				IEnumerable<Product>? response = await client.GetFromJsonAsync<IEnumerable<Product>>($"{Constants.API_URL}/v1/Product/GetAllProducts");

				if (response == null)
				{
					throw new HttpRequestException("Products not found");
				}

				return View(response.ToList());
			}
			catch (Exception e)
			{
#if DEBUG
				Debugger.Break();
#endif
				Console.Error.WriteLine(e.Message);

				return View("Error");
			}
		}


		[HttpGet]
		public IActionResult Create()
		{
			return View(new Product());
		}


		[HttpPost]
		public async Task<IActionResult> UpdateProduct(Product product)
		{
			try
			{
				HttpClient client = _httpClientFactory.CreateClient();

				HttpResponseMessage response = await client.PutAsJsonAsync($"{Constants.API_URL}/v1/Product/UpdateProduct", product);

				if (!response.IsSuccessStatusCode)
				{
					throw new HttpRequestException("Product not updated");
				}

				return RedirectToAction("Detail", new { id = product.Slug });
			}
			catch (HttpRequestException e) 
			{
#if DEBUG
				Debugger.Break();
#endif
				Console.Error.WriteLine(e.Message);
				return View("Error");
			}
		}

		[HttpPost]
		public async Task<IActionResult> CreateProduct(Product product)
		{
			try
			{
				HttpClient client = _httpClientFactory.CreateClient();

				HttpResponseMessage response = await client.PostAsJsonAsync($"{Constants.API_URL}/v1/Product/CreateProduct", product);


				if (!response.IsSuccessStatusCode)
				{
					throw new HttpRequestException("Product not created");
				}

				return RedirectToAction("List");
			}
			catch (HttpRequestException e)
			{

#if DEBUG
				Debugger.Break(); // If an exception occurs and we are debugging, this
								  //Breaks the debugger


				// PORT 7247
#endif

				Console.Error.WriteLine(e.Message);

				return View("Error");
			}
		}

		[HttpPost]
		public async Task<IActionResult> DeleteProduct(Product product)
		{
			try
			{
				HttpClient client = _httpClientFactory.CreateClient();

				HttpResponseMessage response = await client.DeleteAsync($"{Constants.API_URL}/v1/Product/DeleteProduct?productId={product.ProductId}");

				if (!response.IsSuccessStatusCode)
				{
					throw new HttpRequestException("Product not deleted");
				}

				return RedirectToAction("List");
			}
			catch (HttpRequestException e)
			{

#if DEBUG
				Debugger.Break(); // If an exception occurs and we are debugging, this
								  //Breaks the debugger


				// PORT 7247
#endif

				Console.Error.WriteLine(e.Message);

				return View("Error");
			}
		}
	}
}



			