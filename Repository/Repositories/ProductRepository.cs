using Microsoft.EntityFrameworkCore;
using Repository.Data;
using Repository.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Repository.Repositories
{
    public class ProductRepository
    {

        private readonly WebApiDemoContext _context;

        public ProductRepository(WebApiDemoContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Product>> GetAsync()
        {
            return await _context.Product.ToListAsync();
        }

        public async Task<Product> GetAsync(int id)
        {
            return await _context.Product.FindAsync(id);
        }

        public async Task UpdateAsync(int id, Product product)
        {

            if (id != product.Id)
            {
                throw new Exception("Id Inválido");
            }

                _context.Entry(product).State = EntityState.Modified;

            await _context.SaveChangesAsync();
        }

        public async Task CreateAsync(Product product)
        {
            _context.Product.Add(product);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var product = await _context.Product.FindAsync(id);
            if (product == null)
            {
                throw new Exception("Id Inválido");
            }

            _context.Product.Remove(product);
            await _context.SaveChangesAsync();
        }
    }
}
