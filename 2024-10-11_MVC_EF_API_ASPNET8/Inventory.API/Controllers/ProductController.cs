using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using Inventory.API.DbContexts;
using Inventory.Shared.Models;

namespace Inventory.API.Controllers
{
    [ApiController]
    [Route("v1/[controller]")]
    public class ProductController : ControllerBase
    {
        public readonly ILogger<ProductController> _logger;

        private InventoryDBContext InventoryDBContext {get; init;}

        public ProductController(ILogger<ProductController> logger, InventoryDBContext inventoryDBContext)
        {
            _logger = logger;
            InventoryDBContext = inventoryDBContext;
        }

        [HttpGet("GetAllProducts")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult GetAllProducts()
        {
            return Ok(PeelStoreFromProducts(InventoryDBContext.Products.ToList()));
        }


        [HttpGet("GetProductFromId")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public Product? GetProductFromId([Required][FromQuery] int productId)
        {
            return PeelStoreFromProducts(InventoryDBContext.Products.ToList()).FirstOrDefault(p=>p.ProductId == productId);
        }

        //UpdateProduct TODO

        [HttpGet("GetProductFromSlug")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public Product? GetProductFromSlug([Required][FromQuery] String productSlug)
        {
            return PeelStoreFromProducts(InventoryDBContext.Products.ToList()).FirstOrDefault(p=>p.Slug.Equals(productSlug));
        }


        [HttpPut("UpdateProduct")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult UpdateProduct([Required][FromBody] Product product)
        {
            Product? existingProduct = InventoryDBContext.Products.ToList().FirstOrDefault(p=>p.ProductId.Equals(product.ProductId));

            if (existingProduct == null)
            {
                return NotFound();
            }

            existingProduct.Name = product.Name;
            existingProduct.Description = product.Description;
            existingProduct.Price = product.Price;
            existingProduct.StockQuantity = product.StockQuantity;
            existingProduct.DateAdded = product.DateAdded;

            InventoryDBContext.SaveChanges();

            return Ok(PeelStoreFromProducts([existingProduct])[0]);

        }


        [HttpPost("CreateProduct")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public IActionResult CreateProduct([Required][FromBody] Product product)
        {
            product.ProductId = InventoryDBContext.Products.Max(p => p.ProductId) + 1;
            InventoryDBContext.Products.Add(product);

            InventoryDBContext.SaveChanges();

            return CreatedAtAction(nameof(GetProductFromId), new { productId = product.ProductId }, product);
        }


        [HttpDelete("DeleteProduct")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult DeleteProduct([Required][FromQuery] int productId)
        {
            Product? product = InventoryDBContext.Products.FirstOrDefault(p => p.ProductId == productId);

            if (product == null)
            {
                return NotFound();
            }

            InventoryDBContext.Products.Remove(product);
            InventoryDBContext.SaveChanges();
            return Ok();
        }

        private List<Product> PeelStoreFromProducts(List<Product> products)
        {
            List<Product> noStoresProd = [];
            foreach (Product p in products)
            {
                noStoresProd.Add(new Product()
                {
                    ProductId = p.ProductId,
                    Name = p.Name,
                    Description = p.Description,
                    Price = p.Price,
                    StockQuantity = p.StockQuantity,
                    DateAdded = p.DateAdded,
                });

            }
            return noStoresProd;
        }
    }
}
