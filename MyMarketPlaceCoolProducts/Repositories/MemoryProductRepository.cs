using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MyMarketPlaceCoolProducts.DAO;
using MyMarketPlaceCoolProducts.Model;

namespace MyMarketPlaceCoolProducts.Repositories
{
    public class MemoryProductRepository : IRepository<Product, long>
    {
        private readonly ProductDbContext Context;

        public MemoryProductRepository()
        {
            var options = new DbContextOptionsBuilder<ProductDbContext>()
                .UseInMemoryDatabase(databaseName: "Products")
                .Options;
            Context = new ProductDbContext(options);
        }

        public IList<Product> FindAll() => Context.Products.ToListAsync().Result;

        public Product FindById(long Id) => Context.Products.FindAsync(Id).Result;

        public Product InsertOne(Product _Product)
        {
            Product Product = Context.Products.Add(_Product).Entity;
            _ = FlushChangesAsync();
            return Product;
        }

        public bool RemoveOne(Product _Product)
        {
            Context.Products.Remove(_Product);
            _ = FlushChangesAsync();
            return true;
        }

        public Product UpdateOne(Product _Product, long Id)
        {
            _Product.Id = Id;
            Context.Entry(_Product).State = EntityState.Modified;
            _ = FlushChangesAsync();
            return _Product;
        }

        private async Task FlushChangesAsync()
        {
            await Context.SaveChangesAsync();
        }
    }
}
