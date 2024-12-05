using Microsoft.AspNetCore.Mvc;
using Inventory.Shared.Models;
using System.Diagnostics;
using System.Linq.Expressions;

namespace Inventory.Controllers
{
	public class StoreController : Controller
	{
		private readonly IHttpClientFactory _httpClientFactory;

		public StoreController(IHttpClientFactory httpClientFactory)
		{
			_httpClientFactory = httpClientFactory;
		}
		[HttpGet]
		public async Task<IActionResult> Detail(String id)
		{
			HttpClient client = _httpClientFactory.CreateClient();

			try
			{
				StoreController? response = await client.GetFromJsonAsync<StoreController>($"{Constants.API_URL}/v1/Store/GetStoreFromSlug?storeSlug={id}");

				if (response == null)
				{
					throw new HttpRequestException("Store not found");
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

				IEnumerable<Store>? response = await client.GetFromJsonAsync<IEnumerable<Store>>($"{Constants.API_URL}/v1/Store/GetAllStores");

				if (response == null)
				{
					throw new HttpRequestException("Stores not found");
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
			return View(new Store());
		}


		[HttpPost]
		public async Task<IActionResult> UpdateStore(Store store)
		{
			try
			{
				HttpClient client = _httpClientFactory.CreateClient();

				HttpResponseMessage response = await client.PutAsJsonAsync($"{Constants.API_URL}/v1/Store/UpdateStore", store);

				if (!response.IsSuccessStatusCode)
				{
					throw new HttpRequestException("Store not updated");
				}

				return RedirectToAction("Detail", new { id = store.Slug });
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
		public async Task<IActionResult> CreateStore(Store store)
		{
			try
			{
				HttpClient client = _httpClientFactory.CreateClient();

				HttpResponseMessage response = await client.PostAsJsonAsync($"{Constants.API_URL}/v1/Store/CreateStore", store);


				if (!response.IsSuccessStatusCode)
				{
					throw new HttpRequestException("Store not created");
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
		public async Task<IActionResult> DeleteProduct(Store store)
		{
			try
			{
				HttpClient client = _httpClientFactory.CreateClient();

				HttpResponseMessage response = await client.DeleteAsync($"{Constants.API_URL}/v1/Store/DeleteStore?storeId={store.StoreId}");

				if (!response.IsSuccessStatusCode)
				{
					throw new HttpRequestException("Store not deleted");
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



			