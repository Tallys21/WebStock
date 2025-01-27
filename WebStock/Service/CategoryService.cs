using Microsoft.EntityFrameworkCore;
using WebStock.Data;
using WebStock.Models;

namespace WebStock.Service
{
    public class CategoryService
    {
        private readonly WebStockContext _context;

        public CategoryService(WebStockContext context)
        {
            _context = context;
        }

        public async Task<List<Category>> FindAllASync()
        {
            return await _context.Category.OrderBy(x => x.Name).ToListAsync();
        }
    }
}
