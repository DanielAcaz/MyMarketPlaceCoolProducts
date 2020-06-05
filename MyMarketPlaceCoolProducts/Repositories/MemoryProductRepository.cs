using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MyMarketPlaceCoolProducts.DAO;
using MyMarketPlaceCoolProducts.Models;

namespace MyMarketPlaceCoolProducts.Repositories
{
    public class MemoryProductRepository : IRepository<Product, string>
    {
        private readonly ProductDbContext Context;

        public MemoryProductRepository(ProductDbContext _Context)
        {
            Context = _Context;
        }

        public IList<Product> FindAll() => Context.Products.ToListAsync().Result;

        public Product FindById(string Id) => Context.Products.FindAsync(Id).Result;

        public Product InsertOne(Product _Product)
        {
            _Product.Id = GenerateId();
            Product Product = Context.Products.Add(_Product).Entity;
            _ = FlushChangesAsync();
            return Product;
        }

        private string GenerateId()
        {
            return "ID" + DateTime.Now.ToString("yyyyMMddHHmmssffff")
                + new Random().Next(1, 1000);
        }

        public bool RemoveOne(Product _Product)
        {
            Context.Products.Remove(_Product);
            _ = FlushChangesAsync();
            return true;
        }

        public Product UpdateOne(Product _Product, string Id)
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
