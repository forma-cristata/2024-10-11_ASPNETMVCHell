using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using Inventory.API.DbContexts;
using Inventory.Shared.Models;

namespace Inventory.API.Controllers
{
    [ApiController]
    [Route("v1/[controller]")]
    public class StoreController : ControllerBase
    {
        public readonly ILogger<StoreController> _logger;

        private InventoryDBContext InventoryDBContext { get; init; }

        public StoreController(ILogger<StoreController> logger, InventoryDBContext inventoryDBContext)
        {
            _logger = logger;
            InventoryDBContext = inventoryDBContext;
        }

        [HttpGet("GetAllStores")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult GetAllStores()
        {
            return Ok(PeelProductFromStores(InventoryDBContext.Stores.ToList()));
        }


        [HttpGet("GetStoreFromId")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public Store? GetStoreFromId([Required][FromQuery] int storeId)
        {
            return PeelProductFromStores(InventoryDBContext.Stores.ToList()).FirstOrDefault(p => p.StoreId == storeId);
        }


        [HttpGet("GetStoreFromSlug")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public Store? GetStoreFromSlug([Required][FromQuery] String storeSlug)
        {
            return PeelProductFromStores(InventoryDBContext.Stores.ToList()).FirstOrDefault(p => p.Slug.Equals(storeSlug)); // TODO
        }


        [HttpPut("UpdateStore")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult UpdateStore([Required][FromBody] Store store)
        {
            Store? existingStore = InventoryDBContext.Stores.ToList().FirstOrDefault(p => p.StoreId.Equals(store.StoreId));

            if (existingStore == null)
            {
                return NotFound();
            }

            existingStore.Name = store.Name;
            existingStore.Location = store.Location;
            existingStore.DateOpened = store.DateOpened;
            

            InventoryDBContext.SaveChanges();

            return Ok(PeelProductFromStores([existingStore])[0]);

        }


        [HttpPost("CreateStore")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public IActionResult CreateStore([Required][FromBody] Store store)
        {
            store.StoreId = InventoryDBContext.Stores.Max(p => p.StoreId) + 1;
            InventoryDBContext.Stores.Add(store);

            InventoryDBContext.SaveChanges();

            return CreatedAtAction(nameof(GetStoreFromId), new { storeId = store.StoreId }, store);
        }


        [HttpDelete("DeleteStore")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult DeleteStore([Required][FromQuery] int storeId)
        {
            Store? store = InventoryDBContext.Stores.FirstOrDefault(p => p.StoreId == storeId);

            if (store == null)
            {
                return NotFound();
            }

            InventoryDBContext.Stores.Remove(store);
            InventoryDBContext.SaveChanges();
            return Ok();
        }

		private List<Store> PeelProductFromStores(List<Store> stores)
		{
			List<Store> noProdStore = [];
			foreach (Store s in stores)
			{
				noProdStore.Add(new Store()
				{
					StoreId = s.StoreId,
					Name = s.Name,
					Location = s.Location,
					DateOpened = s.DateOpened,
				});

			}
			return noProdStore;
		}
	}
}
