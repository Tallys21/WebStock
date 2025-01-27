using Microsoft.EntityFrameworkCore;
using WebStock.Data;
using WebStock.Models;
using WebStock.Service.Exceptions;

namespace WebStock.Service
{
    public class ProductService
    {
        private readonly WebStockContext _context;

        public ProductService(WebStockContext webStockContext)
        {
            _context = webStockContext;
        }

        public async Task<List<Product>> FindAllAsync()
        {
            return await _context.Product.Include(x => x.Category).ToListAsync();
        }

        public async Task<Product> FindByIdAsync(int id)
        {
            return await _context.Product.Include(x => x.Category).FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task UpdateAsync(Product product)
        {
            bool hasAny = await _context.Product.AnyAsync(x => x.Id == product.Id);
            if (!hasAny)
            {
                throw new NotFoundException("Id not found!");
            }

            try
            {
                _context.Update(product);
                await _context.SaveChangesAsync();
            }
            catch (DbConcurrencyException ex)
            {
                throw new DbConcurrencyException(ex.Message);
            }
        }
    }
}
