using HPlusSport.API.Classes;
using HPlusSport.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HPlusSport.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly ShopContext _context;

        public ProductsController(ShopContext context)
        {
            _context = context;

            _context.Database.EnsureCreated();
        }

        //[HttpGet]
        //public IEnumerable<Product> GetAllProducts()
        //{
        //    return _context.Products.ToArray();
        //}

        [HttpGet]
        public async Task<IActionResult> GetAllProductsAsync([FromQuery] ProductQueryParameters queryParameters)
        {
            IQueryable<Product> products = _context.Products;
           
            // -- FILTERING --
            if (queryParameters.MinPrice != null 
                && queryParameters.MaxPrice != null)
            {
                products = products.Where(
                    p => p.Price >= queryParameters.MinPrice.Value &&
                        p.Price <= queryParameters.MaxPrice.Value);
            }
            if (!string.IsNullOrEmpty(queryParameters.Sku))
            {
                products = products.Where(p => p.Sku == queryParameters.Sku);
            }
            // -- PAGINATING (ALSO SEE QueryParameters.cs) --
            products = products
                .Skip(queryParameters.Size * (queryParameters.Page - 1)) 
                .Take(queryParameters.Size);
            return Ok(await products.ToArrayAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProduct(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }
    }
}
