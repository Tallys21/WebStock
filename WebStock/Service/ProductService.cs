using Microsoft.EntityFrameworkCore;
using WebStock.Data;
using WebStock.Models;

namespace WebStock.Service
{
    public class ProductService
    {
        private readonly WebStockContext _webStockContext;

        public ProductService(WebStockContext webStockContext)
        {
            _webStockContext = webStockContext;
        }

        public async Task<List<Product>> FindAllAsync()
        {
            return await _webStockContext.Product.Include(x => x.Category).ToListAsync();
        }

        public async Task<Product> FindByIdAsync(int id)
        {
            return await _webStockContext.Product.Include(x => x.Category).FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
