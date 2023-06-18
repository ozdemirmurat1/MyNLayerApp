using Microsoft.EntityFrameworkCore;
using NLayer.Core.Models;
using NLayer.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.Repository.Repositories
{
    public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<Category> GetSingleCategoryByIdWithProductsAsync(int id)
        {
            // Bir tane kategoriye bağlı product lar gelecek

            return await _context.Categories.Include(p=>p.Products).Where(p=>p.Id == id).SingleOrDefaultAsync();
        }

        public async Task<List<Category>> GetCategoryWithProducts()
        {
            return await _context.Categories.Include(p=>p.Products).ToListAsync();
        }
    }
}
