using HPlusSport.API.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryAPI.Test
{
    public class InMemoryDbContextFactory
    {
        public ShopContext GetShopDbContext()
        {
            var options = new DbContextOptionsBuilder<ShopContext>()
                        .UseInMemoryDatabase(databaseName: "Shop")
                        .Options;
            var dbContext = new ShopContext(options);

            return dbContext;
        }
    }
}
