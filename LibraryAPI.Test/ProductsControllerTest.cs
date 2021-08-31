using HPlusSport.API.Classes;
using HPlusSport.API.Controllers;
using HPlusSport.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using Xunit;

namespace LibraryAPI.Test
{
    public class ProductsControllerTest
    {
       
        ProductsController _controller;

        public DbContextOptions<ShopContext> ContextOptions { get; }

        ShopContext _context;
        //DbContextOptions<ShopContext> _options;
        ProductQueryParameters _queryParameters;

        //public ProductsControllerTest(DbContextOptions<ShopContext> contextOptions)
        public ProductsControllerTest()
        {
            //ContextOptions = contextOptions;
            _context = new InMemoryDbContextFactory().GetShopDbContext();

            //_options = new DbContextOptions<ShopContext>();
            //_context = new ShopContext(_options);
           // _context = new InMemoryDbContextFactory().GetShopDbContext();
           // _controller = new ProductsController(_context);
            _queryParameters = new ProductQueryParameters();

            //_context.Database.EnsureCreated();

            Seed();
        }

        private void Seed()
        {
            //using (var context = new ShopContext(ContextOptions))
           
           // {
                _context.Database.EnsureDeleted();
                _context.Database.EnsureCreated();

                var cat1 = new Category { Id = 34, Name = "Active Wear - Men" };
                var prod1 = new Product { Id = 34, CategoryId = 34, Name = "Grunge Skater Jeans", Sku = "AWMGSJ", Price = 68, IsAvailable = true };

            _context.Categories.AddRange(cat1);
            _context.Products.AddRange(prod1);

                _context.SaveChanges();
          //  }
        }

        [Fact]
        public void GetAllProducts()
        {
            ////arrange

            ////act
            //var result = _controller.GetAllProductsAsync(_queryParameters);

            ////assert
            //Assert.IsType<OkObjectResult>(result.Result);
            //var list = result.Result as OkObjectResult;
            //Assert.IsType<List<Product>>(list.Value);

            //var listProducts = list.Value as List<Product>;
            //// Assert.Equal(1, listProducts.Count);
            //Assert.Single(listProducts);


            //using (var context = new ShopContext(ContextOptions))
            //{
                var controller = new ProductsController(_context);

                var result = controller.GetAllProductsAsync(_queryParameters);

                //assert
                Assert.IsType<OkObjectResult>(result.Result);
                var list = result.Result as OkObjectResult;
            // Assert.IsType<List<Product>>(list.Value);

            var listProducts = list.Value as List<Product>;
                // Assert.Equal(1, listProducts.Count);
               // Assert.Single(listProducts);
               
                //Assert.Equal(3, items.Count);
                Assert.Equal("Active Wear - Men", listProducts[0].Name);
                //Assert.Equal("ItemThree", items[1].Name);
                //Assert.Equal("ItemTwo", items[2].Name);
            //}

        }
    }
}
